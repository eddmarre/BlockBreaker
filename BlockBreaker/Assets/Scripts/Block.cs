using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] AudioClip breakSound;
    [SerializeField] Sprite[] hitSprites;
    Level level;
    int timesHit;

    private void Start()
    {
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
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
            if (tag == "Breakable")
            {
                HandleHit();
            }
        }

    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits) DestroyBlock();
        else
        {
            ShowNextHitSprite();
        }
    }

    void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite Missing From Array" + gameObject.name);
        }

    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        level.BlockDestroyed();
        Destroy(gameObject);
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    void TriggerSparklesVFX()
    {
        var particles = Instantiate(blockSparklesVFX, transform.position, Quaternion.identity);
        Destroy(particles, 1f);
    }
}
