using UnityEngine;
using System.Collections;

public class enemyBulletMovement : MonoBehaviour {
	
	public static float speed;
	public player playerc;
	
	public GameObject enemyDeathEffect;
	public GameObject impactEffect;
	public int damageToGive;
	
	
	
	// Use this for initialization
	void Start () {
				playerc = FindObjectOfType<player> ();
		}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D>().velocity.y);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "enemy")
		{
			//Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy (other.gameObject);
			other.GetComponent<enemyPatrol>().enemySize = (other.GetComponent<enemyPatrol>().enemySize) - .1f;
			if(other.GetComponent<enemyPatrol>().enemySize <= .2f)
			{
				Destroy (other.gameObject);
			}
			
		}
		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
