using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    public bool isPlayer1 = false;
    public GameObject ball;

    private Rigidbody2D rb;

    private Vector2 playerMovement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1){
            PaddleAController();
        } else {
            PaddleBController();
        }
    }

    private void PaddleAController(){
        playerMovement = new Vector2(0, Input.GetAxis("Vertical"));
    }

    private void PaddleBController(){
        if(ball.transform.position.y>transform.position.y+0.5f){
            playerMovement = new Vector2(0,1);
        } else if (ball.transform.position.y<transform.position.y - 0.5f){
            playerMovement = new Vector2(0,-1);
        } else {
            playerMovement = new Vector2(0,0);
        }
    }

    public void FixedUpdate(){
        rb.velocity = playerMovement *speed;
    }
}
