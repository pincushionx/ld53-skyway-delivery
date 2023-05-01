using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Pincushion.LD53
{
    public class ThrusterController : MonoBehaviour
    {
        public ThrusterDirection ThrusterDirection;
        private ParticleSystem _particles;

        private void Awake()
        {
            _particles = GetComponent<ParticleSystem>();
        }

        public void Init(InputController input)
        {
            if (ThrusterDirection == ThrusterDirection.Vertical) {
                input.OnMoveVertical += OnMoveVertical;
            }
            else if (ThrusterDirection == ThrusterDirection.Horizontal)
            {
                input.OnMoveHorizonal += OnMoveHorizonal;
            }
        }

        private void OnMoveHorizonal(Vector2 obj)
        {
            if (obj.y > 0f)
            {
                _particles.Play();
            }
            else
            {
                if (!_particles.IsDestroyed())
                {
                    _particles.Stop();
                }
            }
        }

        private void OnMoveVertical(float obj)
        {
            if (obj > 0f)
            {
                _particles.Play();
            }
            else
            {
                _particles.Stop();
            }
        }
    }

    public enum ThrusterDirection
    {
        Vertical = 0x1,
        Horizontal = 0x2,
    }
}