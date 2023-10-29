using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Crate : MonoBehaviour
{
    //public GameObject objective;
    public ObjectiveUpdater script;

    private void Start()
    {
        //script = objective.GetComponent<ObjectiveUpdater>();
        //script.UpdateCrates();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathObj")
        {
            Destroy(gameObject);
            script.UpdateCrates();
        }
    }
}
