using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerArkanoid : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var input = Input.GetAxisRaw("Vertical");
        var upperLimit = GameObject.Find("UpperBoundary").transform.position.y -1;
        var lowerLimit = GameObject.Find("LowerBoundary").transform.position.y +1;
        Vector2 playerPosition = transform.position;
        float movement = input * speed * Time.deltaTime;
        playerPosition.y = Mathf.Clamp(playerPosition.y + movement, lowerLimit, upperLimit);
        transform.position = playerPosition;
    }
}
