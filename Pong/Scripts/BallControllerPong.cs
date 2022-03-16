using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllerPong : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float multiplier = 1.1f;
    private Rigidbody2D ballRb;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void Launch() {
    }
}
