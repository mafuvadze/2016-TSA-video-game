using UnityEngine;
using System.Collections;

public class fade : MonoBehaviour {

	public GameObject fadeSignal;
	public Animator anim;
	public bool startFade;
	public Canvas fading;


	// Use this for initialization
	void Start () {
		fading.enabled = false;
		startFade = false;
		anim = GetComponent<Animator> ();


	
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("fade", startFade );
		if(fadeSignal.gameObject == null && fading.enabled == true)
		{
			startFade = true;
		}

	
	}
}
