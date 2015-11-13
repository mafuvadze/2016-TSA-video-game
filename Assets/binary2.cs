using UnityEngine;
using System.Collections;

public class binary2 : MonoBehaviour {
	
	public bool playerThere;
	public static bool leverPulled2;
	private Animator anim;
	
	// Use this for initialization
	void Start () {
		playerThere = false;
		leverPulled2 = false;
	anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("isPulled2", leverPulled2);

		binaryAnsdetector.l2 = leverPulled2;
		if(playerThere)
		{
			if(Input.GetKeyDown(KeyCode.X))
			{
				if(leverPulled2 == true)
				{
					leverPulled2 = false;
				}
				if(leverPulled2 == false)
				{
					leverPulled2 = true;
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
