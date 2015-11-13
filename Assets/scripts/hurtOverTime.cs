using UnityEngine;
using System.Collections;

public class hurtOverTime : MonoBehaviour {

	public int damageToGive;
	public float lifetime;
	public bool playerIn;
	public LayerMask whatIsPlayer;
	public Transform lavaChild;
	public Canvas redSceen;
	public float lifetime2;
	public Transform player;
	public float distance;
	public float distanceValue;

	// Use this for initialization
	void Start () {
		damageToGive = 20;
		playerIn = false;
		lifetime = .7f;
		lifetime2 = .4f;
		redSceen.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		playerIn = Physics2D.OverlapCircle (lavaChild.position, 1, whatIsPlayer);
		if (playerIn) 
		{
			redSceen.enabled = true;
			lifetime -= Time.deltaTime;
		}
		if(!playerIn)
		{
			lifetime = .7f;
		}
		healthManager hm = new healthManager ();
		if(lifetime < 0)
		{
			redSceen.enabled = true;
			hm.hurt = true;
			healthManager.HurtPlayer(damageToGive);
			GetComponent<AudioSource>().Play();
			lifetime = 1f;
				
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "player")
		{
			redSceen.enabled = true;
			
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.name == "player")
		{
			redSceen.enabled = false;
			
		}
	}

}
