using System;
using System.Numerics;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool timerStarted = false;
    public float movespeed = 5f;
    public float timer = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        follow_mouse();
        if (movespeed == 10f)
        {
            if (!timerStarted)
            {
                timer = 10f;
                timerStarted = true;
            }
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                movespeed = 5f;
                timer = 0f;
                timerStarted = false;
            }
        }
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        UnityEngine.Vector2 input = new UnityEngine.Vector2(moveX, moveY);
        input = UnityEngine.Vector2.ClampMagnitude(input, 1f);
        // new UnityEngine.Vector2(moveX, moveY)  
        rb.linearVelocity = input * movespeed;
    }
    void follow_mouse()
    {
        UnityEngine.Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        UnityEngine.Vector3 direction = mousePos - transform.position;
        direction.z = 0;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(0, 0, angle - 90f));
        rb.angularVelocity = 0f;
    }
}
