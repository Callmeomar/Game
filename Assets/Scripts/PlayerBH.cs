using UnityEngine;
using System.Collections;

public class PlayerBH : MonoBehaviour 
{
	public int maxHealth;
	public int currentHealth;
	public int maxMana;
	public int currentMana;

	public float movementSpeed;
	public float hBarLength = 250f;
	public float mBarLength = 225f;

	public GameObject shot;
	public Transform shotSpawnLeft;
	public Transform shotSpawnMid;
	public Transform shotSpawnRight;
	public float fireRate;
	private float nextFire;

	public Texture2D charIconBord;
	public Texture2D healthBar;
	public Texture2D divideBar;
	public Texture2D manaBar;

	void OnGUI ()
	{
		GUI.DrawTexture (new Rect (10, 10, 75, 75), charIconBord, ScaleMode.StretchToFill, true, 0);
		GUI.DrawTexture (new Rect (100, 40, hBarLength, 15), healthBar, ScaleMode.StretchToFill, true, 0);
		GUI.DrawTexture (new Rect (100, 55, 300, 2.5f), divideBar, ScaleMode.StretchToFill, true, 0);
		GUI.DrawTexture (new Rect (100, 57.5f, mBarLength, 10), manaBar, ScaleMode.StretchToFill, true, 0);
	}

	void Update () 
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawnLeft.position, shotSpawnLeft.rotation);
			Instantiate(shot, shotSpawnMid.position, shotSpawnMid.rotation);
			Instantiate(shot, shotSpawnRight.position, shotSpawnRight.rotation);
		}

		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D))
		{
			movementSpeed = 20;
		}
		else
		{
			movementSpeed = 0;
		}

		AdjustBars ();
	}

	void FixedUpdate ()
	{

		float moveHorizontal = Input.GetAxis ("Horizontal") * movementSpeed;
		float moveVertical = Input.GetAxis ("Vertical") * movementSpeed;
		
		moveHorizontal *= Time.deltaTime;
		moveVertical *= Time.deltaTime;
		
		transform.Translate (moveHorizontal, 0, 0);
		transform.Translate (0, 0, moveVertical);
	}

	public void AdjustBars ()
	{
		
		if (currentHealth < 0)
		{
			currentHealth = 0;
		}
		
		if (currentMana < 0)
		{
			currentMana = 0;
		}
		
		if (currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}
		
		if (currentMana > maxMana)
		{
			currentMana = maxMana;
		}
		
		if (maxHealth < 1)
		{
			maxHealth = 1;
		}
		
		if (maxMana < 1)
		{
			maxMana = 1;
		}
		
		hBarLength = 250 * (currentHealth / (float)maxHealth);
		
		mBarLength = 225 * (currentMana / (float)maxMana);
	}
}