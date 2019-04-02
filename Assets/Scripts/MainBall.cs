using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBall : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedX;
    public float speedY;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDelay());
    }

    // Update is called once per frame
    void Update()
    {
        float velX = rb.velocity.x;
        if (velX < (speedX - 1) && velX > (-speedX + 1) && velX != 0)
        {
            if (velX > 0)
            {
                velX = speedX;
                rb.velocity = new Vector2(velX, rb.velocity.y);
            } else {
                velX = -speedX;
                rb.velocity = new Vector2(velX, rb.velocity.y);
            }
        }
    }

    void OnCollisionEnter2D (Collision2D hit)
    {
        if (hit.gameObject.tag == "Paddle")
        {
            float velY = rb.velocity.y/2 + hit.rigidbody.velocity.y;
            rb.velocity = new Vector2(rb.velocity.x, velY);
        }
    }

    IEnumerator StartDelay(){
        yield return new WaitForSecondsRealtime(3.0f);
        LaunchBall();
    }

    void LaunchBall(){
        rb = GetComponent<Rigidbody2D>();
        float rand = Random.Range(0f,2f);
        if (rand <= 1)
        {
            rb.velocity = new Vector2(speedX, speedY);
        } else 
        {
            rb.velocity = new Vector2(-speedX, speedY);
        }
    }
}
