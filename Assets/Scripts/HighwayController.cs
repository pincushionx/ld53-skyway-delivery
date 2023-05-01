using Pincshion.LD53;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pincushion.LD53
{
    public class HighwayController : MonoBehaviour
    {
        [SerializeField] private Transform _startTransform;
        [SerializeField] private Transform _endTransform;
        [SerializeField] private GameObject[] _vehiclePrefabs;

        [SerializeField] private float _spawnRate = 2f;
        [SerializeField] private float _metersPerSecond = 5f;
        [SerializeField] private float minSpawnTime = 2f;


        private void Start()
        {
            StartCoroutine("SpawnCoroutine");
        }

        IEnumerator SpawnCoroutine()
        {
            yield return null;
            while (true)
            {
                int randIndex = Random.Range(0, _vehiclePrefabs.Length);
                GameObject prefab = _vehiclePrefabs[randIndex];
                GameObject go = Instantiate(prefab);
                go.transform.parent = transform;
                HighwayVehicleController controller = go.GetComponent<HighwayVehicleController>();
                controller.Init(_startTransform, _endTransform, _metersPerSecond);
                controller.OnReachedDestination += OnVehicleReachedDestination;
                yield return new WaitForSeconds(minSpawnTime + Random.value * _spawnRate);
            }
        }

        private void OnVehicleReachedDestination(HighwayVehicleController vehicle)
        {
            Destroy(vehicle.gameObject);
        }
    }
}