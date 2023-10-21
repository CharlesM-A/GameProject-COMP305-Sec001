using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform toFollow;
    [SerializeField] float smoothTime = 3f; //smaller values will move more quickly
    Vector3 velocity;
    private void Start()
    {
        velocity=new Vector3(0, 0, transform.position.z);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 target = new Vector3(toFollow.position.x, 0, transform.position.z);
        transform.position = Vector3.SmoothDamp(
            transform.position,
            target,
            ref velocity,
            smoothTime);
    }
}