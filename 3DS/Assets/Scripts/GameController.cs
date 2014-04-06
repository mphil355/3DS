
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	private int goal;
	private int current;

	private GUIText scoreText;
	private GUIText ammoText;
	private string display;

	private SymbolLauncher launcher;

	void Start()
	{
		current = 0;
		goal = Random.Range(3, 30);
		scoreText = GameObject.Find("Score Text").GetComponent<GUIText>();
		ammoText = GameObject.Find("Ammo Text").GetComponent<GUIText>();
		launcher = GameObject.FindGameObjectWithTag("Launcher").GetComponent<SymbolLauncher>();
		UpdateScore();
	}

	void Update()
	{
		UpdateAmmo();
	}

	public void AddScore(int value)
	{
		current += value;
		UpdateScore();
	}

	void UpdateScore()
	{
		display = current.ToString() + " / " + goal.ToString();
		scoreText.text = display;
	}

	void UpdateAmmo()
	{
		string ammoDisplay = "";
		for(int i = 1; i <= launcher.ammo; i ++)
		{
			ammoDisplay += "+ ";
		}
		ammoText.text = ammoDisplay;
	}
}//end GameController.cs
