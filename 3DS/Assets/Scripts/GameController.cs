
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
		scoreText = GetComponentInChildren<GUIText>();
		launcher = GameObject.FindGameObjectWithTag("Launcher").GetComponent<SymbolLauncher>();
		UpdateScore();
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
		ammoText.text = launcher.ammo.ToString();
	}
}//end GameController.cs
