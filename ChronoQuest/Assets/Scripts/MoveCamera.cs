using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] float speed = 5;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical") / 100;
        Vector2 movement = new Vector2 (x, 0);
        transform.Translate( movement * speed * Time.deltaTime);
    }
}