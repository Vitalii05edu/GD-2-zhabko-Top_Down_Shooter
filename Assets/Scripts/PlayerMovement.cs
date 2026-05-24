using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D _rigidbody;
    private Vector2 playerDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        float directionX = Input.GetAxisRaw("Horizontal");
        playerDirection = new Vector2(directionX, directionY).normalized;
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
    }
}
