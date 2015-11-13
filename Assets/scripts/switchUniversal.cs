using UnityEngine;
using System.Collections;

public class switchUniversal : MonoBehaviour {
	public bool playerThere = false;
	public Canvas interact;
	public bool pulled = false;
	public GameObject barrier;
	public GameObject barrier2;
	public Animator anim;
	// Use this for initialization
	void Start () {
		interact.enabled = false;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("isPulled", pulled );
		if (playerThere && !pulled) {
			interact.enabled = true;
			if(Input.GetKeyDown(KeyCode.X))
			{
				pulled = pulled == false ? true:false;
			}
		}
		if (pulled) {
			interact.enabled = false;
			barrier.SetActive(false);
			barrier2.SetActive(false);
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
