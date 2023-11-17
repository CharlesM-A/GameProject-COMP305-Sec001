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
            SceneManager.LoadScene(sceneToIndex, LoadSceneMode.Single);
        }
    }
    
}
