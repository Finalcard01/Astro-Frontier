using System;
using System.Globalization;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject Player;
    public Transform target;
    private Vector3 spawnPos;
    private int wave = 0;
    public float count = 0f;
    private bool nextwave = true;
    private bool statpicked = false;
    public GameObject MENUPrefab;
    public EnemySpawner spawn;
    public GameObject MENU;
    public GameObject Tracker;
    public GameObject Camera;
    public Canvas upgrademenu;
    void Start()
    {
        wave = 0;
        MENU = Instantiate(MENUPrefab, Vector3.zero, quaternion.identity);
    }
    void SpawnEnemy()
    {
        Vector3 spawnPos = GetSpawnPosAround(target, 30f, 50f);
        GameObject go = Instantiate(enemyPrefab, spawnPos, quaternion.identity);
        EnemyMovement enemy = go.GetComponent<EnemyMovement>();
        enemy.target = target;
    }
    public void SpawnPlayer()
    {
        GameObject player1 = Instantiate(Player, new Vector3(0, 0, 0), quaternion.identity);
        target = player1.transform;
    }
    public void SpawnMenu()
    {
        MENU = Instantiate(MENUPrefab, Vector3.zero, quaternion.identity);
        Tracker.transform.position = Vector3.zero;
        Rigidbody2D trb = Tracker.GetComponent<Rigidbody2D>();
        trb.linearVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0 && target != null && wave > 0 && statpicked == false)
        {
            upgrademenu.gameObject.SetActive(true);
        }
        if (target == null)
        {
            upgrademenu.gameObject.SetActive(false);
        }
        if (nextwave == true && target != null)
            {
                wave++;
                count = (int)Math.Round(0.3 * (Math.Pow(wave, 2)) + 10);
                Debug.Log("wave" + wave);
                int toSpawn = (int)Math.Round(0.3 * (Math.Pow(wave, 2)) + 10);
                for (int i = 0; i < toSpawn; i++)
                {
                    SpawnEnemy();
                }
                nextwave = false;
                statpicked = false;
            }
    }
    Vector3 GetSpawnPosAround(Transform player, float minDist, float maxDist)
    {
        Vector2 dir = UnityEngine.Random.insideUnitCircle.normalized;
        float dist = UnityEngine.Random.Range(minDist, maxDist);
        Vector2 offset = dir * dist;
        return new Vector3(player.position.x + offset.x, player.position.y + offset.y, 10f);
    }
    public void Reset()
    {
        wave = 0;
        count = 0;
        nextwave = true;
    }
    public void NextWave()
    {
        nextwave = true;
    }
    public void Pickstat()
    {
        statpicked = true;
    }
}
