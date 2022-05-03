using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllerPong : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float maximumVelocity;
    [SerializeField] private float currentVelocity;
    [SerializeField] private float multiplier;
    [SerializeField] private Rigidbody2D ballRb;
    [SerializeField] private AudioSource audioSource;

    void Start() {
        multiplier = PlayerPrefs.GetFloat("speed"); 
        ballRb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        currentVelocity = initialVelocity;
        maximumVelocity = initialVelocity * 1.5f;
        Launch();
    }

    public void Launch() {
        float xVelocity = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * currentVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (IsPaddle(collision)) {
            if (currentVelocity < maximumVelocity) {
                var updatedVelocity = Mathf.Clamp(multiplier, 1, (1.5f * currentVelocity));
                currentVelocity *= updatedVelocity;
                ballRb.velocity *= updatedVelocity;
            }
            audioSource.Play();
        }
    }

    private bool IsPaddle(Collision2D collision) {
        return collision.gameObject.CompareTag("Paddle"); 
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
