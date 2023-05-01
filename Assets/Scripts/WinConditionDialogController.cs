using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

namespace Pincushion.LD53
{
    public class WinConditionDialogController : MonoBehaviour
    {
        private UIDocument _uiDocument;
        private VisualElement _root;

        bool initialized = false;

        private void OnEnable()
        {
            _uiDocument = GetComponent<UIDocument>();
            _root = _uiDocument.rootVisualElement;
        }

        public void Init(InputController input, MissionController mission, Action OnOkClicked)
        {
            if (!initialized)
            {
                // for the gamepad or if esc or similaris added to the keyboard
                input.OnConfirmPressed += OnOkClicked;
                initialized = true;
            }

            TimeSpan ts = mission.TotalTimeElapsed;
            _root.Q<TextElement>("TimerValue").text = String.Format("{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 100);
        }
    }
}