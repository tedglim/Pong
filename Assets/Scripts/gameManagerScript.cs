using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerScript : MonoBehaviour
{
    int p1Score = 0;
    int p2Score = 0;
    public GUISkin skin;
    public Rigidbody2D mainBall;
    public GameObject p1;
    public GameObject p2;
    public int EndScore;
    public bool isGameOver = false;

    public void Score(string ScoredOn)
    {
        if(!isGameOver)
        {
            if (ScoredOn == "rightWall")
            {
                Debug.Log("I hit: " + ScoredOn);
                p1Score += 1;
            } else if (ScoredOn == "leftWall")
            {
                Debug.Log("I hit: " + ScoredOn);
                p2Score += 1;
            }
        }
    }

    void OnGUI ()
    {
        GUI.skin = skin;
        GUI.Label (new Rect (Screen.width/2 - 150, 20, 100, 100), "" + p1Score);
        GUI.Label (new Rect (Screen.width/2 + 150, 20, 100, 100), "" + p2Score);
        if(isGameOver)
        {
            Reset();
            if(p1Score == EndScore)
            {
                GUI.Label (new Rect (Screen.width/2 - 100, Screen.height/2 - 50, 400, 100), "WINNER");
            } else if(p2Score == EndScore)
            {
                GUI.Label (new Rect (Screen.width/2 - 150, Screen.height/2 - 50, 400, 100), "GAME OVER");
            }
            if (GUI.Button(new Rect (Screen.width/2 - 121/2, 35, 121, 35), "Play Again"))
            {
                p1Score = 0;
                p2Score = 0;
                isGameOver = false;
                ResetAndGo();
            }
        }     
    }

    public void ResetAndGo()
    {
        if(p1Score == EndScore || p2Score == EndScore)
        {
            isGameOver = true;
        }
        if (!isGameOver) {
            Reset();
            mainBall.gameObject.SendMessage("LaunchBall");
        }
    }

    public void Reset()
    {
        p1.transform.position = new Vector3(p1.transform.position.x, 0, p1.transform.position.z);
        p2.transform.position = new Vector3(p2.transform.position.x, 0, p2.transform.position.z);
        mainBall.position = Vector2.zero;
        mainBall.velocity = Vector2.zero;
    }
}
