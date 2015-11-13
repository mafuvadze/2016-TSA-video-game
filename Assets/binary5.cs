using UnityEngine;
using System.Collections;

public class binary5: MonoBehaviour {
	
	public bool playerThere;
	public bool leverPulled;
	
	// Use this for initialization
	void Start () {
		playerThere = false;
		leverPulled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(playerThere)
		{
			if(Input.GetKeyDown(KeyCode.X))
			{
				leverPulled = !leverPulled;
			}
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "player")
		{
			playerThere = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.name == "player")
		{
			
		}
	}
}
