using UnityEngine;
using System.Collections;

public class loadFourth : MonoBehaviour {

	public Canvas pressXpopup;
	public bool playerThere;
	public Canvas loading;
	public Canvas interact;
	public GameObject music;
	
	// Use this for initialization
	void Start () {
		interact.enabled = false;
		loading.enabled = false;
		playerThere = false;
		pressXpopup.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(playerThere)
		{
			pressXpopup.enabled = true;
			if(Input.GetKey(KeyCode.X))
			{
				pressXpopup.enabled =  false;
				loading.enabled = true;
				//music.SetActive(false);
				Application.LoadLevel ("level05");
			}
		}
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "player")
		{
			interact.enabled = true;
			playerThere = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.name == "player")
		{
			interact.enabled = false;
			playerThere = false;
		}
	}
}

