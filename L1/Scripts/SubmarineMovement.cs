
using UnityEngine;

public class SubmarineMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public SpriteRenderer background;
    public float padding = 0.3f;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(x, y, 0f);

        if (movement.magnitude > 1f)
            movement.Normalize();

        transform.position += movement * moveSpeed * Time.deltaTime;

        if (background != null)
        {
            Bounds b = background.bounds;
            Vector3 pos = transform.position;

            pos.x = Mathf.Clamp(
                pos.x, b.min.x + padding, b.max.x - padding
            );

            pos.y = Mathf.Clamp(
                pos.y, b.min.y + padding, b.max.y - padding
            );

            transform.position = pos;
        }
    }
}
