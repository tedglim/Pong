using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public gameManagerScript gameManager;

    void OnCollisionEnter2D (Collision2D hit)
    {
        if(hit.gameObject.name == "MainBall"){
            string scoredOn = this.name;
            gameManager.Score(scoredOn);
            gameManager.ResetAndGo();
        }
    }
}
