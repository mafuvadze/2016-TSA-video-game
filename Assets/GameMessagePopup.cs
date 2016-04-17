using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class GameMessagePopup : MonoBehaviour {

	bool shown;
	SequenceData data;
	// Use this for initialization
	void Start () {
		data = new SequenceData ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && !shown) {
			GameManager.displayGameMessage (data.guess);
			shown = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			shown = false;
			GameManager.hideGameMsgCanvas ();
		}
	}
}
