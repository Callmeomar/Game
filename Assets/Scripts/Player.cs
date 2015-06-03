using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public int maxHealth;
	public int currentHealth;
	public int maxMana;
	public int currentMana;
	public static int physicalAttack;
	public static int physicalDefense;
	public static int magicalAttack;
	public static int magicalDefense;

	public float movementSpeed;
	public float jumpVelocity;
	public float hBarLength = 250f;
	public float mBarLength = 225f;

	public bool magic = false;

	public Texture2D charIconBord;
	public Texture2D healthBar;
	public Texture2D divideBar;
	public Texture2D manaBar;
	public Texture2D slot1Icon;
	public Texture2D slot2Icon;
	public Texture2D slot3Icon;
	public Texture2D slot4Icon;
	public Texture2D slot5Icon;
	public Texture2D slot1Icon2;
	public Texture2D slot2Icon2;
	public Texture2D slot3Icon2;
	public Texture2D slot4Icon2;
	public Texture2D slot5Icon2;
	public bool onGround = false;

	public GameObject bodyPivot;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	public bool slot1 = false;
	public bool slot2 = false;
	public bool slot3 = false;
	public bool slot4 = false;
	public bool slot5 = false;

	public SwordSwing swing;
	public bool swingUsed = false;

	public bool facingRight = true;

	public bool showProfile = false;
	public Texture2D profile;

	public bool showOptions = false;
	public Texture2D saveButton;
	public Texture2D settingsButton;
	public Texture2D quitButton;
	
	void OnGUI ()
	{
		GUI.DrawTexture (new Rect (10, 10, 75, 75), charIconBord, ScaleMode.StretchToFill, true, 0);
		GUI.DrawTexture (new Rect (100, 40, hBarLength, 15), healthBar, ScaleMode.StretchToFill, true, 0);
		GUI.DrawTexture (new Rect (100, 55, 300, 2.5f), divideBar, ScaleMode.StretchToFill, true, 0);
		GUI.DrawTexture (new Rect (100, 57.5f, mBarLength, 10), manaBar, ScaleMode.StretchToFill, true, 0);

		if (magic == true)
		{
			GUI.DrawTexture (new Rect (Screen.width / 2, (Screen.height / 2) + ((Screen.height / 2) - 75), 50, 50), slot3Icon, ScaleMode.StretchToFill, true, 0);
			GUI.DrawTexture (new Rect (Screen.width / 2 + 75, (Screen.height / 2) + ((Screen.height / 2) - 75), 50, 50), slot4Icon, ScaleMode.StretchToFill, true, 0);
			GUI.DrawTexture (new Rect (Screen.width / 2 + 150, (Screen.height / 2) + ((Screen.height / 2) - 75), 50, 50), slot5Icon, ScaleMode.StretchToFill, true, 0);
			GUI.DrawTexture (new Rect (Screen.width / 2 - 75, (Screen.height / 2) + ((Screen.height / 2) - 75), 50, 50), slot2Icon, ScaleMode.StretchToFill, true, 0);
			GUI.DrawTexture (new Rect (Screen.width / 2 - 150, (Screen.height / 2) + ((Screen.height / 2) - 75), 50, 50), slot1Icon, ScaleMode.StretchToFill, true, 0);
		}

		else
		{
			GUI.DrawTexture (new Rect (Screen.width / 2, (Screen.height / 2) + ((Screen.height / 2) - 75), 50, 50), slot3Icon2, ScaleMode.StretchToFill, true, 0);
			GUI.DrawTexture (new Rect (Screen.width / 2 + 75, (Screen.height / 2) + ((Screen.height / 2) - 75), 50, 50), slot4Icon2, ScaleMode.StretchToFill, true, 0);
			GUI.DrawTexture (new Rect (Screen.width / 2 + 150, (Screen.height / 2) + ((Screen.height / 2) - 75), 50, 50), slot5Icon2, ScaleMode.StretchToFill, true, 0);
			GUI.DrawTexture (new Rect (Screen.width / 2 - 75, (Screen.height / 2) + ((Screen.height / 2) - 75), 50, 50), slot2Icon2, ScaleMode.StretchToFill, true, 0);
			GUI.DrawTexture (new Rect (Screen.width / 2 - 150, (Screen.height / 2) + ((Screen.height / 2) - 75), 50, 50), slot1Icon2, ScaleMode.StretchToFill, true, 0);
		}

		if (showProfile == true)
		{
			GUI.DrawTexture (new Rect (100, 75, 256, 384), profile, ScaleMode.StretchToFill, true, 0);
		}

		if (showOptions == true)
		{
			GUI.DrawTexture (new Rect (Screen.width / 2 - 60, Screen.height / 2 - 100, 120, 50), saveButton, ScaleMode.StretchToFill, true, 0);
			GUI.DrawTexture (new Rect (Screen.width / 2 - 105, Screen.height / 2 - 25, 210, 50), settingsButton, ScaleMode.StretchToFill, true, 0);
			GUI.DrawTexture (new Rect (Screen.width / 2 - 60, Screen.height / 2 + 50, 120, 50), quitButton, ScaleMode.StretchToFill, true, 0);
		}
	}
	
	void Update ()
	{
		if (magic == false && Input.GetButtonDown ("Fire1") && swing.isSwinging == false)
		{
			if (swingUsed == false)
			{
				swing.Anticlockwise ();
			}
			if (swingUsed == true)
			{
				swing.Clockwise ();
			}
		}

		if (magic == true && Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}

		if (Input.GetKeyDown (KeyCode.A))
		{
			shotSpawn.rotation = Quaternion.Euler (0, 180, 0);
			bodyPivot.transform.rotation = Quaternion.Euler (0, 180, 0);
			facingRight = false;

			if (swingUsed == true)
			{
				swingUsed = false;
			}
		}
		
		if (Input.GetKeyDown (KeyCode.D))
		{
			shotSpawn.rotation = Quaternion.Euler (0, 0, 0);
			bodyPivot.transform.rotation = Quaternion.Euler (0, 0, 0);
			facingRight = true;

			if (swingUsed == true)
			{
				swingUsed = false;
			}
		}

		if (Input.GetKeyDown (KeyCode.Space) && onGround == true)
		{
			GetComponent<Rigidbody>().AddForce (0, jumpVelocity, 0, ForceMode.VelocityChange);
			onGround = false;
		}

		if (Input.GetKeyDown (KeyCode.LeftShift))
		{
			magic = !magic;
		}

		if (Input.GetKeyDown (KeyCode.Alpha1))
		{
			slot1 = true;
			slot2 = false;
			slot3 = false;
			slot4 = false;
			slot5 = false;
		}

		if (Input.GetKeyDown (KeyCode.Alpha2))
		{
			slot1 = false;
			slot2 = true;
			slot3 = false;
			slot4 = false;
			slot5 = false;
		}

		if (Input.GetKeyDown (KeyCode.Alpha3))
		{
			slot1 = false;
			slot2 = false;
			slot3 = true;
			slot4 = false;
			slot5 = false;
		}
		
		if (Input.GetKeyDown (KeyCode.Alpha4))
		{
			slot1 = false;
			slot2 = false;
			slot3 = false;
			slot4 = true;
			slot5 = false;
		}

		if (Input.GetKeyDown (KeyCode.Alpha5))
		{
			slot1 = false;
			slot2 = false;
			slot3 = false;
			slot4 = false;
			slot5 = true;
		}

		if (Input.GetKeyDown (KeyCode.P))
		{
			showProfile = !showProfile;
		}

		if (Input.GetKeyDown (KeyCode.Escape))
		{
			showOptions = !showOptions;
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
		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		//rigidbody.velocity = movement * movementSpeed;
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Ground")
		{
			onGround = true;
		}
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