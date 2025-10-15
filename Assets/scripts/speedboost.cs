using System.Threading;
using UnityEngine;

public class speedboost : MonoBehaviour
{
    public movement movementScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
         if (other.CompareTag("Player"))
        {
        movementScript.movespeed = 10f;
        movementScript.timerStarted = false;
        Destroy(gameObject);
        }
    }
}
