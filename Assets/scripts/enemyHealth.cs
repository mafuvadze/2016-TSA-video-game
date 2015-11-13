using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {

	public int enemyHealthsys;
	public GameObject deathParticle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (enemyHealthsys <= 0) {
			Instantiate(deathParticle, transform.position, transform.rotation);
			Destroy (gameObject);
				}
	}
	public void giveDamage(int damageToGive)
	{
		enemyHealthsys -= damageToGive;
		GetComponent<AudioSource>().Play ();
	}
}
