using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerArkanoid : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float upperLimit;
    [SerializeField] private float lowerLimit;
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;

    // Start is called before the first frame update
    void Start()
    {
        upperLimit = GameObject.Find("UpperBoundary").transform.position.y - 1;
        lowerLimit = GameObject.Find("LowerBoundary").transform.position.y + 1;
        leftLimit = GameObject.Find("LeftBoundary").transform.position.x + 1;
        rightLimit = GameObject.Find("RightBoundary").transform.position.x - 1;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 playerPosition = transform.position;
        var inputY = Input.GetAxisRaw("Vertical");
        var inputX = Input.GetAxisRaw("Horizontal");
        float movementY = inputY * speed * Time.deltaTime;
        float movementX = inputX * speed * Time.deltaTime;
        playerPosition.y = Mathf.Clamp(playerPosition.y + movementY, lowerLimit, upperLimit);
        playerPosition.x = Mathf.Clamp(playerPosition.x + movementX, leftLimit, rightLimit);
        transform.position = playerPosition;
    }
}
