using UnityEngine;
using System.Collections;

public class pushButton : MonoBehaviour {

	public GameObject laser;
	public bool boxOn;
	public bool player;
	public GameObject box;
	public float position;
	public bool laserOn;
	public Animator anim;
	// Use this for initialization
	void Start () {
		boxOn = false;
		player = false;
		laserOn = true;
		anim = GetComponent<Animator> ();
	
		
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("laserOn", laserOn);
		position = box.transform.position.x;
		if(boxOn || player)
		{
			laser.gameObject.SetActive(false);
			laserOn = false;
		}
		else
		{
			laser.gameObject.SetActive(true);
			laserOn = true;
		}
		if(-65.8 < Mathf.RoundToInt(position) && -62.12 > Mathf.RoundToInt(position))
		{
			laser.gameObject.SetActive(false);
			laserOn = false;
		}
		else{
			if(!player)
			{
				laser.gameObject.SetActive(true);
				laserOn = true;
			}

		}
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "bcx")
		{
			boxOn = true;
		}
		if(other.name == "player")
		{
			player = true;
		}

		laser.gameObject.SetActive(false);
		laserOn = false;
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "box")
		{
			boxOn = false;
		}
		if(other.name == "player")
		{
			player = false;
		}


	}
}
