using UnityEngine;
using System.Collections;

public class killPlayer : MonoBehaviour {

	public levelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<levelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "player")
		    {
			healthManager.HurtPlayer(100);
		}
	}
}
