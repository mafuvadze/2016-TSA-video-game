using UnityEngine;
using System.Collections;

public class ending : MonoBehaviour {
	public GameObject enemy1;
	public GameObject enemy2;
	public bool playerThere;

	public GameObject music;

	public Canvas message1;
	public Canvas message2;
	public Canvas message3;
	public Canvas message4;
	public Canvas endingFade;

	public float lifetime1;
	public float lifetime2;
	public float lifetime3;
	public float lifetime4;
	public float lifetime5;


	// Use this for initialization
	void Start () {
		message1.enabled = false;
		message2.enabled = false;
		message3.enabled = false;
		message4.enabled = false;
		endingFade.enabled = false;
		playerThere = false;
		enemy1.SetActive (false);
		enemy2.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {

		if(playerThere)
		{
			enemy1.SetActive(true);
			enemy2.SetActive(true);

			message1.enabled = true;
			lifetime1 -= Time.deltaTime;

			if(lifetime1 < 0)
			{
				message1.enabled = false;
				message2.enabled = true;
				lifetime2 -= Time.deltaTime;
			}
			if(lifetime2 < 0)
			{
				message2.enabled = false;
				message3.enabled = true;
				lifetime3 -= Time.deltaTime;
			}

			if(lifetime3 < 0)
			{
				message3.enabled = false;
				message4.enabled =  true;
				lifetime4 -= Time.deltaTime;
			}
			if(lifetime4 < 0)
			{
				message4.enabled = false;
				lifetime5 -= Time.deltaTime;
				music.SetActive(false);
				endingFade.enabled = true;

			}

			if(lifetime5 < 0)
			{
				Application.LoadLevel("lastScene");
			}


		}
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "player")
		{
			playerThere = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.name == "player")
		{
			playerThere = false;
		}
	}

}
