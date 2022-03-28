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
        Debug.Log(PlayerPrefs.GetFloat("speed"));
        multiplier = PlayerPrefs.GetFloat("speed"); 
        ballRb = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void Launch() {
        float xVelocity = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (isPaddleOrWall(collision)) {
            ballRb.velocity *= multiplier;
        }
    }

    private static bool isPaddleOrWall(Collision2D collision) {
        return collision.gameObject.CompareTag("Paddle") ||
                    collision.gameObject.name.Equals("UpperWall") ||
                    collision.gameObject.name.Equals("LowerWall");
    }
}
