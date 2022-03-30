using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControllerPong : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private bool isPlayer;
    [SerializeField] private bool isHuman = true;
    [SerializeField] private string mode;
    [SerializeField] private float upperLimit;
    [SerializeField] private float lowerLimit;
    [SerializeField] private float scale;

    // Start is called before the first frame update
    void Start(){
        mode = PlayerPrefs.GetString("mode");
        if (mode.Equals("pve") && !isPlayer) {
            isHuman = false;
        }
        upperLimit = GameObject.Find("UpperWall").transform.position.y;
        lowerLimit = GameObject.Find("LowerWall").transform.position.y;
        scale = GameObject.Find("GameScreen").transform.localScale.y;
    }

    // Update is called once per frame
    void Update() {
        if (isHuman) {
            MovePaddle();
        } else {
            MovePaddleAI();
        }
    }

    private void MovePaddleAI() {
        var ballPosition = GameObject.Find("Ball").transform.position;
        float movement = (ballPosition.y - transform.position.y) * speed * Time.deltaTime;
        MoveInBounds(movement);
    }

    private void MovePaddle() {
        var inputKey = (isPlayer) ?
            Input.GetAxisRaw("Vertical") : Input.GetAxisRaw("Vertical2");
        float movement = inputKey * speed * Time.deltaTime;
        MoveInBounds(movement);
    }

    private void MoveInBounds(float movement) {
        Vector2 paddlePosition = transform.position;
        var upperBound = (upperLimit-1) * scale;
        var lowerBound = (lowerLimit+1) * scale;
        paddlePosition.y = Mathf.Clamp(paddlePosition.y + movement, lowerBound, upperBound);
        transform.position = paddlePosition;
    }
}
