using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void FixedUpdate() 
    {
        if (target == null) return;
        transform.position = target.position + offset;
    }
}