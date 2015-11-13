using UnityEngine;
using System.Collections;

public class checkpointScript : MonoBehaviour {

	public levelManager levelManager;
	public bool checkpointActivated;
	public Canvas checkpointPopup;
	public float popupLifetime;
	public bool activated;

	//public GameObject checkpointNoise;
	// Use this for initialization
	void Start () {
		activated = false;
		levelManager = FindObjectOfType<levelManager> ();
		checkpointPopup.enabled = false;
		popupLifetime = 3;

		}
	// Update is called once per frame
	void Update () {
		popupLifetime -= Time.deltaTime;
		if (popupLifetime < 0) {
			checkpointPopup.enabled = false;
			popupLifetime = 3;

				}
	}
		void OnTriggerEnter2D(Collider2D other)
		{
			if(other.name == "player" && activated == false)
			{
			levelManager.currentCheckpoint =  gameObject;
			Debug.Log("Checkpoint Activated");
			checkpointActivated = true;
			checkpointPopup.enabled = true;
			//checkpointNoise.GetComponent<AudioSource>().Play();
			activated = true;


			}
		}
}
