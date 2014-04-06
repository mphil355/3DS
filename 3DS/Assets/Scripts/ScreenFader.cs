using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour 
{
	public Texture2D fadeScreen;

	private bool sceneStarting;
	private bool sceneEnding;
	private float alpha;
	private float fadeTime;

	void Awake()
	{
		StartScene(3.0f);
	}

	void OnGUI()
	{
		SceneCheck();
		GUI.color = new Color(1, 1, 1, alpha);
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeScreen);
	}

	void SceneCheck()
	{		
		if(sceneStarting)
			FadeToClear();
		else if(sceneEnding)
			FadeToBlack();
	}

	void FadeToClear()
	{
		alpha -= Mathf.Clamp01(Time.deltaTime/fadeTime);
		if (alpha <= 0.05f)
		{
			alpha = 0.0f;
			sceneStarting = false;
		}		
	}

	void FadeToBlack()
	{	
		alpha += Mathf.Clamp01(Time.deltaTime/fadeTime);
		if (alpha >= 0.95f)
		{
			alpha = 1.0f;
			sceneEnding = false;
		}
	}

	public void StartScene(float time)
	{
		alpha = 1.0f;
		sceneStarting = true;
		sceneEnding = false;
		fadeTime = time;
	}
	
	public void EndScene(float time)
	{
		alpha = 0.0f;
		sceneStarting = false;
		sceneEnding = true;
		fadeTime = time;
	}
}

