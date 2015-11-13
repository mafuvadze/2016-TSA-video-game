using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pauseEffect : MonoBehaviour {

	public Canvas pauseMenu;
	public static bool isPaused;

	// Use this for initialization
	void Start () {
		pauseMenu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Fire1")) 
		{
			if(!isPaused)
			{
				//pPause();
			}
			else if(isPaused)
			{
				//pUnpaused();
			}
		}


	
	}
	public void pPause()
	{
		if (pauseMenu.enabled = true) {
						pauseMenu.enabled = true;
						isPaused = true;
						Time.timeScale = 0f;
				}
	}
	public void pUnpaused()
	{
		if(pauseMenu.enabled = true)
		{
			pauseMenu.enabled = false;
			isPaused = false;
			Time.timeScale = 1f;
		}
	}
	public void quit()
	{
		if(pauseMenu.enabled == true)
		{
			pUnpaused ();
			Application.LoadLevel ("mainMenu");
		}

	}
}
