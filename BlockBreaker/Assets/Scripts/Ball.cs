using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //configuration params
    [SerializeField] Paddle paddle;
    [Header("Movement Variables")]
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;
    [SerializeField] float randomFactor = 0.2f;
    [Header("Audio Clips")]
    [SerializeField] AudioClip[] ballSounds;
    //state 
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //cache component references 
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

    private void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }

    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 velocityAdjustment = new Vector2
        (Random.Range(0, randomFactor),
        Random.Range(0, randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityAdjustment;
        }
    }
}
