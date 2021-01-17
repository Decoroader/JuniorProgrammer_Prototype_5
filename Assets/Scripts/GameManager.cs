using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    private int score = 0;

    //private float spawnRate;

    void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    private void UpdateScore(int scoreToAdd)
	{
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    IEnumerator SpawnTarget()
	{
		while (true)
		{
            yield return new WaitForSeconds(1);
            Instantiate(targets[Random.Range(0, targets.Count)]);
            UpdateScore(5);

        }
	}
}
