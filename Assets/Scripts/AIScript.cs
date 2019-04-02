using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    public Camera mainCamera;
    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public Rigidbody2D mainBall;
    public Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float paddleOffset = GetComponent<Collider2D>().bounds.size.y/2;
        float screenTop = mainCamera.ScreenToWorldPoint (new Vector3(0, Screen.height, 0)).y;
        float screenBottom = mainCamera.ScreenToWorldPoint (new Vector3(0, 0, 0)).y;
        if(mainBall.velocity.x > 0)
        {
            if(rb.position.y + paddleOffset < screenTop && mainBall.position.y > rb.position.y)
            {
                rb.velocity = new Vector2(0, speed * Time.deltaTime);
            } else if (rb.position.y - paddleOffset > screenBottom && mainBall.position.y < rb.position.y)
            {
                rb.velocity = new Vector2(0, -speed * Time.deltaTime);
            } else {
                rb.velocity = Vector2.zero;
            }
            if(mainBall.velocity.y < 5f && mainBall.velocity.y > -5f && rb.position.y + paddleOffset < screenTop && rb.position.y - paddleOffset > screenBottom && mainBall.position.y < rb.position.y + paddleOffset && mainBall.position.y > rb.position.y - paddleOffset)
            {
                rb.velocity = new Vector2(0, mainBall.velocity.y);
            }
        } else {
            rb.velocity = Vector2.zero;
        }
    }
}
