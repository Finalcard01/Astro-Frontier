using Unity.Collections;
using UnityEngine;

public class SmoothCamera2 : MonoBehaviour
{
    public Transform target;   // the object to follow
public Vector3 offset;     // how far away it should stay
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
    {
            transform.position = new Vector3(
                target.position.x + offset.x,
                target.position.y + offset.y,
                transform.position.z
            );
    }
    }
}
