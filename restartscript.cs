using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine.InputSystem.Controls;
using JetBrains.Annotations;

public class restartscript : MonoBehaviour
{
    public GameObject MENUPrefab;
    public EnemySpawner spawn;
    public GameObject MENU;
    public CameraMovement CamMove;
    public Player restart;
    private Button resetbtn;
    void Start()
    {
        resetbtn = GameObject.Find("resetbtn").GetComponent<Button>();
        resetbtn.onClick.AddListener(ButtonClick);
        spawn = GameObject.Find("EntitySpawner").GetComponent<EnemySpawner>();
        restart = GameObject.Find("EntitySpawner").GetComponent<Player>();
        CamMove = GameObject.Find("Tracker").GetComponent<CameraMovement>();
    }
    void ButtonClick()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        Destroy(gameObject);
        spawn.SpawnPlayer();
        CamMove.menu = false;
        CamMove.GameOver = false;
        restart.Reset();
        spawn.Reset();
    }
}
