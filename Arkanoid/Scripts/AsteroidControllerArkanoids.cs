
using UnityEngine;

public class AsteroidControllerArkanoids : MonoBehaviour, FreezeableArkanoids
{
    public Sprite[] sprites;
    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float speed = 40.0f;
    public int paused = 0;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Vector3 playerPosition;
    private Vector2 direccion;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        playerPosition = GameObject.Find("Player(Clone)").transform.position;   

        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        this.transform.eulerAngles = new Vector3(0.0f,0.0f,Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;
        _rigidbody.mass =this.size;
    }
    public void SetTrajectory(Vector2 direction)
    {
        direccion = direction;
        _rigidbody.AddForce(direccion* this.speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundaries"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            AsteroidDestruction(gameObject);
        }
    }

    private void AsteroidDestruction(GameObject gameObject)
    {
        if (this.size * 0.5f >= this.minSize)
        {
            CreateSplit();
            CreateSplit();
        }
        Destroy(this.gameObject);
    }

    private void CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;
        AsteroidControllerArkanoids split = Instantiate(this, position, this.transform.rotation);
        split.size = this.size * 0.5f;
        split.SetTrajectory(Random.insideUnitCircle.normalized);
    }

    public void freeze()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void unfreeze()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.None;
        _rigidbody.AddForce(direccion * this.speed);
    }
}

