using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public Transform target;

	void FixedUpdate()
	{
		transform.position = new Vector3 (target.transform.position.x, 12.5f, -25f);
	}
}