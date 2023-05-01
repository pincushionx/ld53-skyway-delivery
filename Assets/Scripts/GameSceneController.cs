using UnityEngine;
using UnityEngine.Assertions;

namespace Pincushion.LD53
{
    public class GameSceneController : MonoBehaviour
    {
        // Keep public, so the components can communicate with each other if needed.
        [SerializeField] private CityController _city;
        [SerializeField] private InputController _input;
        [SerializeField] private MissionController _mission;
        [SerializeField] private OverlayController _overlay;
        [SerializeField] private PlayerController _player;
        [SerializeField] private SoundController _sound;
        [SerializeField] private FloatingTextController _floatingText;
        [SerializeField] private Camera _camera;

        [SerializeField] private GameObject _beaconPrefab;
        [SerializeField] private GameObject _beaconContainer;
        private BeaconController _currentBeacon = null;

        private void Awake()
        {
            // Assert Inspector-provided stuff
            Assert.IsNotNull(_city);
            Assert.IsNotNull(_floatingText);
            Assert.IsNotNull(_input);
            Assert.IsNotNull(_mission);
            Assert.IsNotNull(_overlay);
            Assert.IsNotNull(_player);
            Assert.IsNotNull(_sound);
            Assert.IsNotNull(_camera);
            Assert.IsNotNull(_beaconPrefab);
            Assert.IsNotNull(_beaconContainer);

            // Connect dependencies
            _city.Init();
            _floatingText.Init(_camera.transform);
            _input.Init(_overlay);
            _mission.Init(_city, _player);
            _overlay.Init(this, _city, _player, _input, _sound, _mission);
            _player.Init(_input, _sound, _floatingText, _mission);
            _sound.Init();

            // Initialize events
            _player.OnCrash += OnCrash;
            _mission.OnMissionStarted += OnMissionStarted;
            _mission.OnSourceVisited += OnSourceVisited;
            _mission.OnMissionComplete += OnMissionComplete;
            _mission.OnOutOfMissions += Win;
        }

        private void Start()
        {
            // Start the game
            _player.Respawn(_city.Headquarters);
            NewMission();
        }

        private void OnMissionComplete(IMission obj)
        {
            Debug.Log("OnMissionComplete");

            _overlay.ShowDeliveryDialog(obj, () => OnMissionStepDialogClosed(obj));

            ClearBeacons();
            IPlatformController platform = _city.Headquarters;
            BeaconController beacon = SpawnBeacon(platform);

            _player.LookAtBeacon(beacon);
        }

        private void OnSourceVisited(IMission obj)
        {
            Debug.Log("OnSourceVisited");
            _overlay.ShowPickupDialog(obj, () => OnMissionStepDialogClosed(obj));

            ClearBeacons();
            IPlatformController platform = _city.DestinationPlatforms[obj.DestinationPlatformId];
            BeaconController beacon = SpawnBeacon(platform);

            _player.LookAtBeacon(beacon);
        }

        private void OnMissionStarted(IMission obj)
        {
            Debug.Log("OnMissionStarted");

            _overlay.ShowMissionStartDialog(obj, () => OnMissionStepDialogClosed(obj));

            ClearBeacons();
            IPlatformController platform = _city.SourcePlatforms[obj.SourcePlatformId];
            BeaconController beacon = SpawnBeacon(platform);

            _player.LookAtBeacon(beacon);

            _currentBeacon = beacon;
        }
        private void OnMissionStepDialogClosed(IMission mission)
        {
            _player.LookAtShip();
        }

        public void LookAtCurrentBeacon()
        {
            if (_currentBeacon != null)
            {
                _player.LookAtBeacon(_currentBeacon, 3f);
            }
        }
        
        private BeaconController SpawnBeacon(IPlatformController platform)
        {
            GameObject beaconGo = Instantiate(_beaconPrefab);
            beaconGo.transform.parent = _beaconContainer.transform;
            beaconGo.transform.position = platform.gameObject.transform.position;

            BeaconController beacon = beaconGo.GetComponent<BeaconController>();
            beacon.Init(platform);

            return beacon;
        }
        private void ClearBeacons()
        {
            for (int i = _beaconContainer.transform.childCount-1; i >= 0 ; i--)
            {
                Destroy(_beaconContainer.transform.GetChild(i).gameObject);
            }
        }

        private void NewMission()
        {
            _mission.NewMission();
        }

        private void OnCrash(IColliderController arg1, float arg2)
        {
            Debug.Log("The player crashed into a " + arg1.ColliderType.ToString() + " at an impact of " + arg2);

            Lose();
        }


        private void Win()
        {
            // No missions left

            // Show a win dialog
            _overlay.ShowWinConditionDialog(() => { });

            // Nice to have effects, maybe even the camera circling around the ship
        }
        private void Lose()
        {
            // Overlay
            _overlay.ShowLoseConditionDialog(() => {
                IPlatformController platform = _city.Headquarters;
                _player.Respawn(platform);
            });

            // Destroy the ship
            _player.CrashAndBurn();
        }
    }
}