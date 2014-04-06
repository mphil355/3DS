
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	private int goal;
	private int current;

	private GUIText scoreText;

	void Start()
	{
		current = 0;
		scoreText = GetComponentInChildren<GUIText>();
		UpdateScore();
	}

	public void AddScore(int value)
	{
		current += value;
		print(current);
		UpdateScore();
	}

	void UpdateScore()
	{
		scoreText.text = current.ToString();
	}
}//end GameController.cs
