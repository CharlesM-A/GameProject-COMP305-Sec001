using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarParticleMovement : MonoBehaviour
{
    private Transform cameraTransform;
    // Start is called before the first frame update
    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = cameraTransform.position.x;
        transform.position = newPosition;
    }
}
