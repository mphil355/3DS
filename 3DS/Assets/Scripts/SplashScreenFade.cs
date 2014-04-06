using UnityEngine;
using System.Collections;

public class SplashScreenFade : MonoBehaviour 
{
	private ScreenFader fader;

	void Start()
	{
		fader = GetComponent<ScreenFader>();
		StartCoroutine(FadeToMenu());
	}

	IEnumerator FadeToMenu()
	{
		yield return new WaitForSeconds(2);
		fader.EndScene(2);
		yield return new WaitForSeconds(2);
		Application.LoadLevel("Menu");
	}

}
