using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllerPong : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float multiplier;
    [SerializeField] private Rigidbody2D ballRb;

    void Start()
    {
        multiplier = PlayerPrefs.GetFloat("speed"); 
        ballRb = GetComponent<Rigidbody2D>();
        Launch();
    }

    public void Launch() {
        float xVelocity = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (IsPaddleOrWall(collision)) {
            ballRb.velocity *= multiplier;
        }
    }

    private static bool IsPaddleOrWall(Collision2D collision) {
        return collision.gameObject.CompareTag("Paddle") ||
                    collision.gameObject.name.Equals("UpperWall") ||
                    collision.gameObject.name.Equals("LowerWall");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (IsPlayerOneTarget(collision)) {
            GameControllerPong.Instance.IncreasePlayerOneScore(1);
        } else if (IsPlayerTwoTarget(collision)) {
            GameControllerPong.Instance.IncreasePlayerTwoScore(1);
        }
        GameControllerPong.Instance.Restart();
        Launch();
    }

    private bool IsPlayerOneTarget(Collider2D collision) {
        return collision.gameObject.CompareTag("pongPlayer1");
    }

    private bool IsPlayerTwoTarget(Collider2D collision) {
        return collision.gameObject.CompareTag("pongPlayer2");
    }
}
