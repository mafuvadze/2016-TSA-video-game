using UnityEngine;
using System.Collections;

public class camSiren : MonoBehaviour {
	public GameObject siren;
	public float lifetime;
	public GameObject enemy;
	public Canvas redScreen;
	public bool alarm;
	public Canvas message;
	public GameObject enemyRespawnPoint;
	public float lifetime2;

	// Use this for initialization
	void Start () {
		lifetime2 = 5f;
		siren.SetActive (false);
		lifetime = 12;
		alarm = false;
		message.enabled = false;
		enemy.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(alarm)
		{
			lifetime -= Time.deltaTime;
			enemy.SetActive(true);
			message.enabled = true;
			lifetime -= Time.deltaTime;
			//redScreen.enabled = true;
			if(lifetime < 0)
			{
				siren.SetActive(false);
				redScreen.enabled = false;
				alarm = false;
			}
			if(!alarm)
			{
				message.enabled = false;
			}
			if(lifetime2 < 0)
			{
				message.enabled = false;
			}
		}


	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("in");
		if(other.name == "player")
		{
			siren.SetActive(true);
			alarm = true;
		}
	}
}
