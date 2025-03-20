using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;
    public Vector2 MoveInput { get; private set; }
    public bool Sprint { get; private set; }
    public bool SprintHeld { get; private set; }
    public bool SprintReleased { get; private set; }
    public bool Shoot { get; private set; }
    public bool ShootHeld { get; private set; }
    public bool ShootReleased { get; private set; }
    public bool Pause { get; private set; }

    public bool ToggleShop { get; private set; }

    private PlayerInput _playerInput;

    private InputAction _moveAction;
    private InputAction _sprintAction;
    private InputAction _shootAction;
    private InputAction _pauseAction;
    private InputAction _toggleShopAction;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _playerInput = GetComponent<PlayerInput>();

        SetupInputActions();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateInputs();
    }

    private void SetupInputActions()
    {
        _moveAction = _playerInput.actions["Move"];
        _sprintAction = _playerInput.actions["Sprint"];
        _shootAction = _playerInput.actions["Shoot"];
        _pauseAction = _playerInput.actions["Pause"];
        _toggleShopAction = _playerInput.actions["ToggleShop"];
    }

    private void UpdateInputs()
    {
        MoveInput = _moveAction.ReadValue<Vector2>();
        Sprint = _sprintAction.WasPressedThisFrame();
        SprintHeld = _sprintAction.IsPressed();
        SprintReleased = _sprintAction.WasReleasedThisFrame();
        Shoot = _shootAction.WasPressedThisFrame();
        ShootHeld = _shootAction.IsPressed();
        ShootReleased = _shootAction.WasReleasedThisFrame();
        Pause = _pauseAction.WasPressedThisFrame();
        ToggleShop = _toggleShopAction.WasPressedThisFrame();
    }

    public void inGameActionMapEnable()
    {
        _playerInput.SwitchCurrentActionMap("inGame");
    }
}
