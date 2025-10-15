using System.Data;
using UnityEngine;

public class Bulletdeletion : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
