using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue;
    public ParticleSystem explosionParticle;

    private GameManager gameManager;
    private Rigidbody targetRb;

    private float minUpForce = 11;
    private float maxUpForce = 15;
    private float maxTorque = 11;
    private float xRange = 4;
    private float yPosition = -3;


    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();
    }

    void Update()
    {
        //if (transform.position.y < -7)
        //    Destroy(gameObject);
    }

    private void OnMouseDown()
	{
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
	{
        Destroy(gameObject);
        if (!other.gameObject.CompareTag("Bad"))
            gameManager.GameOver();
    }
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minUpForce, maxUpForce);
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
