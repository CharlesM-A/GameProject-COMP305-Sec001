using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] float parallaxSpeedX;
    Transform cameraTransform;
    public float startPositionX;
    public float spriteWidth;
    //public float relativeCameraPositionX;
    //public float relativeDistanceX;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        startPositionX= transform.position.x; 
        spriteWidth = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        //print($"spriteWidth: {spriteWidth}");
        //print($"rect: {GetComponent<SpriteRenderer>().sprite.rect}");
        //print($"textureWidth: {GetComponent<SpriteRenderer>().sprite.texture.width}");
        //print($"screen Width: {Screen.width}");
        //print($"rect: {GetComponent<SpriteRenderer>().sprite.rect}");
        //print($"rect: {GetComponent<SpriteRenderer>().sprite.rect}");
        //print($"rect: {GetComponent<SpriteRenderer>().sprite.rect}");
        //print($"rect: {GetComponent<SpriteRenderer>().sprite.rect}");

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