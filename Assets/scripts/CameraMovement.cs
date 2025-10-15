using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private GameObject player1;
    public Transform target;
    public movement movescript;
    public stopcamera stopcameraScript;
    public bool menu = true;
    public bool GameOver = false;
    bool outside = false;
    private UnityEngine.Vector2 velocityRef = UnityEngine.Vector2.zero;
    public float smoothTime = 0.3f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void LateUpdate()
    {
        if (target != null)
        {
            if (outside)
            {
                float speed = movescript.movespeed * 1.1f;
                UnityEngine.Vector3 direction = (target.position - transform.position).normalized;
                rb.linearVelocity = UnityEngine.Vector2.SmoothDamp(rb.linearVelocity, direction * speed, ref velocityRef, smoothTime);
            }
            if ((outside == false) && (stopcameraScript.centred == false))
            {
                float speed = movescript.movespeed * 0.5f;
                UnityEngine.Vector3 direction = (target.position - transform.position).normalized;
                rb.linearVelocity = UnityEngine.Vector2.SmoothDamp(rb.linearVelocity, direction * speed, ref velocityRef, smoothTime);
            }
        }
        if (GameOver == false && menu == false)
        {
            FindPlayer();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && target != null)
        {
            outside = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && target != null)
        {
            outside = false;
        }
    }
    public void FindPlayer()
    {
        player1 = GameObject.FindWithTag("Player");
        target = player1.transform;
        movescript = player1.GetComponent<movement>();
    }
}
