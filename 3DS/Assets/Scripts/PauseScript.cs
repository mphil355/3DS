using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour 
{
	public GameObject pauseButton;
	public GameObject playButton;

	private bool pause;
	private SymbolLauncher launcher;

	void Start () 
	{
		pause = false;
		pauseButton = GameObject.Find("Pause");
		playButton = GameObject.Find("Play");
		launcher = GameObject.FindGameObjectWithTag("Launcher").GetComponent<SymbolLauncher>();
		playButton.SetActive(false);
	}

	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(!pause)
				Pause ();
			else
				Unpause();
		}
	}

	void OnGUI()
	{
		if(pause)
		{
			if(GUI.Button(new Rect(Screen.width/2 - Screen.width/8, Screen.height/2, Screen.width/4, Screen.height/10), "Paused"))
			{
				Unpause();
			}
		}
	}

	void Pause()
	{
		pause = true;
		launcher.enabled = false;
		playButton.SetActive(true);
		pauseButton.SetActive(false);
		Time.timeScale = 0;
	}
	void Unpause()
	{
		pause = false;
		launcher.enabled = true;
		playButton.SetActive(false);
		pauseButton.SetActive(true);
		Time.timeScale = 1;
	}
}
