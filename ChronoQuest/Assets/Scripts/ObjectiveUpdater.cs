using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveUpdater : MonoBehaviour
{
    public TMP_Text text;
    public int CratesLeft;
    GameObject[] Crates;

    // Start is called before the first frame update
    void Start()
    {
        Crates = GameObject.FindGameObjectsWithTag("Crate");
        CratesLeft = Crates.GetLength(0);
        text.text = "101010";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCrates();
        string tex = $"Objective:\nDestroy Explosives: {CratesLeft}/3";
        text.text = tex;
    }

    //void SetScore()
    //{
    //    text.text = "asdas";
    //}
    
    public void UpdateCrates()
    {
        Crates = GameObject.FindGameObjectsWithTag("Crate");
        CratesLeft = Crates.GetLength(0);
        Debug.Log(CratesLeft);
        //SetScore();
    }
}
