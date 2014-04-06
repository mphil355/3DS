
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	private int goal;
	private int current;


	public void AddScore(int value)
	{
		current += value;
		print(current);
	}
}//end GameController.cs
