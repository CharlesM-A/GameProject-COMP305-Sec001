using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveLevelTwo : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text text;
    int EnemiesLeft = 2;
    GameObject[] Enemies;
    void Start()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        text = gameObject.GetComponent<TMP_Text>();
        text.text = "Hi";
    }

    // Update is called once per frame
    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        EnemiesLeft = Enemies.GetLength(0);
        string message = $"Objective:\nKill Enemies: {EnemiesLeft}/2";
        text.text = message;
    }
}
