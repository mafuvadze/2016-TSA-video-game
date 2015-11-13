using UnityEngine;
using System.Collections;

public class ladderZone : MonoBehaviour {

	private player thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<player> ();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name  == "player")
		{
			thePlayer.onLadder = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.name  == "player")
		{
			thePlayer.onLadder = false;
		}
	}
}
