using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public float speed = 500.0f;
    public float maxLifeTime = 10.0f;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    public void Project(Vector2 direction)
    {
        _rigidBody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLifeTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
