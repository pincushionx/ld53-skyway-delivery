using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pincushion.LD53
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlatformScriptableObject")]
    public class PlatformSO : ScriptableObject
    {
        public string Name;
        public PlatformType Type;
    }
}