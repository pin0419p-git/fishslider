using UnityEngine;

public class SubmarineController : MonoBehaviour
{
    public float horizontalSpeed = 2f;
    public float verticalSpeed = 2f;

    private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;

    public bool canMove = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!canMove)
        {
            horizontalInput = 0f;
            verticalInput = 0f;
            return;
        }

        horizontalInput = 0f;
        verticalInput = 0f;

        if (Input.GetKey(KeyCode.A))
            horizontalInput = -1f;
        else if (Input.GetKey(KeyCode.D))
            horizontalInput = 1f;

        if (Input.GetKey(KeyCode.Space))
            verticalInput = 1f;
        else if (Input.GetKey(KeyCode.LeftControl))
            verticalInput = -1f;
    }

    void FixedUpdate()
    {
        if (rb == null) return;

        if (!canMove)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity = new Vector2(
            horizontalInput * horizontalSpeed,
            verticalInput * verticalSpeed
        );
    }
}