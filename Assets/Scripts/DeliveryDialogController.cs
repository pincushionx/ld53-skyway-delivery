using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

namespace Pincushion.LD53
{
    public class DeliveryDialogController : DialogControllerBase
    {
        public override void Init(CityController city, InputController input, IMission mission, Action OnOkClicked)
        {
            base.Init(city, input, mission, OnOkClicked);
            _root.Q<TextElement>("MissionText").text = mission.DesitnationPlatformText;
        }
    }
}