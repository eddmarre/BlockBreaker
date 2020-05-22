using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "ball")
        {
            //Debug.Log("hit by " + other.gameObject.name);
            Destroy(gameObject);
        }

    }
}
