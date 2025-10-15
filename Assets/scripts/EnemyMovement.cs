using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float movespeed = 5f;
    private float originalZ;
    void Start()
    {
        originalZ = transform.position.z;
    }
    void Update()
    {
        if (target != null)
            transform.position = Vector3.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, originalZ);
    }
}
