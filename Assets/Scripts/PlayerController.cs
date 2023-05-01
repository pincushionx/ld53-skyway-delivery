using System;
using System.Collections;
using UnityEngine;

namespace Pincushion.LD53
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        // Dependencies
        private InputController _input;
        private SoundController _sound;
        private FloatingTextController _floatingText;
        private MissionController _mission;
        private Rigidbody _rigidbody;

        // Inspector
        [SerializeField] private Vector3 _forceMultiplier = Vector3.one;
        [SerializeField] private Vector3 _torqueMultiplier = Vector3.one;
        [SerializeField] private float _lookUpDownMultiplier = 1f;
        [SerializeField] private float _crashThreshold = 10f;
        [SerializeField] private float _sparkThreshold = 5f;
        [SerializeField] private Transform _lookPosition;
        [SerializeField] private GameObject _shipModel; // for when it crashes
        [SerializeField] private GameObject _explosion; // for when it crashes
        [SerializeField] private ParticleSystem _sparks; // for when it nearly
        [SerializeField] private Transform _floatingTextPosition;
        [SerializeField] private float _lookSmoothTime = .5f;
        private float _currentLookVelocity;
        
        private Vector3 _originalLookPosition;
        private bool _returningLookToShip = false;
        bool _inLookingCoroutine = false;

        // Events
        public event Action<Vector3> OnVelocityUpdate;
        public event Action<IPlatformController, float> OnLandUpdate;
        public event Action<IColliderController, float> OnCrash;

        // internal
        private Vector2 _horizontalForce = Vector2.zero;
        private float _verticalForce = 0f;
        private float _rotationForce = 0f;
        private Vector3 _tilt = Vector3.zero;
        private Vector3 _velocity = Vector3.zero;


        float _rotation = 0;
        float _targetRotation = 0;
        float _currentRotationVelocity;
        float _smoothRotationTime = 0.1f;

        float _timeSinceRespawn = 0f;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _originalLookPosition = _lookPosition.localPosition;

            _explosion.gameObject.SetActive(false);
        }

        public void Init(InputController input, SoundController sound, FloatingTextController floatingText, MissionController mission)
        {
            _input = input;
            _input.OnMoveVertical += OnMoveVertical;
            _input.OnMoveHorizonal += OnMoveHorizonal;

            _sound = sound;
            _floatingText = floatingText;
            _mission = mission;

            InitializeThrusters();
        }

        private void Start()
        {
            _timeSinceRespawn = Time.realtimeSinceStartup;
        }

        private void Update()
        {
            
        }
        
        private void InitializeThrusters()
        {
            ThrusterController[] thrusters = GetComponentsInChildren<ThrusterController>();
            foreach (ThrusterController thruster in thrusters)
            {
                thruster.Init(_input);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_mission.MissionTimeElapsed.TotalSeconds < 5f || (Time.realtimeSinceStartup - _timeSinceRespawn) < 5f)
            {
                // this is just the ship adjusting
                return;
            }

            // IColliderChildController is placed on children that have the colliders.
            // It provides a link back to the controlling game object
            IColliderChildController childCollider = collision.gameObject.GetComponent<IColliderChildController>();
            IColliderController colliderController = (childCollider != null)? childCollider.Parent : collision.gameObject.GetComponent<IColliderController>();

            if (colliderController == null)
            {
                Debug.LogError("Collider " + gameObject.name + " is missing its IColliderController");
                return;
            }

            Vector3 collisionNormal = collision.contacts[0].normal;
            float impact = _velocity.magnitude;
            if (impact >= _crashThreshold)
            {
                // The player crashed
                _floatingText.SpawnFloatingText(_floatingTextPosition.position, collisionNormal, "Impact " + FormatImpact(impact) + " !!!");
                OnCrash?.Invoke(colliderController, impact);
                return;
            }
            else if (colliderController.ColliderType == ColliderType.Platform)
            {
                IPlatformController platform = colliderController.gameObject.GetComponent<IPlatformController>();
                if (platform != null)
                {
                    Debug.Log("Platform: Collided with " + platform.Name + " type:" + platform.PlatformType.ToString() +
                        " impulse:" + collision.impulse + " force:" + _rigidbody.velocity +
                        " relativeVelocity:" + collision.relativeVelocity + "cached velocity:" + _velocity);

                    OnLandUpdate?.Invoke(platform, impact);


                    if (impact >= _sparkThreshold)
                    {
                        // Nearly crashed
                        _floatingText.SpawnFloatingText(_floatingTextPosition.position, collisionNormal, "Impact " + FormatImpact(impact) + " Close one!");
                        _sparks.Play();
                    }
                    else
                    {
                        _floatingText.SpawnFloatingText(_floatingTextPosition.position, collisionNormal, "Impact " + FormatImpact(impact) + " Nice landing!");
                    }
                }
                else
                {
                    Debug.LogError("Platform is missing IPlatformController");
                }
            }
            else
            {
                if (impact >= _sparkThreshold)
                {
                    // Nearly crashed
                    _floatingText.SpawnFloatingText(_floatingTextPosition.position, collisionNormal, "Hit " + colliderController.Name + ". Impact " + FormatImpact(impact) + ". Don't lose your ship!");
                    _sparks.Play();
                }
                else
                {
                    _floatingText.SpawnFloatingText(_floatingTextPosition.position, collisionNormal, "Hit " + colliderController.Name  + ". Impact " + FormatImpact(impact) + ". Be careful!");
                }


                Debug.Log(colliderController.ColliderType.ToString() + " Collided with " + colliderController.Name +
                    " impulse:" + collision.impulse + " force:" + _rigidbody.velocity +
                    " relativeVelocity" + collision.relativeVelocity + "cached velocity:" + _velocity);
            }
        }

        private string FormatImpact(float impact)
        {
            return impact.ToString("N1");
        }

        public void LookAtBeacon(BeaconController beacon)
        {
            StartCoroutine(LookAtBeaconCoroutine(beacon));
        }
        public void LookAtShip()
        {
            StartCoroutine(LookAtShipCoroutine());
        }

        public void LookAtBeacon(BeaconController beacon, float duration)
        {
            StartCoroutine(LookAtBeaconForDurationCoroutine(beacon, duration));
        }

        private IEnumerator LookAtBeaconForDurationCoroutine(BeaconController beacon, float duration)
        {
            yield return null;

            _inLookingCoroutine = true;
            float increment = 0.1f;

            Vector3 currentLookPosition = _lookPosition.position;
            Vector3 targetLookPosition = new Vector3(beacon.transform.position.x, 200, beacon.transform.position.z);

            for (float i = 0f; i < duration; i += increment)
            {
                if (_returningLookToShip)
                {
                    break;
                }

                _lookPosition.position = Vector3.Slerp(currentLookPosition, targetLookPosition, i / duration);
                yield return new WaitForSeconds(increment);
            }

            _inLookingCoroutine = false;
            LookAtShip();
        }

        private IEnumerator LookAtBeaconCoroutine(BeaconController beacon)
        {
            _inLookingCoroutine = true;

            yield return new WaitForSeconds(1f);

            float duration = 3f;
            float increment = 0.1f;
            float endTime = Time.realtimeSinceStartup + duration;

            Vector3 currentLookPosition = _lookPosition.position;
            Vector3 targetLookPosition = new Vector3(beacon.transform.position.x, 200, beacon.transform.position.z);

            for(float i = 0f; i < duration; i += increment)
            {
                if (_returningLookToShip)
                {
                    break;
                }

                _lookPosition.position = Vector3.Slerp(currentLookPosition, targetLookPosition, i / duration);
                yield return new WaitForSeconds(increment);
            }

            _inLookingCoroutine = false;
        }
        private IEnumerator LookAtShipCoroutine()
        {
            _inLookingCoroutine = true;
            _returningLookToShip = true;

            yield return new WaitForSeconds(1f);

            float duration = 1f;
            float increment = 0.1f;

            Vector3 currentLookPosition = _lookPosition.localPosition;
            
            for (float i = 0f; i < duration; i += increment)
            {
                _lookPosition.localPosition = Vector3.Slerp(currentLookPosition, _originalLookPosition, i / duration);
                yield return new WaitForSeconds(increment);
            }
            _returningLookToShip = false;
            _inLookingCoroutine = false;
        }

        public void CrashAndBurn()
        {
            // The ship crashed, destroy the ship
            _shipModel.gameObject.SetActive(false);
            _rigidbody.isKinematic = true;
            // add effects
            _sound.PlaySound("Explosion");
            _explosion.gameObject.SetActive(true);
        }
        public void Respawn(IPlatformController platform)
        {
            // Respawn the ship at the given platform
            _timeSinceRespawn = Time.realtimeSinceStartup;

            _rigidbody.isKinematic = false;
            _shipModel.gameObject.SetActive(true);
            _rigidbody.Move(platform.SpawnTransform.position, platform.SpawnTransform.rotation);

            _velocity = _rigidbody.velocity;
            _rotationForce = 0f;
            _verticalForce = 0f;
            _horizontalForce = Vector2.zero;
            _rotation = 0;
            _targetRotation = 0;
            _currentRotationVelocity = 0;

            _sound.StopSound("Explosion");
            _explosion.gameObject.SetActive(false);

            // In case the player can turn it in by crashing
            if (_mission.IsMissionCompleted)
            {
                OnLandUpdate?.Invoke(platform, 0);
            }
        }

        private void OnMoveHorizonal(Vector2 obj)
        {
            _rotationForce = obj.x;
            _horizontalForce.y = obj.y;
            UpdateThrustSound();
        }

        private void OnMoveVertical(float obj)
        {
            _verticalForce = obj;
            UpdateThrustSound();
        }

        private void UpdateThrustSound()
        {
            if (_verticalForce > 0 || _horizontalForce.y > 0)
            {
                _sound.PlaySound("Thrusters");
            }
            else
            {
                _sound.StopSound("Thrusters");
            }
        }


        private void FixedUpdate()
        {
            if (_verticalForce > 0f || _horizontalForce != Vector2.zero)
            {
                Vector3 force = new Vector3(
                    _forceMultiplier.x * _horizontalForce.x,
                    _forceMultiplier.y * _verticalForce,
                    _forceMultiplier.z * _horizontalForce.y
                );
                //Debug.Log("moving " + force);
                force = transform.TransformVector(force);
                _rigidbody.AddForce(force);
            }
            if (_tilt != Vector3.zero || _rotationForce != 0f)
            {
                _targetRotation += _rotationForce * _torqueMultiplier.y;
                _rotation = Mathf.SmoothDampAngle(_rotation, _targetRotation, ref _currentRotationVelocity, _smoothRotationTime, Mathf.Infinity, Time.fixedDeltaTime);
                _rigidbody.MoveRotation(Quaternion.Euler(_tilt.x * _torqueMultiplier.x, _rotation, _tilt.z * _torqueMultiplier.z));
            }
            /*if (_rotationForce != 0f)
            {
                _rigidbody.AddTorque(0, _rotationForce * _torqueMultiplier.y, 0, ForceMode.Force);
                //Debug.Log("rotating " + rotationForce * torqueMultiplier.y);
            }
            if (_tilt != Vector3.zero)
            {
                //_rigidbody.MoveRotation(Quaternion.Euler(_tilt.x * torqueMultiplier.x, 0, _tilt.z * torqueMultiplier.z));
                _rigidbody.MoveRotation(Quaternion.Euler(_tilt.x * _torqueMultiplier.x, 0, _tilt.z * _torqueMultiplier.z));
            }*/

            Vector3 velocity = _rigidbody.velocity;
            if (_velocity != velocity)
            {
                _velocity = velocity;
                OnVelocityUpdate?.Invoke(_velocity);
            }




            if (!_inLookingCoroutine)
            {
                Vector3 lookpos = _originalLookPosition;

                float targetLookPos = lookpos.y + _rigidbody.velocity.y * _lookUpDownMultiplier;
                lookpos.y = Mathf.SmoothDamp(lookpos.y, targetLookPos, ref _currentLookVelocity, _lookSmoothTime);

                _lookPosition.localPosition = lookpos;
            }
        }
    }
}