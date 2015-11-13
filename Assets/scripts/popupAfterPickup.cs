using UnityEngine;
using System.Collections;

public class popupAfterPickup : MonoBehaviour {

	public Canvas popupAfter;
	public float lifetime;
	public GameObject artifact;
	public bool artifactGone;

	// Use this for initialization
	void Start () {
		popupAfter.enabled = false;
		artifactGone = false;


	
	}
	
	// Update is called once per frame
	void Update () {
		if(pickupObject.gone == true)
		{
			Debug.Log("artifact gone");
			popupAfter.enabled = true;
			lifetime -= Time.deltaTime;
		}
		if(lifetime < 0)
		{
			popupAfter.enabled = false;
		}
	
	}
}
