//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/Input/CustomInput.inputactions
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

public partial class @CustomInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CustomInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CustomInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""ee546296-c5e9-4706-958d-6b88357f083b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""edc94fa6-27fd-4f3a-a8c3-2eb2d14578c8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Break"",
                    ""type"": ""Button"",
                    ""id"": ""b4f3690b-1f9f-4f65-8a66-7258ed1d622d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""c672d338-b1a8-4633-a859-e7eaeac22bd9"",
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
                    ""id"": ""737c5839-1874-43a0-9481-996131a4cc08"",
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
                    ""id"": ""9fc7953f-cb0e-4cc8-a881-46bd66f1841f"",
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
                    ""id"": ""fb4d33fc-dc52-4d77-bcb0-e530ff47f973"",
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
                    ""id"": ""45eb6831-b153-4640-bace-8fe8d1eb210a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""dd396ce0-deea-4c8d-9f84-568f2858e48c"",
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
                    ""id"": ""2ea1fd27-770b-482d-b0ea-ee18281d7276"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""11dbc8b5-72c8-4159-a7eb-4bca661b91e8"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0f429afa-4dec-417b-ad8e-9bb493c5a288"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cc773388-c494-4f8f-a23d-309b424e775a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1a0697df-1e6c-470d-895a-52da0a3d2449"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Break"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Playtest"",
            ""id"": ""9048f614-1f01-4fc7-8a19-e829e75269a5"",
            ""actions"": [
                {
                    ""name"": ""AddItem1"",
                    ""type"": ""Button"",
                    ""id"": ""3f1551a0-0f1b-4d94-9d9f-fff3f8a2f089"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AddItem2"",
                    ""type"": ""Button"",
                    ""id"": ""f5b052b6-10cb-499e-a3e7-884b375221f6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a9de0aef-a832-4ebe-a3ea-321279eeb90a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AddItem1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8333793e-ac7c-437e-b60b-ba87cbd418c6"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AddItem2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Break = m_Player.FindAction("Break", throwIfNotFound: true);
        // Playtest
        m_Playtest = asset.FindActionMap("Playtest", throwIfNotFound: true);
        m_Playtest_AddItem1 = m_Playtest.FindAction("AddItem1", throwIfNotFound: true);
        m_Playtest_AddItem2 = m_Playtest.FindAction("AddItem2", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Break;
    public struct PlayerActions
    {
        private @CustomInput m_Wrapper;
        public PlayerActions(@CustomInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Break => m_Wrapper.m_Player_Break;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Break.started += instance.OnBreak;
            @Break.performed += instance.OnBreak;
            @Break.canceled += instance.OnBreak;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Break.started -= instance.OnBreak;
            @Break.performed -= instance.OnBreak;
            @Break.canceled -= instance.OnBreak;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Playtest
    private readonly InputActionMap m_Playtest;
    private List<IPlaytestActions> m_PlaytestActionsCallbackInterfaces = new List<IPlaytestActions>();
    private readonly InputAction m_Playtest_AddItem1;
    private readonly InputAction m_Playtest_AddItem2;
    public struct PlaytestActions
    {
        private @CustomInput m_Wrapper;
        public PlaytestActions(@CustomInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @AddItem1 => m_Wrapper.m_Playtest_AddItem1;
        public InputAction @AddItem2 => m_Wrapper.m_Playtest_AddItem2;
        public InputActionMap Get() { return m_Wrapper.m_Playtest; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlaytestActions set) { return set.Get(); }
        public void AddCallbacks(IPlaytestActions instance)
        {
            if (instance == null || m_Wrapper.m_PlaytestActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlaytestActionsCallbackInterfaces.Add(instance);
            @AddItem1.started += instance.OnAddItem1;
            @AddItem1.performed += instance.OnAddItem1;
            @AddItem1.canceled += instance.OnAddItem1;
            @AddItem2.started += instance.OnAddItem2;
            @AddItem2.performed += instance.OnAddItem2;
            @AddItem2.canceled += instance.OnAddItem2;
        }

        private void UnregisterCallbacks(IPlaytestActions instance)
        {
            @AddItem1.started -= instance.OnAddItem1;
            @AddItem1.performed -= instance.OnAddItem1;
            @AddItem1.canceled -= instance.OnAddItem1;
            @AddItem2.started -= instance.OnAddItem2;
            @AddItem2.performed -= instance.OnAddItem2;
            @AddItem2.canceled -= instance.OnAddItem2;
        }

        public void RemoveCallbacks(IPlaytestActions instance)
        {
            if (m_Wrapper.m_PlaytestActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlaytestActions instance)
        {
            foreach (var item in m_Wrapper.m_PlaytestActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlaytestActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlaytestActions @Playtest => new PlaytestActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnBreak(InputAction.CallbackContext context);
    }
    public interface IPlaytestActions
    {
        void OnAddItem1(InputAction.CallbackContext context);
        void OnAddItem2(InputAction.CallbackContext context);
    }
}
