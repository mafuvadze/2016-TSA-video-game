using UnityEngine;
using System.Collections;

public class hurtPlayer2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	healthManager hm = new healthManager();
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name == "player")
		{
			if(tag == "boss")
			{
				hm.hurt = true;
				healthManager.HurtPlayer(20);
				other.GetComponent<AudioSource>().Play();
			}
			else{
		hm.hurt = true;
			healthManager.HurtPlayer(20);
			other.GetComponent<AudioSource>().Play();
				}
		}
	}
}
