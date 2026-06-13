using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 move = InputRouter.Instance.CurrentInput.Move;
        rb.linearVelocity = move.normalized * moveSpeed;
    }
}
