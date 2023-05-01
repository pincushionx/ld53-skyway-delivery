using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pincushion.LD53
{
    public interface IColliderController
    {
        public string Name { get; }
        public ColliderType ColliderType { get; }
        public GameObject gameObject { get; }
    }

    public enum ColliderType
    {
        Platform = 0x1,
        Building = 0x2,
        Vehicle = 0x4,
        Ground = 0x8,
        Sign = 0x10,
    }
}