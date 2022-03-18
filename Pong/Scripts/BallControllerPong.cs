using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllerPong : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float multiplier = 1.1f;
    private Rigidbody2D ballRb;
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void Launch() {
        float xVelocity = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Paddle")) {
            initialVelocity *= multiplier;
        }
    }
}
