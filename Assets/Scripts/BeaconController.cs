using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pincushion.LD53
{
    public class BeaconController : MonoBehaviour
    {
        [SerializeField] private Material sourceMaterial;
        [SerializeField] private Material destinationMaterial;
        [SerializeField] private Material hqMaterial;

        private IPlatformController _platform;
        [SerializeField] private GameObject _model;

        private float _rotation = 0;

        public void Init(IPlatformController platform)
        {
            switch (platform.PlatformType) {
                case PlatformType.Source:
                    _model.GetComponent<MeshRenderer>().material = sourceMaterial;
                    break;
                case PlatformType.Destination:
                    _model.GetComponent<MeshRenderer>().material = destinationMaterial;
                    break;
                case PlatformType.Headquarters:
                    _model.GetComponent<MeshRenderer>().material = hqMaterial;
                    break;
                default:
                    _model.GetComponent<MeshRenderer>().material = destinationMaterial; // it's magenta
                    break;
            }
        }

        private void Update()
        {
            _rotation += Time.deltaTime * 90;
            transform.localEulerAngles = new Vector3(0, _rotation, 0);
        }
    }
}