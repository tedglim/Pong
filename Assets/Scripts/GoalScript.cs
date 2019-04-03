using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public gameManagerScript gameManager;
    private AudioSource scoreSound;

    void Start ()
    {
        scoreSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D (Collision2D hit)
    {
        if(hit.gameObject.name == "MainBall"){
            scoreSound.Play();
            string scoredOn = this.name;
            gameManager.Score(scoredOn);
            gameManager.ResetAndGo();
        }
    }
}
