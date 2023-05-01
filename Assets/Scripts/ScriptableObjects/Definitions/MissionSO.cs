using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pincushion.LD53
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MissionScriptableObject")]
    public class MissionSO : ScriptableObject, IMission
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: TextArea][field: SerializeField] public string Text { get; private set; }

        [field: TextArea][field: SerializeField] public string SourcePlatformText { get; private set; }
        [field: TextArea][field: SerializeField] public string DesitnationPlatformText { get; private set; }

        [field: SerializeField] public string SourcePlatformId { get; private set; }
        [field: SerializeField] public string DestinationPlatformId { get; private set; }


        // To Add - payload

    }
}