using UnityEngine;
using System.Collections;

public class SymbolLauncher : MonoBehaviour 
{
	public int ammo;

	private Vector3 originalSymbolPosition;
	private int currentIndex;
	private GameObject current;
	private bool launchInProgress;
	private bool canSpawn;
	private float spawnTimer;
	private bool symbolInLauncher;

	public float spawnRate;
	public int maxDistance;
	public float forceConstant;


	public GameObject[] symbols;


	void Start () 
	{
		spawnTimer = 0;
		canSpawn = false;
		originalSymbolPosition = transform.position;
		currentIndex = 0;
		SpawnMathSymbol();
	}

	void Update () 
	{
		if(current != null)
		{
			if (Input.GetMouseButton(0))
				LaunchBegin();
			if (Input.GetMouseButtonUp(0) || !Input.GetMouseButton(0) && launchInProgress )
				LaunchEnd();
		}
		if(!canSpawn && !symbolInLauncher)
		{
			spawnTimer += Time.deltaTime;
			if(spawnTimer >= spawnRate)
			{
				canSpawn = true;
				spawnTimer = 0;
			}
		}
		//print ("spawn: " + canSpawn + "launch: " + launchInProgress);
		if(canSpawn && !symbolInLauncher && ammo > 0)
			SpawnMathSymbol();
	}

	void LaunchBegin ()
	{
		launchInProgress = true;
		Vector3 launcherPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		launcherPosition = new Vector3(launcherPosition.x, launcherPosition.y, 0);
		
		float distance = Vector3.Distance(launcherPosition, transform.position);

		if (distance > maxDistance) {
			launcherPosition = transform.position + Vector3.ClampMagnitude(launcherPosition - transform.position, maxDistance);
		}

		if (launcherPosition.y > transform.position.y) {
			launcherPosition = new Vector2(launcherPosition.x, transform.position.y);
		}

		current.transform.position = launcherPosition;
	}

	void LaunchEnd ()
	{
		launchInProgress = false;
		symbolInLauncher = false;
		canSpawn = false;
		current.collider2D.enabled = true;
		current.rigidbody2D.velocity = Vector2.zero;
		current.rigidbody2D.AddForce((transform.position - current.transform.position) * forceConstant);
		ammo -= 1;
		Destroy (current, 5);
		current = null;
	}

	void SpawnMathSymbol()
	{
		canSpawn = false;
		symbolInLauncher = true;
		current = Instantiate(symbols[currentIndex], transform.position, Quaternion.identity) as GameObject;
		current.transform.position = originalSymbolPosition;
		current.collider2D.enabled = false;
	}
}
