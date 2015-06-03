using UnityEngine;
using System.Collections;

public class BossShot : MonoBehaviour 
{
	public float speed;
	
	void Start () 
	{
		gameObject.name = "BossShot";
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