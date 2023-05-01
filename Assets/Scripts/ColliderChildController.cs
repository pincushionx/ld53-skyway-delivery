using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pincushion.LD53
{
    public class ColliderChildController : MonoBehaviour, IColliderChildController
    {
        [field: SerializeField] public IColliderController Parent { get; private set; }

        private void Awake()
        {
            IColliderController parent = GetComponentInParent<IColliderController>();
            if (parent == null)
            {
                Debug.LogError("ColliderChildController " + gameObject.name + " is missing a parent IColliderController");
            }

            Parent = parent;
        }
    }
}