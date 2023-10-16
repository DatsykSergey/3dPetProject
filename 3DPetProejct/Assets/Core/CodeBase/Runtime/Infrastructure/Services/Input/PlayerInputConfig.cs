//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Settings/PlayerInputConfig.inputactions
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

public partial class @PlayerActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputConfig"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""5880a940-11d3-47bb-a09a-dcc4985ed65d"",
            ""actions"": [
                {
                    ""name"": ""MoveDirection"",
                    ""type"": ""Value"",
                    ""id"": ""6446b641-41a9-4c4c-85f3-ba463ab983d9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LookDelta"",
                    ""type"": ""Value"",
                    ""id"": ""38ac72e6-92e2-492a-8694-f5fbbc5643ed"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bcc181a8-309b-4e73-971d-dba5b4a59fb8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StopGame"",
                    ""type"": ""Button"",
                    ""id"": ""a0864532-ae6e-49cd-9524-44451565512d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""JumpDown"",
                    ""type"": ""Button"",
                    ""id"": ""a336ccd0-94c8-48f3-a393-a4a55c9b87cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StopMouseRotation"",
                    ""type"": ""Button"",
                    ""id"": ""01c5a946-94ed-4ae7-a106-0ed803c878cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""68c9755f-ce78-4d2f-ac37-00076a7913f0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7f7fb040-21fc-4854-99e8-2851302e403d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b7af9071-db20-4c0d-88a1-c82d82fdfa2f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""33ba72e4-0122-4eb0-aba4-e13185f06165"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""76bff3e7-d274-45c5-9562-5a02023a13ce"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5b9174dc-fc83-40f5-b887-3b87b2b9be26"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d168f4a-7b31-4a6b-b655-167841de0f34"",
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
                    ""id"": ""cb4a55c5-51d4-4b5a-af73-1fc46762e8c4"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa3e2b8d-3856-49cc-861c-489c97d1e20f"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2cd1ab09-6c26-4e80-803c-a9079d954763"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopMouseRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_MoveDirection = m_Gameplay.FindAction("MoveDirection", throwIfNotFound: true);
        m_Gameplay_LookDelta = m_Gameplay.FindAction("LookDelta", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_StopGame = m_Gameplay.FindAction("StopGame", throwIfNotFound: true);
        m_Gameplay_JumpDown = m_Gameplay.FindAction("JumpDown", throwIfNotFound: true);
        m_Gameplay_StopMouseRotation = m_Gameplay.FindAction("StopMouseRotation", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_Gameplay_MoveDirection;
    private readonly InputAction m_Gameplay_LookDelta;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_StopGame;
    private readonly InputAction m_Gameplay_JumpDown;
    private readonly InputAction m_Gameplay_StopMouseRotation;
    public struct GameplayActions
    {
        private @PlayerActions m_Wrapper;
        public GameplayActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveDirection => m_Wrapper.m_Gameplay_MoveDirection;
        public InputAction @LookDelta => m_Wrapper.m_Gameplay_LookDelta;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @StopGame => m_Wrapper.m_Gameplay_StopGame;
        public InputAction @JumpDown => m_Wrapper.m_Gameplay_JumpDown;
        public InputAction @StopMouseRotation => m_Wrapper.m_Gameplay_StopMouseRotation;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @MoveDirection.started += instance.OnMoveDirection;
            @MoveDirection.performed += instance.OnMoveDirection;
            @MoveDirection.canceled += instance.OnMoveDirection;
            @LookDelta.started += instance.OnLookDelta;
            @LookDelta.performed += instance.OnLookDelta;
            @LookDelta.canceled += instance.OnLookDelta;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @StopGame.started += instance.OnStopGame;
            @StopGame.performed += instance.OnStopGame;
            @StopGame.canceled += instance.OnStopGame;
            @JumpDown.started += instance.OnJumpDown;
            @JumpDown.performed += instance.OnJumpDown;
            @JumpDown.canceled += instance.OnJumpDown;
            @StopMouseRotation.started += instance.OnStopMouseRotation;
            @StopMouseRotation.performed += instance.OnStopMouseRotation;
            @StopMouseRotation.canceled += instance.OnStopMouseRotation;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @MoveDirection.started -= instance.OnMoveDirection;
            @MoveDirection.performed -= instance.OnMoveDirection;
            @MoveDirection.canceled -= instance.OnMoveDirection;
            @LookDelta.started -= instance.OnLookDelta;
            @LookDelta.performed -= instance.OnLookDelta;
            @LookDelta.canceled -= instance.OnLookDelta;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @StopGame.started -= instance.OnStopGame;
            @StopGame.performed -= instance.OnStopGame;
            @StopGame.canceled -= instance.OnStopGame;
            @JumpDown.started -= instance.OnJumpDown;
            @JumpDown.performed -= instance.OnJumpDown;
            @JumpDown.canceled -= instance.OnJumpDown;
            @StopMouseRotation.started -= instance.OnStopMouseRotation;
            @StopMouseRotation.performed -= instance.OnStopMouseRotation;
            @StopMouseRotation.canceled -= instance.OnStopMouseRotation;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMoveDirection(InputAction.CallbackContext context);
        void OnLookDelta(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnStopGame(InputAction.CallbackContext context);
        void OnJumpDown(InputAction.CallbackContext context);
        void OnStopMouseRotation(InputAction.CallbackContext context);
    }
}
