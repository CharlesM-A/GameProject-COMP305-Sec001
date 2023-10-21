using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] float parallaxSpeedX;
    Transform cameraTransform;
    public float startPositionX;
    public float spriteWidth;
    public float scale;
    public float startPositionY;
    //public float relativeCameraPositionX;
    //public float relativeDistanceX;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        startPositionX = transform.position.x; 
        startPositionX = transform.position.y; 
        spriteWidth = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        scale = transform.localScale.x;
        spriteWidth *= scale;

    }

    void Update()
    {
        float relativeDistanceX = cameraTransform.position.x * parallaxSpeedX;
        transform.position = new Vector3( startPositionX + relativeDistanceX, 0, 0 );


        float relativeCameraPositionX = cameraTransform.position.x - relativeDistanceX;
        if (relativeCameraPositionX > startPositionX + spriteWidth)
        {
            startPositionX += spriteWidth;
        }
        else if (relativeCameraPositionX < startPositionX - spriteWidth)
        {
            startPositionX -= spriteWidth;
        }
    }
}