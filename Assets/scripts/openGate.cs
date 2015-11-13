using UnityEngine;
using System.Collections;

public class openGate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2d (Collider other)
	{
		if(other.name == "player" )
		{
			transform.localScale = new Vector3 (1f,.2f, 1f);
		}
	}
	/*void OnTriggerExit2D( Collider other)
	{
		if(other.name == "player" )
		{
			transform.localScale = new Vector3 (1f,1f, 1f);
		}
	}*/
}
