// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""RTS Camera"",
            ""id"": ""de03799a-0fce-4fcb-9966-5bb518761460"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""366d55a2-2cf5-4780-8a3d-c64d642e9c8c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""09ccd194-45fa-4664-8d1a-a07c57f24712"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WSAD"",
                    ""id"": ""2f32de24-46b5-47ff-b272-7cf7652cdc67"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c90f7161-31a0-4b4e-bd55-eb655a936811"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2c417703-eb2b-45fa-a956-e4be147ec345"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""44a1162b-f5e3-44f4-9489-e10af0cc674a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fe9a9c1a-6d42-49c6-bc43-d1f34115b59d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""QE"",
                    ""id"": ""3de27303-187a-4a00-a706-40072606632f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8f60aa31-03be-44ea-8b7a-23708d7f966a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""321f7e8c-2b64-4e3b-919e-6efd41899ef3"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // RTS Camera
        m_RTSCamera = asset.FindActionMap("RTS Camera", throwIfNotFound: true);
        m_RTSCamera_Movement = m_RTSCamera.FindAction("Movement", throwIfNotFound: true);
        m_RTSCamera_Rotation = m_RTSCamera.FindAction("Rotation", throwIfNotFound: true);
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

    // RTS Camera
    private readonly InputActionMap m_RTSCamera;
    private IRTSCameraActions m_RTSCameraActionsCallbackInterface;
    private readonly InputAction m_RTSCamera_Movement;
    private readonly InputAction m_RTSCamera_Rotation;
    public struct RTSCameraActions
    {
        private @Controls m_Wrapper;
        public RTSCameraActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_RTSCamera_Movement;
        public InputAction @Rotation => m_Wrapper.m_RTSCamera_Rotation;
        public InputActionMap Get() { return m_Wrapper.m_RTSCamera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RTSCameraActions set) { return set.Get(); }
        public void SetCallbacks(IRTSCameraActions instance)
        {
            if (m_Wrapper.m_RTSCameraActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_RTSCameraActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_RTSCameraActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_RTSCameraActionsCallbackInterface.OnMovement;
                @Rotation.started -= m_Wrapper.m_RTSCameraActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_RTSCameraActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_RTSCameraActionsCallbackInterface.OnRotation;
            }
            m_Wrapper.m_RTSCameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
            }
        }
    }
    public RTSCameraActions @RTSCamera => new RTSCameraActions(this);
    public interface IRTSCameraActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
    }
}
