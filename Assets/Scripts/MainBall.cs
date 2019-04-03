using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainBall : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedX;
    public float speedY;
    public Text countdown;
    private int timer;
    private AudioSource hitSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitSound = GetComponent<AudioSource>();
        LaunchBall();
    }

    // Update is called once per frame
    void Update()
    {
        MaintainHorizontalVelocity();
    }

    void LaunchBall(){
        StartCoroutine(LaunchCount());
    }

    IEnumerator LaunchCount(){
        // StartCoroutine()
        timer = 3;
        while(true) {
            if (timer == 0) {
                countdown.text = "START";
                yield return new WaitForSecondsRealtime(1);
                countdown.text = "";
                break;
            } else {
                countdown.text = (timer).ToString("0");
                timer -= 1;
                yield return new WaitForSecondsRealtime(1);
            }
        }

        float rand = Random.Range(0f,2f);
        if (rand <= .5f)
        {
            rb.velocity = new Vector2(speedX, speedY);
        } else if (rand <= 1.0f)
        {
            rb.velocity = new Vector2(speedX, -speedY);
        } else if (rand <= 1.5f)
        {
            rb.velocity = new Vector2(-speedX, speedY);
        } else 
        {
            rb.velocity = new Vector2(-speedX, -speedY);
        }
    }

    void MaintainHorizontalVelocity()
    {
        float velX = rb.velocity.x;
        float velY = rb.velocity.y;
        if (velX < (speedX - 1) && velX > (-speedX + 1) && velX != 0)
        {
            if (velX > 0)
            {
                rb.velocity = new Vector2(speedX, velY);
            } else {
                rb.velocity = new Vector2(-speedX, velY);
            }
        }
        if (velY < (speedY - 1) && velY > (-speedY + 1) && velY != 0)
        {
            if (velY > 0)
            {
                rb.velocity = new Vector2(velX, speedY);
            } else {
                rb.velocity = new Vector2(velX, -speedY);
            }
        }        
    }

    void OnCollisionEnter2D (Collision2D hit)
    {
        if (hit.gameObject.tag == "Paddle")
        {
            float velY = rb.velocity.y/2 + 2*hit.rigidbody.velocity.y/3;
            rb.velocity = new Vector2(rb.velocity.x, velY);
            hitSound.pitch = Random.Range(.9f, 1.1f);
            hitSound.Play();
        }
    }
}
