//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Config/GameActions.inputactions
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

namespace Test_Pendulum
{
    public partial class @GameActions: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameActions"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""fe7841de-4e03-453f-85c1-883f809fc452"",
            ""actions"": [
                {
                    ""name"": ""ReleaseBall"",
                    ""type"": ""Button"",
                    ""id"": ""810a8d3e-e3d4-491b-a251-d405b0e7c54b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1d8b7198-7a40-4a89-bf95-36618d54ea9e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReleaseBall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8d097a0-dd50-4ae4-b4f4-690b596c6fbe"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReleaseBall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5b119a0-eb0a-498b-aec3-b8e8458e9b4e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReleaseBall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // GamePlay
            m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
            m_GamePlay_ReleaseBall = m_GamePlay.FindAction("ReleaseBall", throwIfNotFound: true);
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

        // GamePlay
        private readonly InputActionMap m_GamePlay;
        private List<IGamePlayActions> m_GamePlayActionsCallbackInterfaces = new List<IGamePlayActions>();
        private readonly InputAction m_GamePlay_ReleaseBall;
        public struct GamePlayActions
        {
            private @GameActions m_Wrapper;
            public GamePlayActions(@GameActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @ReleaseBall => m_Wrapper.m_GamePlay_ReleaseBall;
            public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
            public void AddCallbacks(IGamePlayActions instance)
            {
                if (instance == null || m_Wrapper.m_GamePlayActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_GamePlayActionsCallbackInterfaces.Add(instance);
                @ReleaseBall.started += instance.OnReleaseBall;
                @ReleaseBall.performed += instance.OnReleaseBall;
                @ReleaseBall.canceled += instance.OnReleaseBall;
            }

            private void UnregisterCallbacks(IGamePlayActions instance)
            {
                @ReleaseBall.started -= instance.OnReleaseBall;
                @ReleaseBall.performed -= instance.OnReleaseBall;
                @ReleaseBall.canceled -= instance.OnReleaseBall;
            }

            public void RemoveCallbacks(IGamePlayActions instance)
            {
                if (m_Wrapper.m_GamePlayActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IGamePlayActions instance)
            {
                foreach (var item in m_Wrapper.m_GamePlayActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_GamePlayActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public GamePlayActions @GamePlay => new GamePlayActions(this);
        public interface IGamePlayActions
        {
            void OnReleaseBall(InputAction.CallbackContext context);
        }
    }
}
