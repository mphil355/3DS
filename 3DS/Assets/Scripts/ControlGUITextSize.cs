using UnityEngine;
using System.Collections;

public class ControlGUITextSize : MonoBehaviour {

	public float sizeMultipler;

	void Start () 
	{
		foreach (Transform child in gameObject.transform)
		{
			child.guiText.fontSize = Mathf.RoundToInt(Screen.height * sizeMultipler);
			Debug.Log("Font size: " + child.guiText.fontSize.ToString());
		}
	}
}
