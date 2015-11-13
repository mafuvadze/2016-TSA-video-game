using UnityEngine;
using System.Collections;

public class switch2 : MonoBehaviour {

	public bool switchPulled;
	public Canvas ObjectivePopup;
	public Animator anim;
	public Canvas pullSwitchPopup;
	public bool canSwitch;
	public GameObject wall;
	public float lifetime;
	public bool popShown;

	// Use this for initialization
	void Start () {
		lifetime = 6;
		popShown = false;
		ObjectivePopup.enabled = false;
		switchPulled = false;
		anim = GetComponent<Animator> ();
		pullSwitchPopup.enabled = false;
		canSwitch = false;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("switch2", switchPulled );
		if (canSwitch && Input.GetKey(KeyCode.X))
		{
			Debug.Log ("x pressed");
			switchPulled = true;
			pullSwitchPopup.enabled = false;
			Destroy (wall.gameObject);
		}
		if(popShown == false && switchPulled == true)
		{
			popShown = true;
			ObjectivePopup.enabled = true;
			lifetime -= Time.deltaTime;
		}
		if(lifetime < 0)
		{
			ObjectivePopup.enabled = false;
		}
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "player")
		{
			canSwitch =  true;
			pullSwitchPopup.enabled = true;

		}
	}
}
