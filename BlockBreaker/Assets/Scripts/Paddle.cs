using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Header("configuration Parameters")]
    [SerializeField] float screnWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    GameSession myGameSession;
    Ball myball;
    private void Start()
    {
        myGameSession = FindObjectOfType<GameSession>();
        myball = FindObjectOfType<Ball>();
    }
    void Update()
    {
        //see the mouse position relative to the screen width.
        //Debug.Log(Input.mousePosition.x / Screen.width * screnWidthInUnits);
        //float mousePosInUnits = Input.mousePosition.x / Screen.width * screnWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }
    private float GetXPos()
    {
        if (myGameSession.IsAutoPlayEnabled())
        {
            return myball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screnWidthInUnits;
        }
    }
}
