using UnityEngine;
using System.Collections;

public class SendPlayerBackInTime : MonoBehaviour {

	public bool BackInTime;

	// Use this for initialization
	void Start () {
		BackInTime = false;
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "player") {
			reverseTime.GoBackInTime = true;


		}
	}
}
