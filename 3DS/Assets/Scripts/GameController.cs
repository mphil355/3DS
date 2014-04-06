
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	private int goal;
	private int current;

	private GUIText scoreText;
	private GUIText ammoText;
	private string display;
	private bool gameOver;

	private SymbolLauncher launcher;

	void Start()
	{
		current = 0;
		gameOver = false;
		goal = Random.Range(3, 15);
		scoreText = GameObject.Find("Score Text").GetComponent<GUIText>();
		ammoText = GameObject.Find("Ammo Text").GetComponent<GUIText>();
		launcher = GameObject.FindGameObjectWithTag("Launcher").GetComponent<SymbolLauncher>();
		UpdateScore();
	}

	void Update()
	{
		UpdateAmmo();
		if(launcher.ammo <= 0 || current >= goal)
			gameOver = true;
	}

	void OnGUI()
	{
		if(gameOver)
			GameOver();
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

	void GameOver()
	{
		if(GUI.Button(new Rect(Screen.width/2 - Screen.width/8, Screen.height/2, Screen.width/4, Screen.height/10), "Reset"))
		{
			Application.LoadLevel(Application.loadedLevel);
		}

	}
}//end GameController.cs
