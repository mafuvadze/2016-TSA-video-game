using UnityEngine;
using System.Collections;

public class floatingBoxes : MonoBehaviour {

	public int randomy;
	public int randomx;
	// Use this for initialization
	void Start () {
		randomy = Random.Range (-3, 3);
		randomx = Random.Range (-3, 3);
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y,randomy);
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,randomx);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
