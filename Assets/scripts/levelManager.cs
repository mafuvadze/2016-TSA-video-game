using UnityEngine;
using System.Collections;

public class levelManager : MonoBehaviour {

	public GameObject currentCheckpoint;
	private player player;
	public GameObject arm;

	public GameObject deathParticle;
	public GameObject respawnParticle;

	public float respawnDelay;

	public healthManager healthManager;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<player> ();
		//arm = FindObjectOfType<player> ();
		healthManager = FindObjectOfType<healthManager> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void RespawnPlayer()
	{
		StartCoroutine ("RespawnPlayerCo");
	}
	public IEnumerator RespawnPlayerCo()
	{
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		arm.SetActive (false);
		player.GetComponent<Renderer>().enabled = false;
		arm.GetComponent<Renderer>().enabled = false;
		Debug.Log ("PlayerRespawn");
		yield return new WaitForSeconds (respawnDelay);
		player.transform.position = currentCheckpoint.transform.position;
		player.enabled = true;
		arm.SetActive (true);
		player.GetComponent<Renderer>().enabled = true;
		arm.GetComponent<Renderer>().enabled = true;
		healthManager.playerHealth += Random.Range(2,5) * 20;
		healthManager.isDead = false;
		//healthManager.hearts5.enabled = true;
		Instantiate (respawnParticle, player.transform.position, player.transform.rotation);
	}
}
