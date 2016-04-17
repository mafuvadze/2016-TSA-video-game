using UnityEngine;
using System.Collections;

public class YearInputTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			GameManager.showSelector ();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			GameManager.hideSelector ();
		}
	}
}
