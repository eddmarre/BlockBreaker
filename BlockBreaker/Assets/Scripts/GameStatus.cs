﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int scorePerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    int currentScore = 0;
    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }
    private void Update()
    {
        Time.timeScale = gameSpeed;
    }
    public void AddToScore()
    {
        currentScore += scorePerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
}
