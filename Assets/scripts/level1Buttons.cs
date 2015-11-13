using UnityEngine;
using System.Collections;

public class level1Buttons : MonoBehaviour {

	public Texture buttonTextureExit;

	void onGUI()
	{
		if(GUI.Button (new Rect(Screen.width * .2f, Screen.height * .2f, Screen.width * .5f, Screen.height * .1f),buttonTextureExit,""))
		{
			print("Exit Button Clicked");
			Application.LoadLevel ("mainMenu");
		}
	}
}
