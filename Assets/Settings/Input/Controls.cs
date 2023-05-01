//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Settings/Input/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Pincushion.LD53
{
    public partial class @Controls: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""ShipKeyboardMouse"",
            ""id"": ""849fd633-418f-47b3-9c41-aa72bff7c8d8"",
            ""actions"": [
                {
                    ""name"": ""ZMovement"",
                    ""type"": ""Button"",
                    ""id"": ""efa1cb0c-c28f-46fc-882d-a8e3a2402e64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""XMovement"",
                    ""type"": ""Button"",
                    ""id"": ""96cc5273-88b1-4578-8c93-492382090ada"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""VerticalMovement"",
                    ""type"": ""Button"",
                    ""id"": ""63310a9a-4122-49b0-9ba7-a9038290481e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Forward/Reverse Keys"",
                    ""id"": ""ad664e54-ac8f-4218-8a98-716be352da34"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f772b721-269e-474a-ae7d-9dd384271e1e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ca942f61-e2b2-4b56-9102-5c49797260bb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left/Right Keys"",
                    ""id"": ""1c0b0174-0357-4b62-bc06-32f69913347b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7360cda0-5a79-4649-bc9e-38c01fe5389a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2547ec8e-9ecf-4143-8e40-136763db1c4b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Up/Down Keys"",
                    ""id"": ""3463b3ac-51de-42ca-b99c-ac9ee9e12c04"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""16f0d53b-be8c-460f-9ed7-57c4a8c58874"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""57f18668-2197-4374-b512-3756feb1cd30"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Ship-Gamepad"",
            ""id"": ""1cdd6714-ceef-4924-bc90-bbfc994c8628"",
            ""actions"": [
                {
                    ""name"": ""HorizontalGamepadMovement"",
                    ""type"": ""Value"",
                    ""id"": ""6d628d4f-a641-486d-bae1-903ed9df9d97"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""VerticalGamepadMovement"",
                    ""type"": ""Button"",
                    ""id"": ""13ef7f2b-83ff-48ef-93dc-a6776142e2ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StatusClick"",
                    ""type"": ""Button"",
                    ""id"": ""f0aa3716-4c81-4010-b6cc-8ec9e74e7545"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1b55f4b7-0a09-425a-b7b3-b5dbb6368155"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalGamepadMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1d22efa-5734-48c3-b3ca-f924e4be763f"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalGamepadMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc93baf4-348d-4029-ac6c-c9727ced277c"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StatusClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dialog-Gamepad"",
            ""id"": ""2e2d6435-6c78-43ed-b0a9-0a5883d5e5aa"",
            ""actions"": [
                {
                    ""name"": ""Ok"",
                    ""type"": ""Button"",
                    ""id"": ""f8943933-a37c-4ecc-9422-5a63a7b74d97"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StatusClick"",
                    ""type"": ""Button"",
                    ""id"": ""19df219f-4626-446e-a68f-97b6ca494a6c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4da5da2e-8d7a-4517-b0ac-6ed48c20c1bd"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ok"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21ce99f7-3879-4bd7-a7a0-ef0224513a30"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StatusClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dialog-Keyboard"",
            ""id"": ""478fcbae-78f7-4006-b845-953bdcac5732"",
            ""actions"": [
                {
                    ""name"": ""Ok"",
                    ""type"": ""Button"",
                    ""id"": ""c0b0af53-3182-4b59-95d2-d71721181779"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3286052f-b8d4-449c-ad90-9ecaa7368716"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ok"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // ShipKeyboardMouse
            m_ShipKeyboardMouse = asset.FindActionMap("ShipKeyboardMouse", throwIfNotFound: true);
            m_ShipKeyboardMouse_ZMovement = m_ShipKeyboardMouse.FindAction("ZMovement", throwIfNotFound: true);
            m_ShipKeyboardMouse_XMovement = m_ShipKeyboardMouse.FindAction("XMovement", throwIfNotFound: true);
            m_ShipKeyboardMouse_VerticalMovement = m_ShipKeyboardMouse.FindAction("VerticalMovement", throwIfNotFound: true);
            // Ship-Gamepad
            m_ShipGamepad = asset.FindActionMap("Ship-Gamepad", throwIfNotFound: true);
            m_ShipGamepad_HorizontalGamepadMovement = m_ShipGamepad.FindAction("HorizontalGamepadMovement", throwIfNotFound: true);
            m_ShipGamepad_VerticalGamepadMovement = m_ShipGamepad.FindAction("VerticalGamepadMovement", throwIfNotFound: true);
            m_ShipGamepad_StatusClick = m_ShipGamepad.FindAction("StatusClick", throwIfNotFound: true);
            // Dialog-Gamepad
            m_DialogGamepad = asset.FindActionMap("Dialog-Gamepad", throwIfNotFound: true);
            m_DialogGamepad_Ok = m_DialogGamepad.FindAction("Ok", throwIfNotFound: true);
            m_DialogGamepad_StatusClick = m_DialogGamepad.FindAction("StatusClick", throwIfNotFound: true);
            // Dialog-Keyboard
            m_DialogKeyboard = asset.FindActionMap("Dialog-Keyboard", throwIfNotFound: true);
            m_DialogKeyboard_Ok = m_DialogKeyboard.FindAction("Ok", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // ShipKeyboardMouse
        private readonly InputActionMap m_ShipKeyboardMouse;
        private List<IShipKeyboardMouseActions> m_ShipKeyboardMouseActionsCallbackInterfaces = new List<IShipKeyboardMouseActions>();
        private readonly InputAction m_ShipKeyboardMouse_ZMovement;
        private readonly InputAction m_ShipKeyboardMouse_XMovement;
        private readonly InputAction m_ShipKeyboardMouse_VerticalMovement;
        public struct ShipKeyboardMouseActions
        {
            private @Controls m_Wrapper;
            public ShipKeyboardMouseActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @ZMovement => m_Wrapper.m_ShipKeyboardMouse_ZMovement;
            public InputAction @XMovement => m_Wrapper.m_ShipKeyboardMouse_XMovement;
            public InputAction @VerticalMovement => m_Wrapper.m_ShipKeyboardMouse_VerticalMovement;
            public InputActionMap Get() { return m_Wrapper.m_ShipKeyboardMouse; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ShipKeyboardMouseActions set) { return set.Get(); }
            public void AddCallbacks(IShipKeyboardMouseActions instance)
            {
                if (instance == null || m_Wrapper.m_ShipKeyboardMouseActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_ShipKeyboardMouseActionsCallbackInterfaces.Add(instance);
                @ZMovement.started += instance.OnZMovement;
                @ZMovement.performed += instance.OnZMovement;
                @ZMovement.canceled += instance.OnZMovement;
                @XMovement.started += instance.OnXMovement;
                @XMovement.performed += instance.OnXMovement;
                @XMovement.canceled += instance.OnXMovement;
                @VerticalMovement.started += instance.OnVerticalMovement;
                @VerticalMovement.performed += instance.OnVerticalMovement;
                @VerticalMovement.canceled += instance.OnVerticalMovement;
            }

            private void UnregisterCallbacks(IShipKeyboardMouseActions instance)
            {
                @ZMovement.started -= instance.OnZMovement;
                @ZMovement.performed -= instance.OnZMovement;
                @ZMovement.canceled -= instance.OnZMovement;
                @XMovement.started -= instance.OnXMovement;
                @XMovement.performed -= instance.OnXMovement;
                @XMovement.canceled -= instance.OnXMovement;
                @VerticalMovement.started -= instance.OnVerticalMovement;
                @VerticalMovement.performed -= instance.OnVerticalMovement;
                @VerticalMovement.canceled -= instance.OnVerticalMovement;
            }

            public void RemoveCallbacks(IShipKeyboardMouseActions instance)
            {
                if (m_Wrapper.m_ShipKeyboardMouseActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IShipKeyboardMouseActions instance)
            {
                foreach (var item in m_Wrapper.m_ShipKeyboardMouseActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_ShipKeyboardMouseActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public ShipKeyboardMouseActions @ShipKeyboardMouse => new ShipKeyboardMouseActions(this);

        // Ship-Gamepad
        private readonly InputActionMap m_ShipGamepad;
        private List<IShipGamepadActions> m_ShipGamepadActionsCallbackInterfaces = new List<IShipGamepadActions>();
        private readonly InputAction m_ShipGamepad_HorizontalGamepadMovement;
        private readonly InputAction m_ShipGamepad_VerticalGamepadMovement;
        private readonly InputAction m_ShipGamepad_StatusClick;
        public struct ShipGamepadActions
        {
            private @Controls m_Wrapper;
            public ShipGamepadActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @HorizontalGamepadMovement => m_Wrapper.m_ShipGamepad_HorizontalGamepadMovement;
            public InputAction @VerticalGamepadMovement => m_Wrapper.m_ShipGamepad_VerticalGamepadMovement;
            public InputAction @StatusClick => m_Wrapper.m_ShipGamepad_StatusClick;
            public InputActionMap Get() { return m_Wrapper.m_ShipGamepad; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ShipGamepadActions set) { return set.Get(); }
            public void AddCallbacks(IShipGamepadActions instance)
            {
                if (instance == null || m_Wrapper.m_ShipGamepadActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_ShipGamepadActionsCallbackInterfaces.Add(instance);
                @HorizontalGamepadMovement.started += instance.OnHorizontalGamepadMovement;
                @HorizontalGamepadMovement.performed += instance.OnHorizontalGamepadMovement;
                @HorizontalGamepadMovement.canceled += instance.OnHorizontalGamepadMovement;
                @VerticalGamepadMovement.started += instance.OnVerticalGamepadMovement;
                @VerticalGamepadMovement.performed += instance.OnVerticalGamepadMovement;
                @VerticalGamepadMovement.canceled += instance.OnVerticalGamepadMovement;
                @StatusClick.started += instance.OnStatusClick;
                @StatusClick.performed += instance.OnStatusClick;
                @StatusClick.canceled += instance.OnStatusClick;
            }

            private void UnregisterCallbacks(IShipGamepadActions instance)
            {
                @HorizontalGamepadMovement.started -= instance.OnHorizontalGamepadMovement;
                @HorizontalGamepadMovement.performed -= instance.OnHorizontalGamepadMovement;
                @HorizontalGamepadMovement.canceled -= instance.OnHorizontalGamepadMovement;
                @VerticalGamepadMovement.started -= instance.OnVerticalGamepadMovement;
                @VerticalGamepadMovement.performed -= instance.OnVerticalGamepadMovement;
                @VerticalGamepadMovement.canceled -= instance.OnVerticalGamepadMovement;
                @StatusClick.started -= instance.OnStatusClick;
                @StatusClick.performed -= instance.OnStatusClick;
                @StatusClick.canceled -= instance.OnStatusClick;
            }

            public void RemoveCallbacks(IShipGamepadActions instance)
            {
                if (m_Wrapper.m_ShipGamepadActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IShipGamepadActions instance)
            {
                foreach (var item in m_Wrapper.m_ShipGamepadActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_ShipGamepadActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public ShipGamepadActions @ShipGamepad => new ShipGamepadActions(this);

        // Dialog-Gamepad
        private readonly InputActionMap m_DialogGamepad;
        private List<IDialogGamepadActions> m_DialogGamepadActionsCallbackInterfaces = new List<IDialogGamepadActions>();
        private readonly InputAction m_DialogGamepad_Ok;
        private readonly InputAction m_DialogGamepad_StatusClick;
        public struct DialogGamepadActions
        {
            private @Controls m_Wrapper;
            public DialogGamepadActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Ok => m_Wrapper.m_DialogGamepad_Ok;
            public InputAction @StatusClick => m_Wrapper.m_DialogGamepad_StatusClick;
            public InputActionMap Get() { return m_Wrapper.m_DialogGamepad; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DialogGamepadActions set) { return set.Get(); }
            public void AddCallbacks(IDialogGamepadActions instance)
            {
                if (instance == null || m_Wrapper.m_DialogGamepadActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_DialogGamepadActionsCallbackInterfaces.Add(instance);
                @Ok.started += instance.OnOk;
                @Ok.performed += instance.OnOk;
                @Ok.canceled += instance.OnOk;
                @StatusClick.started += instance.OnStatusClick;
                @StatusClick.performed += instance.OnStatusClick;
                @StatusClick.canceled += instance.OnStatusClick;
            }

            private void UnregisterCallbacks(IDialogGamepadActions instance)
            {
                @Ok.started -= instance.OnOk;
                @Ok.performed -= instance.OnOk;
                @Ok.canceled -= instance.OnOk;
                @StatusClick.started -= instance.OnStatusClick;
                @StatusClick.performed -= instance.OnStatusClick;
                @StatusClick.canceled -= instance.OnStatusClick;
            }

            public void RemoveCallbacks(IDialogGamepadActions instance)
            {
                if (m_Wrapper.m_DialogGamepadActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IDialogGamepadActions instance)
            {
                foreach (var item in m_Wrapper.m_DialogGamepadActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_DialogGamepadActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public DialogGamepadActions @DialogGamepad => new DialogGamepadActions(this);

        // Dialog-Keyboard
        private readonly InputActionMap m_DialogKeyboard;
        private List<IDialogKeyboardActions> m_DialogKeyboardActionsCallbackInterfaces = new List<IDialogKeyboardActions>();
        private readonly InputAction m_DialogKeyboard_Ok;
        public struct DialogKeyboardActions
        {
            private @Controls m_Wrapper;
            public DialogKeyboardActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Ok => m_Wrapper.m_DialogKeyboard_Ok;
            public InputActionMap Get() { return m_Wrapper.m_DialogKeyboard; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DialogKeyboardActions set) { return set.Get(); }
            public void AddCallbacks(IDialogKeyboardActions instance)
            {
                if (instance == null || m_Wrapper.m_DialogKeyboardActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_DialogKeyboardActionsCallbackInterfaces.Add(instance);
                @Ok.started += instance.OnOk;
                @Ok.performed += instance.OnOk;
                @Ok.canceled += instance.OnOk;
            }

            private void UnregisterCallbacks(IDialogKeyboardActions instance)
            {
                @Ok.started -= instance.OnOk;
                @Ok.performed -= instance.OnOk;
                @Ok.canceled -= instance.OnOk;
            }

            public void RemoveCallbacks(IDialogKeyboardActions instance)
            {
                if (m_Wrapper.m_DialogKeyboardActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IDialogKeyboardActions instance)
            {
                foreach (var item in m_Wrapper.m_DialogKeyboardActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_DialogKeyboardActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public DialogKeyboardActions @DialogKeyboard => new DialogKeyboardActions(this);
        private int m_NewcontrolschemeSchemeIndex = -1;
        public InputControlScheme NewcontrolschemeScheme
        {
            get
            {
                if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
                return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
            }
        }
        public interface IShipKeyboardMouseActions
        {
            void OnZMovement(InputAction.CallbackContext context);
            void OnXMovement(InputAction.CallbackContext context);
            void OnVerticalMovement(InputAction.CallbackContext context);
        }
        public interface IShipGamepadActions
        {
            void OnHorizontalGamepadMovement(InputAction.CallbackContext context);
            void OnVerticalGamepadMovement(InputAction.CallbackContext context);
            void OnStatusClick(InputAction.CallbackContext context);
        }
        public interface IDialogGamepadActions
        {
            void OnOk(InputAction.CallbackContext context);
            void OnStatusClick(InputAction.CallbackContext context);
        }
        public interface IDialogKeyboardActions
        {
            void OnOk(InputAction.CallbackContext context);
        }
    }
}
