using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Lever : MonoBehaviour {

	SequenceData data;
	bool disable, playerPresent;
	SpriteRenderer renderer;
	public string name, opens;
	// Use this for initialization
	void Start () {
		data = new SequenceData ();
		disable = false;
		renderer = gameObject.GetComponentInChildren<SpriteRenderer> ();

		//workaround to get rung on left to open normally
		if (opens.Equals ("Rung") || opens.Equals("PlatformR")) {
			LeverManager.toggleLever (renderer, opens);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (playerPresent) {
			toggleListener ();
		}
	}

	public void toggleListener(){
		if (Input.GetKeyDown (KeyCode.X)) {
			LeverManager.toggleLever (renderer, opens);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && !disable) {
			GameManager.displayGameMessage (data.lever);
			disable = true;
			playerPresent = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			disable = false;
			playerPresent = false;
			GameManager.hideGameMsgCanvas ();
		}
	}
}
