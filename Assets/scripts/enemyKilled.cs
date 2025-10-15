using UnityEngine;
public class enemyKilled : MonoBehaviour
{
    public EnemySpawner enemyCounter;
    public Player player;
    void Start()
    {
        enemyCounter = Object.FindFirstObjectByType<EnemySpawner>();
        player = Object.FindFirstObjectByType<Player>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            enemyCounter.count = enemyCounter.count - 0.5f;
            player.Score = player.Score + 0.5f;
            Destroy(other.gameObject); // destroy enemy
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            enemyCounter.count = enemyCounter.count - 1f;
            Destroy(gameObject);
            player.TakeDamage(20);
        }
    }
}
