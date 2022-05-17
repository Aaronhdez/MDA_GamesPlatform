using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerArkanoids : MonoBehaviour, FreezeableArkanoids
{
    private Rigidbody2D _rigidBody;
    public float speed = 500.0f;
    public float maxLifeTime = 10.0f;
    public Vector2 direccion;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    public void Project(Vector2 direction)
    {
        direccion = direction;
        _rigidBody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLifeTime);
    }

    public void freeze()
    {
        _rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void unfreeze()
    {
        _rigidBody.constraints = RigidbodyConstraints2D.None;
        _rigidBody.AddForce(direccion * this.speed);
        Destroy(this.gameObject, this.maxLifeTime);
    }
}
