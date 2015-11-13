using UnityEngine;
using System.Collections;
/*
public class artifactPopup : MonoBehaviour {

	public Canvas popup;
	public bool playerThere;
	public Canvas commandCanvas;
	public Canvas commandCanvas2;
	public float lifetime;
	// Use this for initialization
	void Start () {
		popup.enabled = false;
		playerThere = false;
		commandCanvas.enabled = false;
		commandCanvas2.enabled = false;
		//lifetime = 5;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(commandCanvas.enabled == true)
		{
			lifetime -= Time.deltaTime;
		}
		if(lifetime < 0)
		{
			commandCanvas.enabled = false;
			commandCanvas2.enabled = true;
		}
		if(playerThere == true && Input.GetKey (KeyCode.X))
		{
			commandCanvas2.enabled = false;
			popup.enabled = true;
		}
	
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		playerThere = true;
		commandCanvas.enabled = true;
		
	}
	void OnTriggerExit2D (Collider2D other)
	{
		playerThere = false;
	}
	public void quit()
	{
		popup.enabled = false;
		Time.timeScale = 1f;


	}
	public void pause()
	{
		Time.timeScale = 0f;
	}

}
*/
