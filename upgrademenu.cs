using UnityEngine;
using UnityEngine.UI;

public class upgrademenu : MonoBehaviour
{
    public Button op1;
    public Button op2;
    public Button op3;
    public Canvas upgrademenuob;
    public EnemySpawner entityspawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        op1.onClick.AddListener(OnButtonClick);
        op3.onClick.AddListener(OnButtonClick);
        op2.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void OnButtonClick()
    {
        upgrademenuob.gameObject.SetActive(false);
        entityspawner.Pickstat();
        entityspawner.NextWave();
    }
}
