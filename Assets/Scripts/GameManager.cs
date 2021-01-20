﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;

    public Button restartButton;
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI TitleText;
    public GameObject titleScreen;

    private int score;


    //private float spawnRate;

    void Start()
    {

    }
    public void StartGame()
	{
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
        titleScreen.SetActive(false);
    }
    public void UpdateScore(int scoreToAdd)
	{
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
	{
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        StopAllCoroutines();
    }
    public void RestartGame()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    IEnumerator SpawnTarget()
	{
		while (true)
		{
            yield return new WaitForSeconds(1);
            Instantiate(targets[Random.Range(0, targets.Count)]);
        }
	}
}
