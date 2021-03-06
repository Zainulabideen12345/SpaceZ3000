// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player Controls"",
            ""id"": ""217a6e40-2057-4aed-a984-99a53f994a6d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c2681f9a-b307-45c2-b652-fecfebd40d99"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5feea9fe-2a35-4396-99c5-27959529e746"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootMain"",
                    ""type"": ""Button"",
                    ""id"": ""e9133bd5-dda0-4d36-8c3f-7353e854c60c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""0784788b-e99a-445a-9834-199d88ccfd8d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseUltimate"",
                    ""type"": ""Button"",
                    ""id"": ""a13ede32-3135-4783-adec-653976b9ac72"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseHalo"",
                    ""type"": ""Button"",
                    ""id"": ""c96463a3-5393-46d5-8e87-1957cda0280d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseFlare"",
                    ""type"": ""Button"",
                    ""id"": ""217ef951-8b66-4b75-8262-06ea957f013d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchWeapon1"",
                    ""type"": ""Button"",
                    ""id"": ""6e006feb-c076-4301-93a1-649005c63a96"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchWeapon2"",
                    ""type"": ""Button"",
                    ""id"": ""98a83103-83be-47b8-a7e7-8bab652712ff"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseMines"",
                    ""type"": ""Button"",
                    ""id"": ""81b57cb4-868c-4f72-9542-d7d114018ec1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d8b9b946-53c4-49c5-9bc0-c301e294fdaa"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""5edc5e3d-8a4a-43e1-8cfa-58c56787a728"",
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
                    ""id"": ""c0885c22-3a29-4030-a4f3-e310be287406"",
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
                    ""id"": ""21e28745-0cfc-421a-8d36-cf9105b18ecf"",
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
                    ""id"": ""aea9ab48-ed07-4803-acc5-467201462cef"",
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
                    ""id"": ""9f5cf7d9-1092-4b8b-8177-7b54de2d9939"",
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
                    ""id"": ""c8b6fbb2-3de6-4f77-baf1-c774c9af4bc4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d62b7644-b5d7-4d70-9908-0c3c09a9e4f9"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f4d7009-a194-4de8-be01-5e8a6dd5e195"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46b16a5e-89d1-48c5-a3be-26dac5e43d01"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f628c24-704a-4251-a4c3-815b3ab0fefc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootMain"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b6fd8a8-e535-4164-9915-86edde3e2760"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootMain"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""353ab7b7-e79e-4793-b337-976e4c726577"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8b25ea8-b5e8-43eb-8940-9c6cbb690189"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""190b1c27-37f8-4b18-b3e6-67fed8e58ea2"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseUltimate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a86eb5f6-bb8f-4695-a4fe-62c33faa01bf"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseHalo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d00d773a-57bb-4f85-a8a0-1c142d2d6704"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseFlare"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14e711cd-a153-434f-9de4-a99de64564ce"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8bd937bd-126a-40e1-8a6d-603b38310746"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f180c6b8-2eff-43d6-838c-046cfb9579e3"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseMines"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Controls
        m_PlayerControls = asset.FindActionMap("Player Controls", throwIfNotFound: true);
        m_PlayerControls_Move = m_PlayerControls.FindAction("Move", throwIfNotFound: true);
        m_PlayerControls_Aim = m_PlayerControls.FindAction("Aim", throwIfNotFound: true);
        m_PlayerControls_ShootMain = m_PlayerControls.FindAction("ShootMain", throwIfNotFound: true);
        m_PlayerControls_Dash = m_PlayerControls.FindAction("Dash", throwIfNotFound: true);
        m_PlayerControls_UseUltimate = m_PlayerControls.FindAction("UseUltimate", throwIfNotFound: true);
        m_PlayerControls_UseHalo = m_PlayerControls.FindAction("UseHalo", throwIfNotFound: true);
        m_PlayerControls_UseFlare = m_PlayerControls.FindAction("UseFlare", throwIfNotFound: true);
        m_PlayerControls_SwitchWeapon1 = m_PlayerControls.FindAction("SwitchWeapon1", throwIfNotFound: true);
        m_PlayerControls_SwitchWeapon2 = m_PlayerControls.FindAction("SwitchWeapon2", throwIfNotFound: true);
        m_PlayerControls_UseMines = m_PlayerControls.FindAction("UseMines", throwIfNotFound: true);
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

    // Player Controls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Move;
    private readonly InputAction m_PlayerControls_Aim;
    private readonly InputAction m_PlayerControls_ShootMain;
    private readonly InputAction m_PlayerControls_Dash;
    private readonly InputAction m_PlayerControls_UseUltimate;
    private readonly InputAction m_PlayerControls_UseHalo;
    private readonly InputAction m_PlayerControls_UseFlare;
    private readonly InputAction m_PlayerControls_SwitchWeapon1;
    private readonly InputAction m_PlayerControls_SwitchWeapon2;
    private readonly InputAction m_PlayerControls_UseMines;
    public struct PlayerControlsActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerControls_Move;
        public InputAction @Aim => m_Wrapper.m_PlayerControls_Aim;
        public InputAction @ShootMain => m_Wrapper.m_PlayerControls_ShootMain;
        public InputAction @Dash => m_Wrapper.m_PlayerControls_Dash;
        public InputAction @UseUltimate => m_Wrapper.m_PlayerControls_UseUltimate;
        public InputAction @UseHalo => m_Wrapper.m_PlayerControls_UseHalo;
        public InputAction @UseFlare => m_Wrapper.m_PlayerControls_UseFlare;
        public InputAction @SwitchWeapon1 => m_Wrapper.m_PlayerControls_SwitchWeapon1;
        public InputAction @SwitchWeapon2 => m_Wrapper.m_PlayerControls_SwitchWeapon2;
        public InputAction @UseMines => m_Wrapper.m_PlayerControls_UseMines;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAim;
                @ShootMain.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShootMain;
                @ShootMain.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShootMain;
                @ShootMain.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShootMain;
                @Dash.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDash;
                @UseUltimate.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnUseUltimate;
                @UseUltimate.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnUseUltimate;
                @UseUltimate.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnUseUltimate;
                @UseHalo.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnUseHalo;
                @UseHalo.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnUseHalo;
                @UseHalo.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnUseHalo;
                @UseFlare.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnUseFlare;
                @UseFlare.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnUseFlare;
                @UseFlare.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnUseFlare;
                @SwitchWeapon1.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSwitchWeapon1;
                @SwitchWeapon1.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSwitchWeapon1;
                @SwitchWeapon1.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSwitchWeapon1;
                @SwitchWeapon2.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSwitchWeapon2;
                @SwitchWeapon2.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSwitchWeapon2;
                @SwitchWeapon2.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSwitchWeapon2;
                @UseMines.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnUseMines;
                @UseMines.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnUseMines;
                @UseMines.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnUseMines;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @ShootMain.started += instance.OnShootMain;
                @ShootMain.performed += instance.OnShootMain;
                @ShootMain.canceled += instance.OnShootMain;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @UseUltimate.started += instance.OnUseUltimate;
                @UseUltimate.performed += instance.OnUseUltimate;
                @UseUltimate.canceled += instance.OnUseUltimate;
                @UseHalo.started += instance.OnUseHalo;
                @UseHalo.performed += instance.OnUseHalo;
                @UseHalo.canceled += instance.OnUseHalo;
                @UseFlare.started += instance.OnUseFlare;
                @UseFlare.performed += instance.OnUseFlare;
                @UseFlare.canceled += instance.OnUseFlare;
                @SwitchWeapon1.started += instance.OnSwitchWeapon1;
                @SwitchWeapon1.performed += instance.OnSwitchWeapon1;
                @SwitchWeapon1.canceled += instance.OnSwitchWeapon1;
                @SwitchWeapon2.started += instance.OnSwitchWeapon2;
                @SwitchWeapon2.performed += instance.OnSwitchWeapon2;
                @SwitchWeapon2.canceled += instance.OnSwitchWeapon2;
                @UseMines.started += instance.OnUseMines;
                @UseMines.performed += instance.OnUseMines;
                @UseMines.canceled += instance.OnUseMines;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
    public interface IPlayerControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnShootMain(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnUseUltimate(InputAction.CallbackContext context);
        void OnUseHalo(InputAction.CallbackContext context);
        void OnUseFlare(InputAction.CallbackContext context);
        void OnSwitchWeapon1(InputAction.CallbackContext context);
        void OnSwitchWeapon2(InputAction.CallbackContext context);
        void OnUseMines(InputAction.CallbackContext context);
    }
}
