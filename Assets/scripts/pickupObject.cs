using UnityEngine;
using System.Collections;

public class pickupObject : MonoBehaviour {
	
	//public Canvas pickup;
	public GameObject enemy;
	public GameObject artifact;
	public static bool gone;
	//public Canvas popupAfter;
	
	// Use this for initialization
	void Start () {
		//pickup.enabled = false;
		//popupAfter.enabled = false;
		gone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.X))
		{
			//pickup.enabled = false;
		}
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "player")
		{
			Debug.Log("player there");
			gone = true;
			//popupAfter.enabled = true;
			Destroy(gameObject);
			//pickup.enabled = true;

		}

	}

}

