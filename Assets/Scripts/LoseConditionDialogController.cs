using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Pincushion.LD53
{
    public class LoseConditionDialogController : MonoBehaviour
    {
        private UIDocument _uiDocument;
        private VisualElement _root;

        bool initialized = false;

        private void OnEnable()
        {
            _uiDocument = GetComponent<UIDocument>();
            _root = _uiDocument.rootVisualElement;
        }

        public void Init(InputController input, Action OnOkClicked)
        {
            if (!initialized)
            {
                // for the gamepad or if esc or similaris added to the keyboard
                input.OnConfirmPressed += OnOkClicked;
                initialized = true;
            }
        }
    }
}