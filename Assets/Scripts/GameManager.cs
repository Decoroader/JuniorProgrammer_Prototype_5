using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    //private float spawnRate;

    void Start()
    {
        StartCoroutine(SpawnTarget());
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
