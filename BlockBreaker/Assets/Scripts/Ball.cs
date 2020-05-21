using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //configuration params
    [SerializeField] Paddle paddle;
    //state 
    Vector2 paddleToBallVector;

    private void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    private void Update()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

}
