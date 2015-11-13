using UnityEngine;
using System.Collections;

public class switch3 : MonoBehaviour {

	public bool switchPulled;
	public Animator anim;
	public Canvas pullSwitchPopup;
	public bool canSwitch;
	public GameObject wall;
	
	// Use this for initialization
	void Start () {
		switchPulled = false;
		anim = GetComponent<Animator> ();
		pullSwitchPopup.enabled = false;
		canSwitch = false;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("switch3", switchPulled );
		if (canSwitch && Input.GetKey(KeyCode.X))
		{
			Debug.Log ("x pressed");
			switchPulled = true;
			pullSwitchPopup.enabled = false;
			Destroy (wall.gameObject);
			//switchPulled = false;
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

