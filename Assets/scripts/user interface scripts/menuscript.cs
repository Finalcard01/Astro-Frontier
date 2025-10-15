using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine.InputSystem.Controls;
using JetBrains.Annotations;

public class menuscript : MonoBehaviour
{
    private Button MENU;
    public EnemySpawner enemies;
    public GameObject GAMEOVERUI;
    public EnemySpawner EntitySpawner;
    public CameraMovement CamMove;
    public GameObject enemy;
    void Start()
    {
        MENU = GameObject.Find("menubtn").GetComponent<Button>();
        MENU.onClick.AddListener(ButtonClick);
        EntitySpawner = GameObject.Find("EntitySpawner").GetComponent<EnemySpawner>();
        GAMEOVERUI = GameObject.Find("GAMEOVERUI(Clone)");
        CamMove = GameObject.Find("Tracker").GetComponent<CameraMovement>();
    }
    // Update is called once per frame
    void ButtonClick()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        Destroy(GAMEOVERUI);
        EntitySpawner.SpawnMenu();
        CamMove.GameOver = false;
        CamMove.menu = true;
        
    }
}
