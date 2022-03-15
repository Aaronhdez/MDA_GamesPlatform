using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControllerPong : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private bool isPlayer;

    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update() {
        MovePaddle();
    }

    private void MovePaddle() {
        var inputKey = (isPlayer) ?
            Input.GetAxisRaw("Vertical") : Input.GetAxisRaw("Vertical2");
        float movement = inputKey * speed * Time.deltaTime;
        Vector2 paddlePosition = transform.position;
        paddlePosition.y = Mathf.Clamp(paddlePosition.y + movement, -3, 3);
        transform.position = paddlePosition;
    }
}
