using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField] float speed =3f;
    [SerializeField] Vector2 startPosition;// = 3.73f;
    float textureWidth = 0;
    void Start()
    {
        startPosition = transform.position;
        SetupTexture();
    }
    void SetupTexture()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        textureWidth = sprite.texture.width / sprite.pixelsPerUnit;
        textureWidth *= transform.localScale.x;
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x + textureWidth < 0)
        {
            transform.position = startPosition;
        }
    }
}