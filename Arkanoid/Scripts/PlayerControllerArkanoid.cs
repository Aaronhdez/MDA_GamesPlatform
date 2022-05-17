using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerArkanoid : MonoBehaviour, FreezeableArkanoids
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float torqueSpeed = 1.0f;
    [SerializeField] public Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private float upperLimit;
    [SerializeField] private float lowerLimit;
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    public BulletControllerArkanoids bulletPrefab;
    public int paused = 0;

    // Start is called before the first frame update
    void Start()
    {
        upperLimit = GameObject.Find("PlayerUpperBoundary").transform.position.y - 1;
        lowerLimit = GameObject.Find("PlayerLowerBoundary").transform.position.y + 1;
        leftLimit = GameObject.Find("PlayerLeftBoundary").transform.position.x + 1;
        rightLimit = GameObject.Find("PlayerRightBoundary").transform.position.x - 1;
        var originalRigid = gameObject.GetComponent<Rigidbody2D>().constraints;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(paused == 0)
        {
            MovePlayer();
            PointToMouse();

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
            
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
        float movementX;
        movementX = inputX * speed * Time.deltaTime;
    
        playerPosition.x = Mathf.Clamp(playerPosition.x + movementX, leftLimit, rightLimit);
        return playerPosition.x;
    }

    private float MoveY(Vector2 playerPosition)
    {
        var inputY = Input.GetAxisRaw("Vertical");
        float movementY;
        movementY = inputY * speed * Time.deltaTime;
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
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            FindObjectOfType<ArkanoidsGameManager>().Restart();
        }
    }
    public void Shoot()
    {
        BulletControllerArkanoids bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }

    public void freeze()
    {
        paused = 1;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void unfreeze()
    {
        paused = 0;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
}
