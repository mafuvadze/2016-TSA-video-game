using UnityEngine;
using System.Collections;

public class lvl3Advance : MonoBehaviour {

	public Canvas OpenDoor;
	public bool playerThere;
	public Canvas loading;
	public GameObject music;

	// Use this for initialization
	void Start () {
		loading.enabled = false;
		OpenDoor.enabled = false;
		playerThere = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(playerThere)
		{
			OpenDoor.enabled = true;
		}
		if(playerThere && OpenDoor.enabled == true)
		{
			if(Input.GetKey(KeyCode.X))
			{
				loading.enabled = true;
				music.SetActive(false);
				Application.LoadLevel("level04");
			
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
