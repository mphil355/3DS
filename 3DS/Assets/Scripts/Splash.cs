/* This code is property of ALLCAPS
 *  
 * Title : Splash.cs
 * Author : 
 * Contributors :   
 * Modified : 
 * Purpose: 				*/

using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour 
{
	private float randomZRotation;

	void Start()
	{
		randomZRotation = Random.Range(0, 90);
		transform.Rotate(new Vector3(0, 0, randomZRotation));
		Destroy(gameObject, .20f);
	}
}//end Splash.cs
