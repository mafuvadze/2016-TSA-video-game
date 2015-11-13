using UnityEngine;
using System.Collections;

public class teleportDoor : MonoBehaviour {

	public bool playerAtElevator;
	public GameObject teleportLocation;
	public GameObject player;
	public GameObject arm;
	public GameObject gun;
	public Canvas teleport;
	public GameObject TeleportEffect;

	// Use this for initialization
	void Start () {
		playerAtElevator = false;
		teleport.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(playerAtElevator)
		{
			if(Input.GetKey (KeyCode.X))
			{
				teleportingDoor();
			}
		}
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
			if (other.name == "player") 
			{
			teleport.enabled = true;
				playerAtElevator = true;
			}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "player") 
		{
			teleport.enabled = false;
			playerAtElevator = false;
		}
	}
	public void teleportingDoor()
	{
		StartCoroutine ("RespawnPlayerCo");
	}
	public IEnumerator RespawnPlayerCo()
	{
		player.GetComponent<Renderer>().enabled = false;
		arm.GetComponent<Renderer>().enabled = false;
		gun.GetComponent<Renderer>().enabled = false;
		Instantiate(TeleportEffect, player.transform.position, player.transform.rotation);
		yield return new WaitForSeconds (1.5f);
		player.transform.position = teleportLocation.transform.position;
		//Instantiate(TeleportEffect, player.transform.position, player.transform.rotation);
		player.GetComponent<Renderer>().enabled = true;
		arm.GetComponent<Renderer>().enabled = true;
		gun.GetComponent<Renderer>().enabled = true;

	}
}
