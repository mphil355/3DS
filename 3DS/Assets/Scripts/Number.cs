

using UnityEngine;
using System.Collections;

public class Number : MonoBehaviour 
{
	public int value;

	private GameController gameController;

	void Start()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		print ("Hit");
		if(col.gameObject.tag == "MathSymbols")
		{
			gameController.AddScore(value);
			Destroy(gameObject);
			Destroy(col.gameObject);
		}
	}
	
}//end Number.cs
