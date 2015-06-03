using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour 
{
	public float speed;

	public GameObject shot;
	public Transform shotSpawn90;
	public Transform shotSpawn120;
	public Transform shotSpawn150;
	public Transform shotSpawn180;
	public Transform shotSpawn210;
	public Transform shotSpawn240;
	public Transform shotSpawn270;

	public Transform waypoint;
	public bool move = false;

	void Start () 
	{
		InvokeRepeating ("Phase1", 1, 0.125f);
		StartCoroutine (MoveToWaypoint ());
	}

	void Update ()
	{
		if (move == true)
		{
			transform.position = Vector3.Slerp (transform.position, waypoint.transform.position, Time.deltaTime * speed);
		}
	}

	void Phase1 ()
	{
		Instantiate (shot, shotSpawn90.position, shotSpawn90.rotation);
		Instantiate (shot, shotSpawn120.position, shotSpawn120.rotation);
		Instantiate (shot, shotSpawn150.position, shotSpawn150.rotation);
		Instantiate (shot, shotSpawn180.position, shotSpawn180.rotation);
		Instantiate (shot, shotSpawn210.position, shotSpawn210.rotation);
		Instantiate (shot, shotSpawn240.position, shotSpawn240.rotation);
		Instantiate (shot, shotSpawn270.position, shotSpawn270.rotation);
	}

	IEnumerator MoveToWaypoint ()
	{
		yield return new WaitForSeconds (3);
		move = true;
	}
}