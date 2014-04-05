using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {
	
	public GameObject target;
	public GameObject bullet;
	
	public float maxDistance;
	public float forceConstant;
	
	private bool attack;

	// Use this for initialization
	void Start () {
		attack = false;	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
			AttackBegin();
		if (Input.GetMouseButtonUp(0) || !Input.GetMouseButton(0) && attack )
			AttackEnded();
	}
	
	public void AttackBegin() {
		attack = true;
		//print ("clicked");
		bullet.rigidbody2D.gravityScale = 0;
		Vector3 launcherPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		launcherPosition = new Vector3(launcherPosition.x, launcherPosition.y, 0);
		
		float distance = Vector3.Distance(launcherPosition, target.transform.position);
		
		//Debug.Log(distance);
		if (distance > maxDistance) {
			launcherPosition = target.transform.position + Vector3.ClampMagnitude(launcherPosition - target.transform.position, maxDistance);
		}
		
		bullet.transform.position = launcherPosition;
	}
	
	public void AttackEnded() {
		attack = false;
		print ("released");
		bullet.rigidbody2D.velocity = Vector3.zero;
		bullet.rigidbody2D.gravityScale = 1;
		bullet.rigidbody2D.AddForce((target.transform.position - bullet.transform.position) * forceConstant);
	}
}
