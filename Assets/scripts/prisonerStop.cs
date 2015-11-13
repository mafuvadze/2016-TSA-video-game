using UnityEngine;
using System.Collections;

public class prisonerStop : MonoBehaviour {

	public GameObject prisoner;
	public bool prisonerIn;

	// Use this for initialization
	void Start () {
		prisonerIn = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(prisonerIn)
		{
			prisoner.GetComponent<Rigidbody2D>().velocity = new Vector2(0,prisoner.GetComponent<Rigidbody2D>().velocity.y);
			prisonerScript.moveSpeed = 0;
		}
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "prisoner")
		{
			prisonerIn =  true;
		}
	}
}
