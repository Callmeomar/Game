using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public Texture2D continueUnSel;
	public Texture2D newGameUnSel;
	public Texture2D settingsUnSel;
	public Texture2D quitUnSel;

	public Texture2D continueSel;
	public Texture2D newGameSel;
	public Texture2D settingsSel;
	public Texture2D quitSel;
	
	public Texture2D continueHolder;
	public Texture2D newGameHolder;
	public Texture2D settingsHolder;
	public Texture2D quitHolder;

	void OnGUI ()
	{
		Rect continueBtn = new Rect (Screen.width / 2 + 75, Screen.height / 2, 320, 50);
		Rect newGameBtn = new Rect (Screen.width / 2 + 25, Screen.height / 2 + 75, 320, 50);
		Rect settingsBtn = new Rect (Screen.width / 2 - 50, Screen.height / 2 + 150, 320, 50);
		Rect quitBtn = new Rect (Screen.width / 2 - 125, Screen.height / 2 + 225, 320, 50);

		GUI.DrawTexture (continueBtn, continueHolder, ScaleMode.StretchToFill, true, 0);
		GUI.DrawTexture (newGameBtn, newGameHolder, ScaleMode.StretchToFill, true, 0);
		GUI.DrawTexture (settingsBtn, settingsHolder, ScaleMode.StretchToFill, true, 0);
		GUI.DrawTexture (quitBtn, quitHolder, ScaleMode.StretchToFill, true, 0);

		if (continueBtn.Contains (Event.current.mousePosition))
		{
			continueHolder = continueSel;
			if (Input.GetButtonDown ("Fire1"))
			{
				Application.LoadLevel ("level");
			}
		}
		else
		{
			continueHolder = continueUnSel;
		}

		if (newGameBtn.Contains (Event.current.mousePosition))
		{
			newGameHolder = newGameSel;
		}
		else
		{
			newGameHolder = newGameUnSel;
		}

		if (settingsBtn.Contains (Event.current.mousePosition))
		{
			settingsHolder = settingsSel;
		}
		else
		{
			settingsHolder = settingsUnSel;
		}

		if (quitBtn.Contains (Event.current.mousePosition))
		{
			quitHolder = quitSel;
		}
		else
		{
			quitHolder = quitUnSel;
		}
	}
}