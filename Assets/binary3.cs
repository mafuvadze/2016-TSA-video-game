using UnityEngine;
using System.Collections;

public class binary3 : MonoBehaviour {
	
	public bool playerThere;
	public static bool leverPulled3;
	private Animator anim;
	
	// Use this for initialization
	void Start () {
		playerThere = false;
		leverPulled3 = false;
		//anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("isPulled3", leverPulled3);

		binaryAnsdetector.l3 = leverPulled3;
		if(playerThere)
		{
			if(Input.GetKeyDown(KeyCode.X))
			{
				if(leverPulled3 == true)
				{
					leverPulled3 = false;
				}
				if(leverPulled3 == false)
				{
					leverPulled3 = true;
				}

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
			playerThere = false;
		}
	}
}
