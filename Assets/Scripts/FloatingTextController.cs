using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pincushion.LD53
{
    public class FloatingTextController : MonoBehaviour
    {
        [SerializeField] private GameObject _floatingTextPrefab;
        [SerializeField] private Transform _lookAt;

        public void Init(Transform lookAt)
        {
            _lookAt = lookAt;
        }

        public void SpawnFloatingText(Vector3 position, Vector3 direction, string text)
        {
            GameObject go = Instantiate(_floatingTextPrefab);
            go.transform.position = position;

            FloatingTextInstanceController controller = go.GetComponent<FloatingTextInstanceController>();
            controller.Init(_lookAt, direction, text);
            
        }
    }
}