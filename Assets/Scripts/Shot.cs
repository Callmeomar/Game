using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour 
{
	public float speed;

	void Start () 
	{
		gameObject.name = "BaseMagiShot";
		GetComponent<Rigidbody>().velocity = transform.right * speed;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.name == "Cube")
		{
			GetComponent<Rigidbody>().velocity = transform.right * 0;
			gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;

			foreach (Transform child in gameObject.transform)
			{
				child.gameObject.SetActive(true);
			}
			StartCoroutine (OnHit ());
		}
	}

	IEnumerator OnHit ()
	{
		yield return new WaitForSeconds (1);
		Destroy(gameObject);
	}
}