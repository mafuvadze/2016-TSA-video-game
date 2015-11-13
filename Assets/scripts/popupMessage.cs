using UnityEngine;
using System.Collections;

public class popupMessage : MonoBehaviour {

	public Canvas popUp;

	// Use this for initialization
	void Start () {
		popUp.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name == "player")
		{
			popUp.enabled = true;
		}
	}
	void OnTriggerExit2D (Collider2D other)
	{
		if(other.name == "player")
		{
			popUp.enabled = false;
		}
	}
}
