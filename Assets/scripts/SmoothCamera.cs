using UnityEngine;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using System.Collections;

public class SmoothCamera : MonoBehaviour
{
    [SerializeField]private UnityEngine.Vector3 offset = new UnityEngine.Vector3(0f, 0f, 0f);
    [SerializeField]private float smoothTime = 0.01f;
    private UnityEngine.Vector3 velocity = UnityEngine.Vector3.zero;

    [SerializeField] private Transform target;
    

void LateUpdate()
    {
            if (!target) return;
            UnityEngine.Vector3 targetPosition = target.position + offset;
            targetPosition.z = transform.position.z;
            transform.position = UnityEngine.Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            velocity.z = 0f;

    }
    
}
