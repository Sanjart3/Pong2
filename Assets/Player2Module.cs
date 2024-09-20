using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Module : MonoBehaviour
{
    public float movementSpeed;
    public bool isAI;
    public GameObject ball;

    private Rigidbody2D rb;
    private Vector2 playerMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isAI)
        {
            AIControl();
        }
        else
        {
            PlayerControl();
        }
    }

    private void PlayerControl()
    {
        playerMove = new Vector2(0, 0); // Reset movement

        if (Input.GetKey(KeyCode.UpArrow)) // Move up
        {
            playerMove.y = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow)) // Move down
        {
            playerMove.y = -1;
        }
    }

    private void AIControl()
    {
        playerMove = new Vector2(0, 0); // Reset movement

        if (Input.GetKey(KeyCode.W)) // Move up
        {
            playerMove.y = 1;
        }
        else if (Input.GetKey(KeyCode.S)) // Move down
        {
            playerMove.y = -1;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = playerMove * movementSpeed; // Use velocity for smooth movement
    }
}