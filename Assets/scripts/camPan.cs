using UnityEngine;
using System.Collections;

public class camPan : MonoBehaviour {
	public bool leverPulled;
	public bool playerThere;
	public Canvas pullMessage;
	public GameObject cam;
	private Animator anim;

	// Use this for initialization
	void Start () {
		leverPulled = false;
		pullMessage.enabled = false;
		anim = GetComponent<Animator> ();
		playerThere = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("leverPulled",leverPulled );
		if(leverPulled == true)
		{
			cam.SetActive(false);
		}if(playerThere)
		{
			if (Input.GetKeyDown (KeyCode.X))
			{
				leverPulled = true;
				pullMessage.enabled = false;
			}
		}

	}
	void OnTriggerEnter2D (Collider2D other)
	{

		if(other.name == "player")
		{
			playerThere = true;
			if(!leverPulled)
			{
				pullMessage.enabled = true;
			}
		}
	}
	void OnTriggerExit2D (Collider2D other)
	{
		if(other.name == "player")
		{
			playerThere = false;
			pullMessage.enabled = false;
		}
	}
}
