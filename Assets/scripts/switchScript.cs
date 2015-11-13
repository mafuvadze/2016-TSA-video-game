using UnityEngine;
using System.Collections;

public class switchScript : MonoBehaviour {
	
	public bool switchisOn;
	public Canvas pullSwitch;
	public bool intriggerZone;
	public GameObject wallBarier;
	private Animator anim;
	// Use this for initialization
	void Start () {
		switchisOn = false;
		intriggerZone = false;
		pullSwitch.enabled = false;
		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("switchOn", switchisOn);
		if(pullSwitch.enabled == true && Input.GetKey (KeyCode.X))
		{
			Destroy (wallBarier.gameObject);
			pullSwitch.enabled = false;

		}
		if(intriggerZone == true && Input.GetKey (KeyCode.X))
		{
			switchisOn  = true;
		}
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "player" && switchisOn == false)
		{
			pullSwitch.enabled = true;
			intriggerZone = true;

		}
}
}