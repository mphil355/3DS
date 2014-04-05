using UnityEngine;
using System.Collections;

public class CameraPixelPerfect : MonoBehaviour {
	private float _lastHeight;
	public  GameObject holder;
	public  float delimiter;

	// Use this for initialization
	void Start () {
		holder.transform.localScale = new Vector3(delimiter, delimiter, delimiter);
		SetScale();
	}
	
	public void SetScale ()
	{
		Debug.Log("Rescale to " + Screen.height.ToString() + " pixels");
		Camera.mainCamera.orthographicSize = (Screen.height / 2) * delimiter;
//		Camera.mainCamera.far = 5000 * delimiter;
		_lastHeight = Screen.height;
	}

	// Update is called once per frame
	void Update () {
		if (_lastHeight != Screen.height)
			SetScale();
	}
}
