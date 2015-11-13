using UnityEngine;
using System.Collections;

public class binaryPuzzle : MonoBehaviour {

	public bool playerThere;
	public static bool leverPulled1;
	private Animator anim;
	// Use this for initialization
	void Start () {
		playerThere = false;
		leverPulled1 = true;
		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("lever one is: " + leverPulled1);
		anim.SetBool ("isPulled1", leverPulled1);
		//binaryAnsdetector.l1 = leverPulled1;
		if (Input.GetKeyDown (KeyCode.X) && playerThere == true) {
			if(leverPulled1 == true)
			{
				leverPulled1 = false;
			}
			if(leverPulled1 == false)
			{
				leverPulled1 = true;
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
