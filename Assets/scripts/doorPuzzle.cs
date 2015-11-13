using UnityEngine;
using System.Collections;

public class doorPuzzle : MonoBehaviour {
	public GameObject open;
	public GameObject close;
	public Canvas message;
	public bool playerThere;
	public bool leverPulled;
	public Animator anim;
	// Use this for initialization
	void Start () {
		message.enabled = false;
		playerThere = false;
		leverPulled = false;
		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("leverPulled", leverPulled);
		if(playerThere)
		{
			message.enabled = true;
		}
		else{
			message.enabled = false;
		}
		if(playerThere && Input.GetKey(KeyCode.X))
		{
			leverPulled = !leverPulled;
		}
		if(leverPulled)
		{
			open.SetActive(false);
			close.SetActive(true);
		}else{
		open.SetActive(true);
		close.SetActive(true);
		}
		/*if(playerThere && Input.GetKey(KeyCode.X) && leverPulled)
		{
			open.SetActive(true);
			close.SetActive(false);
			leverPulled = false;
		}
		*/

	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name == "player")
		{
			playerThere = true;
		}
	}
	void OnTriggerExit2D (Collider2D other)
	{
		if(other.name == "player")
		{
			playerThere = false;
		}
	}
}
