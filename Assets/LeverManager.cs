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
			if (opens.StartsWith ("Platform")) {

			} else {
				closeDoor (opens);
			}
		} else {
			lever.sprite = Media.getImage ("lever_up");
			if (opens.StartsWith ("Platform")) {
				lower (opens);
			} else {
				openDoor (opens);
			}
		}
	}

	public static void lower(string name){
		GameObject obj = GameObject.Find (name);
		Rigidbody2D body = obj.GetComponentInChildren<Rigidbody2D> ();
		instance.lowerWorkAround(obj, body);
	}

	public void lowerWorkAround(GameObject obj, Rigidbody2D body){
		StartCoroutine (startLowering(obj, body));	
	}

	IEnumerator startLowering(GameObject obj, Rigidbody2D body){
		while(obj.gameObject.transform.position.y > -14.78f){
			body.velocity = new Vector2(body.velocity.x, -.4f);
			yield return new WaitForSeconds (.015f);
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
