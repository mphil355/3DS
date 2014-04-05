using UnityEngine;
using System.Collections;

public class SymbolLauncher : MonoBehaviour {

	public GameObject referencePoint;

	private Vector3 originalSymbolPosition;

	private bool launchInProgress;

	public int maxDistance;
	public float forceConstant;

	void Start () 
	{
		originalSymbolPosition = gameObject.transform.position;
	}

	void Update () 
	{
		if (Input.GetMouseButton(0))
			LaunchBegin();
		if (Input.GetMouseButtonUp(0) || !Input.GetMouseButton(0) && launchInProgress )
			LaunchEnd();
	}

	void LaunchBegin ()
	{
		launchInProgress = true;
		Vector3 launcherPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		launcherPosition = new Vector3(launcherPosition.x, launcherPosition.y, 0);
		
		float distance = Vector3.Distance(launcherPosition, referencePoint.transform.position);

		if (distance > maxDistance) {
			launcherPosition = referencePoint.transform.position + Vector3.ClampMagnitude(launcherPosition - referencePoint.transform.position, maxDistance);
		}

		if (launcherPosition.y > referencePoint.transform.position.y) {
			launcherPosition = new Vector2(launcherPosition.x, referencePoint.transform.position.y);
		}

		gameObject.transform.position = launcherPosition;
	}

	void LaunchEnd ()
	{
		launchInProgress = false;
		gameObject.rigidbody2D.velocity = Vector2.zero;
		gameObject.rigidbody2D.AddForce((referencePoint.transform.position - gameObject.transform.position) * forceConstant);
	}
}
