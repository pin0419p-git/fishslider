
using UnityEngine;

public class StayInBackground : MonoBehaviour
{
    public SpriteRenderer background;
    public float padding = 0.3f;

    void LateUpdate()
    {
        if (background == null) return;

        Bounds bounds = background.bounds;

        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(
            pos.x,
            bounds.min.x + padding,
            bounds.max.x - padding
        );

        pos.y = Mathf.Clamp(
            pos.y,
            bounds.min.y + padding,
            bounds.max.y - padding
        );

        transform.position = pos;
    }
}

