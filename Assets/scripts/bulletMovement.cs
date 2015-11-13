using UnityEngine;
using System.Collections;

public class bulletMovement : MonoBehaviour {
	
	public float speed;
	public player playerc;

	public GameObject enemyDeathEffect;
	public GameObject impactEffect;
	public int damageToGive;
	public bool enemyDead;
	public GameObject drop;
	public static float enemyX;
	public static float enemyY;



	// Use this for initialization
	void Start () {
		enemyDead = false;
		playerc = FindObjectOfType<player> ();
		if(playerc.transform.localScale.x >0)
		   speed = -speed;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (enemyDead);
		GetComponent<Rigidbody2D>().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D>().velocity.y);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "protected")
		{
			Instantiate (impactEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		}
		if(other.tag != "protect")
		{
			enemyX = other.transform.localScale.x;
			enemyY = other.transform.localScale.y;
			other.transform.localScale = new Vector3 (.75f*enemyX, .75f*enemyY, 1f);
		}
		if(other.tag == "wall")
		{
			other.transform.localScale = new Vector3(1f,1f,1f);
			//Destroy(other.gameObject);
		}
		if(other.tag == "enemy" && other.tag != "ground" && other.tag != "wall" && other.tag != "unshrinkable")
		{
			if(other.tag != "protect")
			{
				other.GetComponent<enemyPatrol>().enemySize = (other.GetComponent<enemyPatrol>().enemySize) - .1f;
				if(other.GetComponent<enemyPatrol>().enemySize < .3f);
			}//Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy (other.gameObject);
		
			{
				//other.GetComponent<enemyPatrol>().enemySize = (other.GetComponent<enemyPatrol>().enemySize) - .15f;
				enemyDead = true;
				if(Application.loadedLevelName == "level06")
				{
					Instantiate(drop, other.transform.position, other.transform.rotation);
				}
				Destroy (other.gameObject);

			}

		}
		Instantiate (impactEffect, transform.position, transform.rotation);
		gameObject.SetActive (false);
		StartCoroutine ("Wait");
		//Destroy (gameObject);
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds (3);
		Destroy (gameObject);
	}
}
