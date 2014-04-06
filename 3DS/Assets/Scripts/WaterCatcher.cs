using UnityEngine;
using System.Collections;

public class WaterCatcher : MonoBehaviour 
{
	private GameController controller;

	void Start()
	{
		controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{		
		if(col.gameObject.tag == "Droplet")
		{
			controller.current += 1;
		}
	}
}
