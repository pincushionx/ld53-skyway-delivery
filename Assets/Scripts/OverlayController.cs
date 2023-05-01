using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Pincushion.LD53
{
    public class OverlayController : MonoBehaviour
    {
        private GameSceneController _scene;
        private PlayerController _player;
        private CityController _city;
        private InputController _input;
        private SoundController _sound;
        private MissionController _mission;

        private UIDocument _uiDocument;
        private VisualElement _root;

        [SerializeField] private MissionStartDialogController _missionStartDialog;
        [SerializeField] private PickupDialogController _pickupDialog;
        [SerializeField] private DeliveryDialogController _deliveryDialog;
        [SerializeField] private WinConditionDialogController _winConditionDialog;
        [SerializeField] private LoseConditionDialogController _loseConditionDialog;

        public event Action OnDialogOpen;
        public event Action OnDialogClosed;



        private void Awake()
        {
            _uiDocument = GetComponent<UIDocument>();
            _root = _uiDocument.rootVisualElement;


            // Initialize dialogs
            CloseAllDialogs();

            InitializeMissionOverlay();

            _timerElement = _root.Q<TextElement>("TimerValue");
        }

        public void Init(GameSceneController gameSceneController, CityController city, PlayerController player,
            InputController input, SoundController sound, MissionController mission)
        {
            _scene = gameSceneController;
            _player = player;
            _city = city;
            _input = input;
            _sound = sound;
            _mission = mission;

            _player.OnVelocityUpdate += OnVelocityUpdate;
            _player.OnLandUpdate += OnLandUpdate;
            _input.OnStatusPressed += OnStatusClicked;
            _mission.OnMissionComplete += OnMissionComplete;

            _root.Q<TextElement>("StatusValue").RegisterCallback<ClickEvent>((e) => { OnStatusClicked(); });
            
        }

        private void Start()
        {
            _root.Q<TextElement>("MissionCountValue").text = "01 of " + _mission.MissionCount;
        }

        private TextElement _timerElement;
        private void Update()
        {
            TimeSpan ts = _mission.MissionTimeElapsed;
            _timerElement.text = String.Format("{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 100);

            
        }

        private void OnMissionComplete(IMission obj)
        {
            _root.Q<TextElement>("MissionCountValue").text = _mission.MissionNumber.ToString("D2") + " of " + _mission.MissionCount;

            TimeSpan ts = _mission.TotalTimeElapsed;
            _root.Q<TextElement>("ScoreValue").text = String.Format("{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 100);
        }

        private void OnStatusClicked()
        {
            _scene.LookAtCurrentBeacon();
        }

        private void InitializeMissionOverlay()
        {
            _root.Q<TextElement>("MissionName").text = "";
            _root.Q<TextElement>("MissionText").text = "";
            _root.Q<TextElement>("PickupValue").text = "";
            _root.Q<TextElement>("DeliveryValue").text = "";
            _root.Q<TextElement>("StatusValue").text = "";
        }
        private void UpdateMissionOverlay(IMission mission)
        {
            _root.Q<TextElement>("MissionName").text = mission.Name;
            _root.Q<TextElement>("MissionText").text = mission.Text;
            _root.Q<TextElement>("PickupValue").text = _city.SourcePlatforms[mission.SourcePlatformId].Name;
            _root.Q<TextElement>("DeliveryValue").text = _city.DestinationPlatforms[mission.DestinationPlatformId].Name;
            _root.Q<TextElement>("StatusValue").text = _mission.StatusText;
        }

        public void ShowMissionStartDialog(IMission mission, Action onDialogClosed)
        {
            _mission.PauseTimer();

            _missionStartDialog.gameObject.SetActive(true);
            _missionStartDialog.Init(_city, _input, mission, () => { CloseAllDialogs(); onDialogClosed(); UpdateMissionOverlay(mission); _mission.UnpauseTimer(); });
            OnDialogOpen?.Invoke();
        }
        public void ShowPickupDialog(IMission mission, Action onDialogClosed)
        {
            _mission.PauseTimer();

            _pickupDialog.gameObject.SetActive(true);
            _pickupDialog.Init(_city, _input, mission, () => { CloseAllDialogs(); onDialogClosed(); UpdateMissionOverlay(mission); _mission.UnpauseTimer(); });
            OnDialogOpen?.Invoke();
        }
        public void ShowDeliveryDialog(IMission mission, Action onDialogClosed)
        {
            _mission.PauseTimer();

            _deliveryDialog.gameObject.SetActive(true);
            _deliveryDialog.Init(_city, _input, mission, () => { CloseAllDialogs(); onDialogClosed(); UpdateMissionOverlay(mission); _mission.UnpauseTimer(); });
            OnDialogOpen?.Invoke();
        }
        public void ShowWinConditionDialog(Action onDialogClosed)
        {
            _mission.PauseTimer();

            _winConditionDialog.gameObject.SetActive(true);
            _winConditionDialog.Init(_input, _mission, () => { CloseAllDialogs(); onDialogClosed(); });
            OnDialogOpen?.Invoke();
        }
        public void ShowLoseConditionDialog(Action onDialogClosed)
        {
            _mission.PauseTimer();

            _loseConditionDialog.gameObject.SetActive(true);
            _loseConditionDialog.Init(_input, () => { _mission.UnpauseTimer(); CloseAllDialogs(); onDialogClosed(); });
            OnDialogOpen?.Invoke();
        }

        private void CloseAllDialogs()
        {
            _missionStartDialog.gameObject.SetActive(false);
            _pickupDialog.gameObject.SetActive(false);
            _deliveryDialog.gameObject.SetActive(false);
            _winConditionDialog.gameObject.SetActive(false);
            _loseConditionDialog.gameObject.SetActive(false);
            OnDialogClosed?.Invoke();
        }

        private void OnLandUpdate(IPlatformController arg1, float arg2)
        {
            UpdateLandingSpeed(arg2);
        }

        private void OnVelocityUpdate(Vector3 obj)
        {
            UpdateSpeed(obj.magnitude);
        }

        private void UpdateLandingSpeed(float speed)
        {
            //_root.Q<TextElement>("LandingVelocityValue").text = speed.ToString("N1");
        }

        private void UpdateSpeed(float speed)
        {
            _root.Q<TextElement>("VelocityValue").text = speed.ToString("N1");
        }
    }
}