using UnityEngine;
using System.Collections;

public class DisableGameObj : MonoBehaviour {

	public string object1, object2;
	GameObject obj1, obj2;
	// Use this for initialization
	void Start () {
		obj1 = GameObject.Find (object1);
		obj2 = GameObject.Find (object2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (obj1 != null && obj2 != null) {
				DestroyObject (obj1);
				DestroyObject (obj2);
			}
		}
	}
}
