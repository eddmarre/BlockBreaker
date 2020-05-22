using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void Update()
    {
        if (Debug.isDebugBuild)
        {
            DebugBinds();
        }
    }

    private void DebugBinds()
    {
        if (Input.GetKey(KeyCode.F))
        {
            level.BlockDestroyed();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "ball")
        {
            //Debug.Log("hit by " + other.gameObject.name);
            DestroyBlock();
        }

    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.BlockDestroyed();
        Destroy(gameObject);
    }
}
