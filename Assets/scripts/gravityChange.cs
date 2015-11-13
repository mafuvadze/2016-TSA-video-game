using UnityEngine;
using System.Collections;

public class gravityChange : MonoBehaviour {

	public GameObject player;
	public int gravity;
	private Rigidbody2D myrigidbody2D;


	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "player")
		{
			myrigidbody2D = other.GetComponent<Rigidbody2D> ();
			myrigidbody2D.gravityScale = gravity;
		}
		if (other.tag == "box")
		{
			other.GetComponent<Rigidbody2D>().gravityScale = 4;
		}
	}
}
