using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupScript : MonoBehaviour
{
    public Camera mainCamera;
    public BoxCollider2D topWall;
    public BoxCollider2D rightWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public GameObject p1;
    public GameObject p2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        topWall.size = new Vector2 (mainCamera.ScreenToWorldPoint (new Vector3 (Screen.width * 2f, 0f, 0f)).x, 1f);
        topWall.offset = new Vector2 (0f, mainCamera.ScreenToWorldPoint (new Vector3 (0f, Screen.height, 0f)).y + 0.5f);

        rightWall.size = new Vector2 (1f, mainCamera.ScreenToWorldPoint (new Vector3 (0f, Screen.height * 2f, 0f)).y);
        rightWall.offset = new Vector2 (mainCamera.ScreenToWorldPoint (new Vector3 (Screen.width, 0f, 0f)).x + 0.5f, 0f);

        bottomWall.size = new Vector2 (mainCamera.ScreenToWorldPoint (new Vector3 (Screen.width * 2f, 0f, 0f)).x, 1f);
        bottomWall.offset = new Vector2 (0f, mainCamera.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).y - 0.5f);

        leftWall.size = new Vector2 (1f, mainCamera.ScreenToWorldPoint (new Vector3 (0f, Screen.height * 2f, 0f)).y);
        leftWall.offset = new Vector2 (mainCamera.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).x - 0.5f, 0f);

        Vector3 p1Temp = p1.transform.position;
        p1Temp.x = mainCamera.ScreenToWorldPoint (new Vector3 (75f, 0f, 0f)).x;
        p1.transform.position = p1Temp;
        p1.transform.eulerAngles = new Vector3 (0f, 0f, 90f);

        Vector3 p2Temp = p2.transform.position;
        p2Temp.x = mainCamera.ScreenToWorldPoint (new Vector3 (Screen.width - 75f, 0f, 0f)).x;
        p2.transform.position = p2Temp;
        p2.transform.eulerAngles = new Vector3 (0f, 0f, -90f);
    }
}
