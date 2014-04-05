using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	void OnGUI()
	{
		if(GUI.Button(new Rect(10, Screen.height/2 - 100, Screen.width/4, Screen.height/10), "Start"))
		{
			Application.LoadLevel("Level");
		}
		if(GUI.Button(new Rect(10, Screen.height/2, Screen.width/4, Screen.height/10), "Options"))
		{
			print ("options");
		}
		if(GUI.Button(new Rect(10, Screen.height/2 + 100, Screen.width/4, Screen.height/10), "Exit"))
		{
			print ("exit");
		}
	}
}
