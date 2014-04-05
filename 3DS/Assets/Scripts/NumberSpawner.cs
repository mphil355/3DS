using UnityEngine;
using System.Collections;

public class NumberSpawner : MonoBehaviour
{
	public GameObject[] numbers;						//array that holds the numbers

	public float spawnRate;								//how fast numbers spawn
	public float minX;									//left boundary
	public float maxX;									//right boundary

	private float spawnTimer;							//used to count up until the next spawn time
	private bool canSpawn;								//flag to tell if the script is ready to spawn another number

	void Start()
	{
		canSpawn = false;
		spawnTimer = 0;
	}

	void Update()
	{
		IncrementCounter();
		if(canSpawn)
			SpawnNumber();
	}

	void IncrementCounter()
	{
		if(!canSpawn)
		{
			spawnTimer += Time.deltaTime;
			if(spawnTimer >= spawnRate)
			{
				canSpawn = true;
				spawnTimer = 0;
			}
		}
	}

	void SpawnNumber()
	{
		canSpawn = false;
		int spawnIndex = Random.Range(0, numbers.Length);
		Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), transform.position.y, 0);
		GameObject theNumber = Instantiate(numbers[spawnIndex], spawnPosition, Quaternion.identity) as GameObject;
		theNumber.rigidbody2D.velocity = new Vector2(0f, -1f);
	}
}