using UnityEngine;
using System.Collections;

public class PlayerShotBH : MonoBehaviour 
{
	public float speed;

	void Start () 
	{
		gameObject.name = "PlayerShot";
		GetComponent<Rigidbody>().velocity = transform.up * speed;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Wall")
		{
			Destroy(this.gameObject);
		}
	}
}