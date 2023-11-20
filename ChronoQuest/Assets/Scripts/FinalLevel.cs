using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject portal;
    GameObject enemy;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        if(!enemy)
        {
            Debug.Log("enemydead");
        }
    }
}
