using UnityEngine;
using System.Collections;

public class DisableGameObj : MonoBehaviour {

	public string object1, object2, object3;
	GameObject obj1, obj2, obj3;
	// Use this for initialization
	void Start () {
		obj1 = GameObject.Find (object1);
		obj2 = GameObject.Find (object2);
		obj3 = GameObject.Find (object3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (obj1 != null && obj2 != null && obj3 != null) {
				DestroyObject (obj1);
				DestroyObject (obj2);
				DestroyObject (obj3);
			}
		}
	}
}
