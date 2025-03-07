// GENERATED AUTOMATICALLY FROM 'Assets/InputActions/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""RegularGame"",
            ""id"": ""07c09d52-0427-4758-865a-24188421d785"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""0c06b6a9-a2e3-43e5-9639-f82a6dc85b2d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""68f4d6ee-4f6d-48b4-9a22-9ac9fd5587f7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootHold"",
                    ""type"": ""Button"",
                    ""id"": ""52e36476-1716-472b-9ae6-315884b5a861"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.21)""
                },
                {
                    ""name"": ""ShootTap"",
                    ""type"": ""Button"",
                    ""id"": ""e3918449-7e44-4b8a-9b78-e6573da2cbcc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e0eb22bd-4371-4c49-a986-2d917ce93819"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""8b0bc2b4-8ab4-4e42-afe9-022202890c5d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""a2045aec-ccbf-4776-a460-69c3ae687d2f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""a656d907-2674-4095-8f71-fa9d71b40cbd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""6bf6e3e3-e6c9-45b1-8be2-dbfe8ae8f934"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c57956d3-a125-408a-863b-02cc49f7e10f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""10534194-55f5-4d21-bf1a-63df1d722a72"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d11d36e6-efe3-4249-a079-5d61ee2ad93f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d08662cf-15b9-4590-8dca-bc79ac9c8275"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ecb5da0a-a950-48b4-a9d9-0fa4a80d44b2"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14a5b950-d877-4bb4-8150-f841e2b000d3"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44f0bd5d-12de-4ec0-8ecf-6a84441033bd"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53740148-8efe-41b0-bc38-e7597ef8cad1"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb6e5668-decd-47bd-ab03-809bcb6c17fa"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e86b5730-a5a6-4542-b87c-47728a890acb"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootTap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7dcaa83f-577e-4ae7-a02d-4c281348b7d1"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PlayerControl"",
            ""bindingGroup"": ""PlayerControl"",
            ""devices"": []
        }
    ]
}");
        // RegularGame
        m_RegularGame = asset.FindActionMap("RegularGame", throwIfNotFound: true);
        m_RegularGame_Move = m_RegularGame.FindAction("Move", throwIfNotFound: true);
        m_RegularGame_Look = m_RegularGame.FindAction("Look", throwIfNotFound: true);
        m_RegularGame_ShootHold = m_RegularGame.FindAction("ShootHold", throwIfNotFound: true);
        m_RegularGame_ShootTap = m_RegularGame.FindAction("ShootTap", throwIfNotFound: true);
        m_RegularGame_Jump = m_RegularGame.FindAction("Jump", throwIfNotFound: true);
        m_RegularGame_Aim = m_RegularGame.FindAction("Aim", throwIfNotFound: true);
        m_RegularGame_Sprint = m_RegularGame.FindAction("Sprint", throwIfNotFound: true);
        m_RegularGame_Reload = m_RegularGame.FindAction("Reload", throwIfNotFound: true);
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

    // RegularGame
    private readonly InputActionMap m_RegularGame;
    private IRegularGameActions m_RegularGameActionsCallbackInterface;
    private readonly InputAction m_RegularGame_Move;
    private readonly InputAction m_RegularGame_Look;
    private readonly InputAction m_RegularGame_ShootHold;
    private readonly InputAction m_RegularGame_ShootTap;
    private readonly InputAction m_RegularGame_Jump;
    private readonly InputAction m_RegularGame_Aim;
    private readonly InputAction m_RegularGame_Sprint;
    private readonly InputAction m_RegularGame_Reload;
    public struct RegularGameActions
    {
        private @PlayerControls m_Wrapper;
        public RegularGameActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_RegularGame_Move;
        public InputAction @Look => m_Wrapper.m_RegularGame_Look;
        public InputAction @ShootHold => m_Wrapper.m_RegularGame_ShootHold;
        public InputAction @ShootTap => m_Wrapper.m_RegularGame_ShootTap;
        public InputAction @Jump => m_Wrapper.m_RegularGame_Jump;
        public InputAction @Aim => m_Wrapper.m_RegularGame_Aim;
        public InputAction @Sprint => m_Wrapper.m_RegularGame_Sprint;
        public InputAction @Reload => m_Wrapper.m_RegularGame_Reload;
        public InputActionMap Get() { return m_Wrapper.m_RegularGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RegularGameActions set) { return set.Get(); }
        public void SetCallbacks(IRegularGameActions instance)
        {
            if (m_Wrapper.m_RegularGameActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnLook;
                @ShootHold.started -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnShootHold;
                @ShootHold.performed -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnShootHold;
                @ShootHold.canceled -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnShootHold;
                @ShootTap.started -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnShootTap;
                @ShootTap.performed -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnShootTap;
                @ShootTap.canceled -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnShootTap;
                @Jump.started -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnJump;
                @Aim.started -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnAim;
                @Sprint.started -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnSprint;
                @Reload.started -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_RegularGameActionsCallbackInterface.OnReload;
            }
            m_Wrapper.m_RegularGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @ShootHold.started += instance.OnShootHold;
                @ShootHold.performed += instance.OnShootHold;
                @ShootHold.canceled += instance.OnShootHold;
                @ShootTap.started += instance.OnShootTap;
                @ShootTap.performed += instance.OnShootTap;
                @ShootTap.canceled += instance.OnShootTap;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
            }
        }
    }
    public RegularGameActions @RegularGame => new RegularGameActions(this);
    private int m_PlayerControlSchemeIndex = -1;
    public InputControlScheme PlayerControlScheme
    {
        get
        {
            if (m_PlayerControlSchemeIndex == -1) m_PlayerControlSchemeIndex = asset.FindControlSchemeIndex("PlayerControl");
            return asset.controlSchemes[m_PlayerControlSchemeIndex];
        }
    }
    public interface IRegularGameActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnShootHold(InputAction.CallbackContext context);
        void OnShootTap(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
    }
}
