

using UnityEngine;
using System.Collections;

public class Number : MonoBehaviour 
{
	public int value;
	public GameObject splash;
	public GameObject droplet;

	private float randomZRotation;

	void Start()
	{
		Random.seed = System.DateTime.Now.Second;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//print ("Hit");
		if(col.gameObject.tag == "MathSymbols")
		{
			SpawnDroplets();
			Destroy(gameObject);
			Destroy(col.gameObject);
			Instantiate(splash, transform.position, Quaternion.identity);
		}
	}

	void SpawnDroplets()
	{
		Vector2 launch;
		GameObject drop;
		for (int i = 0; i < value; i++)
		{
			launch = new Vector2(Random.Range(-1, 1), Random.Range(2, 4));
			randomZRotation = Random.Range(0, 360);
			drop = Instantiate(droplet, transform.position, Quaternion.identity) as GameObject;
			drop.transform.Rotate(new Vector3(0, 0, randomZRotation));
			drop.rigidbody2D.velocity = launch;
		}
	}
	
}//end Number.cs
