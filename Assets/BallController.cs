using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float initialSpeed = 10.0f; // Fixed typo
    public float speedIncrease = 0.2f;

    public Text playerText;
    public Text opponentText;
    private int hitCounter = 0;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2f);
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed + (speedIncrease * hitCounter));
    }

    private void StartBall()
    {
        rb.velocity = new Vector2(-1, 0) * (initialSpeed + speedIncrease * hitCounter);
    }

    private void RestartBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero; // Reset position
        hitCounter = 0;
        Invoke("StartBall", 2f);
    }

    private void PlayerBounce(Transform obj)
    {
        hitCounter++;
        Vector2 ballPosition = transform.position;
        Vector2 playerPosition = obj.position;

        float xDirection = (transform.position.x > 0) ? -1 : 1;
        float yDirection = (ballPosition.y - playerPosition.y) / obj.GetComponent<Collider2D>().bounds.size.y;

        if (yDirection == 0)
        {
            yDirection = 0.25f;
        }

        rb.velocity = new Vector2(xDirection, yDirection) * (initialSpeed + (speedIncrease * hitCounter));
    }

    private void OnCollisionEnter2D(Collision2D other) // Fixed method name
    {
        if (other.gameObject.name == "player1" || other.gameObject.name == "player2")
        {
            PlayerBounce(other.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (transform.position.x > 0)
        {
            RestartBall();
            if (int.TryParse(opponentText.text, out int opponentScore))
            {
                opponentText.text = (opponentScore + 1).ToString();
            }
        }
        else if (transform.position.x < 0)
        {
            RestartBall();
            if (int.TryParse(playerText.text, out int playerScore))
            {
                playerText.text = (playerScore + 1).ToString();
            }
        }
    }
}
