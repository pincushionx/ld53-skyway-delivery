using Pincushion.LD53;
using UnityEngine;

namespace Pincushion.LD53
{
    public class PlatformController : MonoBehaviour, IPlatformController, IColliderController
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public PlatformType PlatformType { get; private set; }
        [field: SerializeField] public ColliderType ColliderType { get; private set; }
        [field: SerializeField] public Transform SpawnTransform { get; private set; }
    }
}