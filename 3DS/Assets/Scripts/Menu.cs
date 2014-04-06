﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{	
	private ScreenFader fader;

	void Start()
	{		
		fader = GetComponent<ScreenFader>();
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width/10, Screen.height/2, Screen.width/4, Screen.height/10), "Start"))
		{
			StartCoroutine(FadeToLevel());
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
	
	IEnumerator FadeToLevel()
	{
		fader.EndScene(2);
		yield return new WaitForSeconds(2);
		Application.LoadLevel("Level");
	}
}
