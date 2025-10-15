using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine.InputSystem.Controls;
using JetBrains.Annotations;
public class playscript : MonoBehaviour
{
    private Button play;
    public GameObject MENUPrefab;
    public EnemySpawner spawn;
    public GameObject MENU;
    public CameraMovement CamMove;
    void Start()
    {
        play = GameObject.Find("playbtn").GetComponent<Button>();
        spawn = GameObject.Find("EntitySpawner").GetComponent<EnemySpawner>();
        play.onClick.AddListener(ButtonClick);
        CamMove = GameObject.Find("Tracker").GetComponent<CameraMovement>();
    }
    void ButtonClick()
    {
        Destroy(gameObject);
        spawn.SpawnPlayer();
        CamMove.menu = false;
    }
}
