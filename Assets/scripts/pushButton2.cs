using UnityEngine;
using System.Collections;

public class pushButton2 : MonoBehaviour {
	
	public GameObject laser;
	public bool boxOn;
	public bool player;
	public float position;
	public bool onTrue;
	public bool Activated;
	public Animator anim;
	// Use this for initialization
	void Start () {
		boxOn = false;
		player = false;
		onTrue = true;
		Activated = false;
		anim = GetComponent<Animator> ();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("laserOn", Activated);
		if (boxOn == onTrue) {
			laser.SetActive (false);
		} else {
			laser.SetActive(true);
		}
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "bcx")
		{
			boxOn = true;
			Activated = true;
		}
		laser.gameObject.SetActive(false);
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "box")
		{
			boxOn = false;
			Activated = false;
		}
		
	}
}
