using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : Entity
{
    [SerializeField]
    private float moveSpeed = 5f;

    [Header("Interaction")]
    [SerializeField] float interactRadius = 1.5f;
    [SerializeField] LayerMask interactPlayer;

    Rigidbody2D rb;
    Animator anim;
    Vector2 moveInput;
    bool facingRight = true;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    private void Update()
    {
        if (!CanMove())
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        moveInput = InputRouter.Instance.CurrentInput.Move;

        UpdateFlip();
        UpdateAnimator();
        HandleInteract();
    }

    private void FixedUpdate()
    {
        if (!CanMove()) return;
        rb.linearVelocity = moveInput.normalized * moveSpeed;
    }

    protected override void OnDamageTaken(int amount)
    {
        EventBus.Publish(new OnPlayerHpChanged
        {
            current = currentHp,
            max = maxHp
        });
    }

    protected override void Die()
    {
        Debug.Log("Game Over");
        EventBus.Publish(new OnPlayerDied());
        //Làm hiện Game Over scene ở đay.
    }

    bool CanMove()
    {
        var state = GameStateManager.Instance.CurrentState;
        return state == GameState.World || state == GameState.Combat;
    }

    void UpdateFlip()
    {
        if (moveInput.x == 0) return;

        bool shouldFaceRight = moveInput.x > 0;
        if (shouldFaceRight == facingRight) return;

        facingRight = shouldFaceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void UpdateAnimator()
    {
        // chưa làm tại chưa có asset nhân vật.
    }

    void HandleInteract()
    {
        if (!InputRouter.Instance.CurrentInput.Interact) return;

        Collider2D hit = Physics2D.OverlapCircle(
            transform.position, interactRadius, interactPlayer);

        if (hit == null) return;

        var interactable = hit.GetComponent<IInteractable>();
        interactable?.Interact(this);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }

}