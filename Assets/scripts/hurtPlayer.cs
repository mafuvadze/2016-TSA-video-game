using UnityEngine;
using System.Collections;

public class hurtPlayer : MonoBehaviour {

	public int damageToGive;
	public Canvas redScreen;
	public float lifetime;
	// Use this for initialization
	void Start () {
		redScreen.enabled = false;
		lifetime = 1.5f;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(redScreen.enabled == true)
		{
			lifetime -= Time.deltaTime;
			if(lifetime < 0)
			{
				redScreen.enabled = false;
				lifetime = 1.5f;
			}
		}
		if(gameObject == null)
		{
			Debug.Log ("enemy Dead");
			redScreen.enabled = false;
		}

		}
	healthManager hm = new healthManager();
		void OnTriggerEnter2D(Collider2D other)
		{
			if(other.name == "player")
			{
				redScreen.enabled = true;
				hm.hurt = true;
				healthManager.HurtPlayer(damageToGive);
				other.GetComponent<AudioSource>().Play();
			}
		}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.name == "player")
		{
			redScreen.enabled = false;
		}
	}
}
