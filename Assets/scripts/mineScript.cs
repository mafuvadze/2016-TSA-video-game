using UnityEngine;
using System.Collections;

public class mineScript : MonoBehaviour {

	public Animator anim;
	public bool playerHurt;
	public bool startAnimation;
	public float lifetime;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		playerHurt = false;
		startAnimation = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("boom", startAnimation );
		if(playerHurt)
		{
			startAnimation = true;
			lifetime -= Time.deltaTime;
		}
		if(lifetime < 0)
		{
			startAnimation = false;
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "player")
		{
			playerHurt = true;

		}
	}

}
