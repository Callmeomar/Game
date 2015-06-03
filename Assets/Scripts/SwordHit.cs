using UnityEngine;
using System.Collections;

public class SwordHit : MonoBehaviour 
{
	public SwordSwing swing;

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Enemy" && swing.isSwinging == true)
		{
			Destroy (other.gameObject);
		}
	}
}