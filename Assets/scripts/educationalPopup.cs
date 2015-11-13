using UnityEngine;
using System.Collections;

public class educationalPopup : MonoBehaviour {

	public Canvas educationPopup;


	// Use this for initialization
	void Start () {
		educationPopup.enabled = false;
		if (Application.loadedLevelName == "level01") 
		{
			PlayerPrefs.SetInt ("collected", 0);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Cancel"))
		{
			Time.timeScale = 1f;
			educationPopup.enabled = false;
			if(gameObject.tag != "protect")
				Destroy (gameObject);
			
		}
	
	}
	public void Unpaused()
	{
		Time.timeScale = 1f;
		educationPopup.enabled = false;
		if(gameObject.tag != "protected")
			Destroy (gameObject);

	}

	public void Pause()
	{
		if(gameObject.tag != ("protect"))
		{
			int col = PlayerPrefs.GetInt("collected");
			PlayerPrefs.SetInt("collected", col + 1);
		}
		Time.timeScale = 0f;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "player")
		{
			educationPopup.enabled = true;
			Pause();

		}

	}

}
