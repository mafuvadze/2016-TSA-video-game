using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {
	
	//public Canvas loadingScreen;
	public float lifetime;
	public bool startNextLevel;

	void Start () 
	{
		//loadingScreen.enabled = false;
		startNextLevel = false;
	}
	void Update ()
	{
		if(lifetime < 0)
		{
			Application.LoadLevel ("level01");
		}


	}

	public void playClicked()
	{
		Application.LoadLevel ("openingMessage");
		lifetime = 3;
		lifetime -= Time.deltaTime;	
		print("Play Button Clicked");
		//loadingScreen.enabled = true;

	}
	public void quit()
{
		Application.Quit ();
}
public void credits()
{
		print ("Credits Button Clicked");
}
}
