using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

namespace Pincushion.LD53
{
    public class PickupDialogController : DialogControllerBase
    {
        public override void Init(CityController city, InputController input, IMission mission, Action OnOkClicked)
        {
            base.Init(city, input, mission, OnOkClicked);
            _root.Q<TextElement>("MissionText").text = mission.SourcePlatformText;
        }
    }
}