using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall_DeathZone : MonoBehaviour
{
    private Transform CameraP;
    
    // Start is called before the first frame update
    void Start()
    {
        CameraP = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = CameraP.position.x;
        transform.position = newPosition;
    }

    
}
