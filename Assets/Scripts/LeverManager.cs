using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class LeverManager : MonoBehaviour {
	
	GameObject lever;
	public static LeverManager instance;

	void Awake() {
		instance = this;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static SpriteRenderer getLever(string name){
		GameObject obj = GameObject.Find (name);
		SpriteRenderer lever = obj.gameObject.GetComponentInChildren<SpriteRenderer> ();
		return lever;
	}

	public static void toggleLever (SpriteRenderer lever, string opens){	
		if (lever.sprite == Media.getImage ("lever_up")) {
			lever.sprite = Media.getImage ("lever_down");
			closeDoor (opens);
		} else {
			lever.sprite = Media.getImage ("lever_up");
			openDoor (opens);
		}
	}
		
	public static void openDoor(string name){
		GameObject obj = GameObject.Find (name);
		if (obj != null) {
			obj.BroadcastMessage ("open");
		}
	}

	public static void closeDoor (string name){
		GameObject obj = GameObject.Find (name);
		if (obj != null) {
			obj.BroadcastMessage ("close");
		}	}
}
