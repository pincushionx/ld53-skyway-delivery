using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pincushion.LD53
{
    public class ColliderController : MonoBehaviour, IColliderController
    {
        [field: SerializeField] public string Name {get;set;}

        [field: SerializeField] public ColliderType ColliderType { get; set; }
    }
}