using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarParticleMovement : MonoBehaviour
{
    private Transform cameraTransform;
    public float delay = 2.0f; // Seconds to wait before following the camera's X position
    private float startTime;

    // Start is called before the first frame update
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        startTime = Time.time; // Record the start time
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        // Check if the delay has passed
        if (Time.time - startTime > delay)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = cameraTransform.position.x;
            transform.position = newPosition;
        }
    }
}
