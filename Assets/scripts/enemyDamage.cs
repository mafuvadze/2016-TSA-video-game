using UnityEngine;
using System.Collections;

public class enemyDamage : MonoBehaviour {

	public GameObject impactEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "enemy")
		{
			other.GetComponent<enemyHealth>().giveDamage(7);
			Instantiate(impactEffect, other.transform.position, other.transform.rotation);
			other.GetComponent<AudioSource>().Play ();
		}
	}
}
