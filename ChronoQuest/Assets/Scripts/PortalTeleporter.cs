using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public int sceneToIndex;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            Debug.Log("Player Hit portal");
            SceneManager.LoadScene(sceneToIndex, LoadSceneMode.Single);
        }
        Debug.Log("Hit portal");
    }
    
}
