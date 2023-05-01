using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pincshion.LD53
{
    public class HighwayVehicleController : MonoBehaviour
    {
        private float _metersPerSecond = 5f;
        public Action<HighwayVehicleController> OnReachedDestination;

        private Transform _startTransform;
        private Transform _endTransform;
        Vector3 _distanceVector;
        float _distance;
        
        float _distancePerSecond;
        float _distanceTravelled;

        public void Init(Transform startTransform, Transform endTransform, float metersPerSecond)
        {
            _startTransform = startTransform;
            _endTransform = endTransform;
            _metersPerSecond = metersPerSecond;

            transform.position = startTransform.position;
            transform.rotation = startTransform.rotation;

            _distanceVector = startTransform.position - endTransform.position;
            _distance = _distanceVector.magnitude;
            //_distancePerSecond = _metersPerSecond / _distance;
        }

        // Update is called once per frame
        void Update()
        {
            _distanceTravelled += Time.deltaTime * _metersPerSecond;

            transform.position = Vector3.Lerp(_startTransform.position, _endTransform.position, _distanceTravelled / _distance);

            if (_distanceTravelled > _distance)
            {
                OnReachedDestination?.Invoke(this);
            }
        }
    }
}