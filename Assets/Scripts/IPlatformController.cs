using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pincushion.LD53
{
    public interface IPlatformController
    {
        //PlatformSO PlatformData { get; }
        string Id { get; }
        string Name { get; }
        PlatformType PlatformType { get; }
        GameObject gameObject { get; }
        Transform SpawnTransform {get; }
    }

    public enum PlatformType
    {
        Source = 0x1,
        Destination = 0x2,
        Headquarters = 0x4,
    }
}