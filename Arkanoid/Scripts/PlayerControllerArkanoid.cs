using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerArkanoid : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float torqueSpeed = 1.0f;
    [SerializeField] public Camera camera;
    [SerializeField] private Transform target;
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
        PointToMouse();
    }

    
    private void MovePlayer()
    {
        Vector2 playerPosition = transform.position;
        playerPosition.y=MoveY(playerPosition);
        playerPosition.x=MoveX(playerPosition);
        transform.position = playerPosition;
    }

    private float MoveX(Vector2 playerPosition)
    {
        var inputX = Input.GetAxisRaw("Horizontal");
        float movementX = inputX * speed * Time.deltaTime;
        playerPosition.x = Mathf.Clamp(playerPosition.x + movementX, leftLimit, rightLimit);
        return playerPosition.x;
    }

    private float MoveY(Vector2 playerPosition)
    {
        var inputY = Input.GetAxisRaw("Vertical");
        float movementY = inputY * speed * Time.deltaTime;
        playerPosition.y = Mathf.Clamp(playerPosition.y + movementY, lowerLimit, upperLimit);
        return playerPosition.y;
    }
    private void PointToMouse()
    {
        var mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        var object_pos = Camera.main.WorldToScreenPoint(target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        var angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
 
       
    }

}
