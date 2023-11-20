using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveLevelTwo : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text text; 
    [SerializeField] PlayerHealth PlayerHealthScript;
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject Portal;
    GameObject[] Enemies;
    // int enemiesSpawned = 0;
    public int totalEnemies = 5;
    int enemiesKilled = 0;
    void Start()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        text = gameObject.GetComponent<TMP_Text>();
        text.text = "Hi";
        spawnEnemy(PlayerHealthScript);
    }

    // Update is called once per frame
    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(Enemies.GetLength(0) == 0 && enemiesKilled < totalEnemies)
        {
            enemiesKilled += 1;
            spawnEnemy(PlayerHealthScript);
        }
        string message = $"Objective:\nKill Enemies: {enemiesKilled}/5";
        text.text = message;
        if(enemiesKilled == totalEnemies)
        {
            Portal.SetActive(true);
        }
    }
    void spawnEnemy(PlayerHealth ph)
    {
        Debug.Log("enemyspawned");
        GameObject enemy = Instantiate(enemyPrefab, spawner.transform.position, spawner.transform.rotation);
        SlimeHit slimehit = enemy.GetComponentInChildren<SlimeHit>();
        slimehit.playerHealth = ph;
        Debug.Log(slimehit.playerHealth);
    }
}
