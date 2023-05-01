using System;
using UnityEngine;

namespace Pincushion.LD53
{
    public class MissionController : MonoBehaviour
    {
        // Dependencies
        private CityController _city;
        private PlayerController _player;

        // Configuration
        [SerializeField] private MissionSO[] _missions;

        // Events
        public event Action<IMission> OnMissionStarted;
        public event Action<IMission> OnSourceVisited;
        public event Action<IMission> OnMissionComplete;
        public event Action OnOutOfMissions;
        public delegate void PlayerOnWrongPlatformDelegate(IMission mission, IPlatformController targetPlatform, IPlatformController landedPlatform);
        public event PlayerOnWrongPlatformDelegate OnPlayerOnWrongPlatform;

        // Internal
        private int _currentMissionIndex = -1;
        private MissionSO _currentMission = null;
        private MissionStep _missionStep = MissionStep.None;

        private float MissionStartTime = 0f;
        System.Diagnostics.Stopwatch _stopWatch = new System.Diagnostics.Stopwatch();


        private TimeSpan _totalTimeElapsed;
        public TimeSpan TotalTimeElapsed { get { return _totalTimeElapsed; } }
        public TimeSpan MissionTimeElapsed {get {return _stopWatch.Elapsed;} }
        public int MissionCount {get { return _missions.Length; } }
        public int MissionNumber { get { return _currentMissionIndex + 1; } }
        public bool IsMissionCompleted { get { return _missionStep == MissionStep.Completed; } }

        public string StatusText
        {
            get
            {
                switch (_missionStep) {

                    case MissionStep.VisitSource:
                        return "Pickup";

                    case MissionStep.VisitDestination:
                        return "Delivery";

                    case MissionStep.Completed:
                        return "Completed";

                    case MissionStep.None:
                    default:
                        return "";
                }
            }
        }

        public void PauseTimer()
        {
            _stopWatch.Stop();
        }
        public void UnpauseTimer()
        {
            _stopWatch.Start();
        }

        private void Start()
        {
            ValidateMissions();
        }

        public void Init(CityController city, PlayerController player)
        {
            _city = city;
            _player = player;

            _player.OnLandUpdate += OnLandUpdate;
        }

        // The player landed on a platform (without crashing)
        private void OnLandUpdate(IPlatformController arg1, float arg2)
        {

            if (_missionStep == MissionStep.Completed)
            {
                NewMission();
            }
            else if (_missionStep == MissionStep.VisitSource)
            {
                if (arg1.Id == _currentMission.SourcePlatformId)
                {
                    NextMissionStep();
                }
                else
                {
                    // Player landed on the wrong platform
                    IPlatformController expectedPlatform = _city.SourcePlatforms[_currentMission.SourcePlatformId];
                    OnPlayerOnWrongPlatform?.Invoke(_currentMission, expectedPlatform, arg1);
                }
            }
            else if (_missionStep == MissionStep.VisitDestination)
            {
                if (arg1.Id == _currentMission.DestinationPlatformId)
                {
                    NextMissionStep();
                }
                else
                {
                    // Player landed on the wrong platform
                    IPlatformController expectedPlatform = _city.DestinationPlatforms[_currentMission.DestinationPlatformId];
                    OnPlayerOnWrongPlatform?.Invoke(_currentMission, expectedPlatform, arg1);
                }
            }
            else
            {
                Debug.LogError("_missionStep not set");
            }

             
        }

        private void NextMissionStep()
        {
            if (_missionStep == MissionStep.VisitSource)
            {
                _missionStep = MissionStep.VisitDestination;
                OnSourceVisited?.Invoke(_currentMission);
            }
            else if (_missionStep == MissionStep.VisitDestination)
            {
                MissionComplete();
            }
        }

        private void MissionComplete()
        {
            _stopWatch.Stop();
            _totalTimeElapsed += _stopWatch.Elapsed;

            _missionStep = MissionStep.Completed;
            OnMissionComplete?.Invoke(_currentMission);
        }

        public void NewMission()
        {
            _currentMissionIndex++;
            if (_missions.Length <= _currentMissionIndex)
            {
                OnOutOfMissions?.Invoke();
                return;
            }

            MissionStartTime = Time.realtimeSinceStartup;
            _stopWatch.Restart();
            _stopWatch.Start();
            

            _currentMission = _missions[_currentMissionIndex];

            _missionStep = MissionStep.VisitSource;
            OnMissionStarted?.Invoke(_currentMission);
        }


        private void ValidateMissions()
        {
            foreach (var mission in _missions)
            {
                if (!_city.SourcePlatforms.ContainsKey(mission.SourcePlatformId))
                {
                    Debug.LogError(mission.Name + "(" + mission.name + ") has an unknown source platform id");
                }
                if (!_city.DestinationPlatforms.ContainsKey(mission.DestinationPlatformId))
                {
                    Debug.LogError(mission.Name + "(" + mission.name + ") has an unknown destination platform id");
                }
            }
        }

        private enum MissionStep
        {
            None,
            VisitSource, // need to visit the source
            VisitDestination, // need to visit the destination
            Completed,
        }
    }

}