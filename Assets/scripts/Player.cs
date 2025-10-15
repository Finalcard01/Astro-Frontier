using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
public class Player : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;
    public PlayerHP healthbar;
    public float Score = 0;
    public bool GAMEOVERUI = false;
    public TextMeshProUGUI textBox;
    public GameObject GAMEOVER;
    public UnityEngine.Transform VectorPos;
    public CameraMovement CamMove;
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        textBox.text = "0";
    }
    void Update()
    {
        textBox.text = Score.ToString();
        if ((currentHealth == 0) && (GAMEOVERUI == false))
        {
            GameOver();
            GAMEOVERUI = true;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        healthbar.SetHealth(currentHealth);
    }
    public void GameOver()
    {
        Instantiate(GAMEOVER, VectorPos);
        GameObject player = GameObject.FindWithTag("Player");
        Destroy(player);
        CamMove.GameOver = true;
    }
    public void Reset()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        Score = 0;
    }
}
