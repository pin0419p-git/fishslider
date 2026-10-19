
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public SpriteRenderer background;
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null || background == null)
            return;

        Bounds b = background.bounds;
        Camera cam = GetComponent<Camera>();

        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        Vector3 desired = target.position;

        // จำกัดกล้องให้อยู่ภายใน Background
        desired.x = Mathf.Clamp(
            desired.x,
            b.min.x + halfWidth,
            b.max.x - halfWidth
        );

        desired.y = Mathf.Clamp(
            desired.y,
            b.min.y + halfHeight,
            b.max.y - halfHeight
        );

        desired.z = transform.position.z;

        transform.position = Vector3.Lerp(
            transform.position,
            desired,
            smoothSpeed * Time.deltaTime
        );
    }
}
