using UnityEngine;

public class stopcamera : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform target;
    public GameObject movement;
    public Transform movement2;
    public bool centred;
    void Start()
    {
        Rigidbody2D rb = movement.GetComponent<Rigidbody2D>();
    }
    void LateUpdate()
    {
        transform.position = movement2.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && target != null)
        {
            Rigidbody2D rb = movement.GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector2.zero;
            centred = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player") && target != null)
        {
            centred = false;
        }
    }
}
