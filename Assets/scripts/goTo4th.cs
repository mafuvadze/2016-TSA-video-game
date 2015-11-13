using UnityEngine;
using System.Collections;

public class go : MonoBehaviour {

	public Canvas pressXpopup;
	public bool playerThere;

	// Use this for initialization
	void Start () {
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
				Application.LoadLevel ("level05");
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
}
