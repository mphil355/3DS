using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width/10, Screen.height/2, Screen.width/4, Screen.height/10), "Start"))
		{
			Application.LoadLevel("Level");
		}
		if(GUI.Button(new Rect(Screen.width/2.6f, Screen.height/2, Screen.width/4, Screen.height/10), "Options"))
		{
			print ("options");
		}
		if(GUI.Button(new Rect(Screen.width/1.5f, Screen.height/2, Screen.width/4, Screen.height/10), "Exit"))
		{
			print ("exit");
		}
	}
}
