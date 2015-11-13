using UnityEngine;
using System.Collections;

public class endGame : MonoBehaviour {

	public float lifetime;
	public float lifetime2;
	public bool playerThere;
	public Canvas fingerPrint;
	public Canvas pressx;
	public Canvas bigReveal;
	public bool ending;
	public GameObject fadeSignal;
	public Canvas fadingC;

	// Use this for initialization
	void Start () {
		fadingC.enabled = false;
		ending = false;
		pressx.enabled = false;
		bigReveal.enabled = false;
		fingerPrint.enabled = false;
		lifetime = 4;
		lifetime2 = 21f;
		playerThere = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(lifetime2 < 11)
		{
			fadingC.enabled = true;
			Destroy(fadeSignal.gameObject);
		}

		if(playerThere && bigReveal.enabled == false)
		{
			fingerPrint.enabled = true;
			lifetime -= Time.deltaTime;
		}
		if(lifetime < 0 && bigReveal.enabled == false)
		{
			pressx.enabled = true;
			lifetime = 200f;
		}
		if(playerThere && Input.GetKey (KeyCode.X))
		{
			pressx.enabled = false;
			fingerPrint.enabled = false;
			bigReveal.enabled = true;
			ending = true;
		}
		if(ending)
		{
			lifetime2 -= Time.deltaTime;
		}

		if(lifetime2 < 0f)
		{
			Application.LoadLevel ("lastScene");
		}
	
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name == "player")
		{
			playerThere = true;
		}
	}

}
