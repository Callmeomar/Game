using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour 
{
	public static Settings gameSettings;

	void Awake () 
	{
		if (gameSettings == null)
		{
			DontDestroyOnLoad (gameObject);
			gameSettings = this;
		}
		else if (gameSettings != this)
		{
			Destroy(gameObject);
		}
	}

	public float musicVolume = 0.5f;
	public float sfxVolume = 0.5f;

	public GameObject back;
	public GameObject cover;
	
	void OnGUI ()
	{
		musicVolume = GUI.HorizontalSlider (new Rect(Screen.width / 2 - 300, Screen.height / 2 - 75, 100, 10), musicVolume, 0.00f, 1.00f);
		sfxVolume = GUI.HorizontalSlider (new Rect(Screen.width / 2 - 300, Screen.height / 2 + 50, 100, 10), sfxVolume, 0.00f, 1.00f);
	}
	/*
	void Update ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) 
		{
			switch (hit.collider.name)
			{
			case ("Back"):
				back.SetActive (true);
				if (!scrollHasPlayed)
				{
					audio.PlayOneShot (scroll);
					scrollHasPlayed = true;
				}
				if (Input.GetButton ("Fire1"))
				{
					StartCoroutine (OnClick ());
				}
				break;
			case ("InstBool Off"):
				if (Input.GetButtonDown("Fire1"))
				{
					instBoolOn.SetActive (true);
					GameObject data = GameObject.Find ("GameData");
					if (data != null)
					{
						DataRelations dataRelations = data.GetComponent<DataRelations> ();
						dataRelations.showInstructions = true;
					}
				}
				break;
			case ("InstBool On"):
				if (Input.GetButtonDown ("Fire1"))
				{
					instBoolOn.SetActive (false);
					GameObject data = GameObject.Find ("GameData");
					if (data != null)
					{
						DataRelations dataRelations = data.GetComponent<DataRelations> ();
						dataRelations.showInstructions = false;
					}
				}
				break;
			case ("TimeBool Off"):
				if (Input.GetButtonDown ("Fire1"))
				{
					timeBoolOn.SetActive (true);
					GameObject data = GameObject.Find ("GameData");
					if (data != null)
					{
						DataRelations dataRelations = data.GetComponent<DataRelations> ();
						dataRelations.showTimer = true;
					}
				}
				break;
			case ("TimeBool On"):
				if (Input.GetButtonDown ("Fire1"))
				{
					timeBoolOn.SetActive (false);
					GameObject data = GameObject.Find ("GameData");
					if (data != null)
					{
						DataRelations dataRelations = data.GetComponent<DataRelations> ();
						dataRelations.showTimer = false;
					}
				}
				break;
			default:
				confirm.SetActive (false);
				back.SetActive (false);
				scrollHasPlayed = false;
				break;
			}
		}
	}
	
	IEnumerator OnClick ()
	{
		audio.PlayOneShot (confirmClick);
		cover.SetActive (true);
		yield return new WaitForSeconds (0.175f);
		Application.LoadLevel ("Main Menu");
	}
	*/
}