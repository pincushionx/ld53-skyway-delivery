using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pincushion.LD53
{
    public class InputController : MonoBehaviour, Controls.IShipKeyboardMouseActions, Controls.IShipGamepadActions, Controls.IDialogGamepadActions, Controls.IDialogKeyboardActions
    {
        public event Action<Vector2> OnMoveHorizonal;
        public event Action<float> OnMoveVertical;
        public event Action OnConfirmPressed;
        public event Action OnStatusPressed;

        private Controls _controls;
        private Vector2 CurrentHorizontal = Vector2.zero;

        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new Controls();
                _controls.ShipKeyboardMouse.AddCallbacks(this);
                _controls.ShipKeyboardMouse.Enable();

                _controls.ShipGamepad.AddCallbacks(this);
                _controls.ShipGamepad.Enable();

                _controls.DialogGamepad.AddCallbacks(this);
                _controls.DialogGamepad.Disable();

                _controls.DialogKeyboard.AddCallbacks(this);
                _controls.DialogKeyboard.Disable();
            }
        }

        public void Init(OverlayController _overlay)
        {
            _overlay.OnDialogOpen += _overlay_OnDialogOpen;
            _overlay.OnDialogClosed += _overlay_OnDialogClosed;
        }

        private void _overlay_OnDialogClosed()
        {
            _controls.DialogGamepad.Disable();
            _controls.DialogKeyboard.Disable();

            _controls.ShipKeyboardMouse.Enable();
            _controls.ShipGamepad.Enable();

        }

        private void _overlay_OnDialogOpen()
        {
            _controls.DialogGamepad.Enable();
            _controls.DialogKeyboard.Enable();

            _controls.ShipKeyboardMouse.Disable();
            _controls.ShipGamepad.Disable();
        }

        public void OnZMovement(InputAction.CallbackContext context)
        {
            CurrentHorizontal.y = context.ReadValue<float>();
            OnMoveHorizonal?.Invoke(CurrentHorizontal);
        }

        public void OnXMovement(InputAction.CallbackContext context)
        {
            CurrentHorizontal.x = context.ReadValue<float>();
            OnMoveHorizonal?.Invoke(CurrentHorizontal);
        }

        public void OnVerticalMovement(InputAction.CallbackContext context)
        {
            float value = context.ReadValue<float>();
            OnMoveVertical?.Invoke(value);
        }

        public void OnHorizontalGamepadMovement(InputAction.CallbackContext context)
        {
            CurrentHorizontal = context.ReadValue<Vector2>();
            OnMoveHorizonal?.Invoke(CurrentHorizontal);
        }

        public void OnVerticalGamepadMovement(InputAction.CallbackContext context)
        {
            float value = context.ReadValue<float>();
            OnMoveVertical?.Invoke(value);
        }

        public void OnOk(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                OnConfirmPressed?.Invoke();
            }
        }

        public void OnStatusClick(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                OnStatusPressed?.Invoke();
            }
        }
    }
}