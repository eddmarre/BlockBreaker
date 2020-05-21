using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Header("configuration Parameters")]
    [SerializeField] float screnWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    void Update()
    {
        //see the mouse position relative to the screen width.
        //Debug.Log(Input.mousePosition.x / Screen.width * screnWidthInUnits);
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screnWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = paddlePos;
    }
}
