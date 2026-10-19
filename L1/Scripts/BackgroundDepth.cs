using UnityEngine;

public class BackgroundDepth : MonoBehaviour
{
    public float moveSpeed = 2f;
    public KeyCode swimKey = KeyCode.Space;

    void Update()
    {
        if (Input.GetKey(swimKey)) 
        {
            transform.Translate(
                Vector3.down * moveSpeed * Time.deltaTime
            ); 
        }
    }
}
