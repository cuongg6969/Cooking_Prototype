using UnityEngine;
using UnityEngine.InputSystem;

public class InputRouter : MonoBehaviour
{
    public static InputRouter Instance;

    public GameInput CurrentInput {  get; private set; }

    private PlayerControls controls;
    private Vector2 move;
    private bool interact;
    private bool attack;
    private bool pause;

    private void Awake()
    {
        Instance = this;    
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Enable();

        controls.Player.Move.performed += OnMove;
        controls.Player.Move.canceled += OnMove;

        controls.Player.Attack.performed += OnAttack;
        controls.Player.Attack.canceled += OnAttack;

        controls.Player.Interact.performed += OnInteract;
        controls.Player.Interact.canceled += OnInteract;

        controls.Player.Pause.performed += OnPause;
        controls.Player.Pause.canceled += OnPause;
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        CurrentInput = new GameInput
        {
            Move = move,
            Pause = pause,
            Attack = attack,
            Interact = interact
        };
    }

    private void OnMove(InputAction.CallbackContext ctx) => move = ctx.ReadValue<Vector2>();
    private void OnAttack(InputAction.CallbackContext ctx) => attack = ctx.ReadValueAsButton();
    private void OnInteract(InputAction.CallbackContext ctx) => interact = ctx.ReadValueAsButton();
    private void OnPause(InputAction.CallbackContext ctx) => pause = ctx.ReadValueAsButton();
}
