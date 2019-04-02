using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public Camera mainCamera;
    public KeyCode up;
    public KeyCode down;
    public Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float paddleOffset = GetComponent<Collider2D>().bounds.size.y/2;
        float screenTop = mainCamera.ScreenToWorldPoint (new Vector3(0, Screen.height, 0)).y;
        float screenBottom = mainCamera.ScreenToWorldPoint (new Vector3(0, 0, 0)).y;
        if(Input.GetKey(up))
        {
            rb.velocity = new Vector2(0f, speed);
            if(rb.position.y + paddleOffset > screenTop)
            {
                rb.position = new Vector2(rb.position.x, screenTop - paddleOffset);
            }
        } else if (Input.GetKey(down))
        {
            rb.velocity = new Vector2(0f, -speed);
            if(rb.position.y - paddleOffset < screenBottom)
            {
                rb.position = new Vector2(rb.position.x, screenBottom + paddleOffset);
            }
        } else 
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }
}
