using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    private float minUpForce = 9;
    private float maxUpForce = 17;
    private float maxTorque = 11;
    private float xRange = 4;
    private float yPosition = -5;


    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();
    }

    void Update()
    {
        
    }
    
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(-minUpForce, maxUpForce);
    }
    private float RandomTorque()
	{
        return Random.Range(-maxTorque, maxTorque);
	}
    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), yPosition);
    }
}
