using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {
	SpriteRenderer renderer;
	BoxCollider2D collider;
	// Use this for initialization
	void Start () {
		renderer = gameObject.GetComponentInChildren<SpriteRenderer> ();
		collider = gameObject.GetComponentInChildren<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void open(){
		renderer.enabled = true;
		collider.enabled = true;
	}

	public void close(){
		renderer.enabled = false;
		collider.enabled = false;
	}
}
