using UnityEngine;
using System.Collections;

public class elevatorCheckpointScript : MonoBehaviour {

	public levelManager levelManager;
	public bool checkpointActivated;
	public Canvas checkpointPopup;
	public Canvas openElevator;
	public float popupLifetime;


	public GameObject checkpointNoise;
	 //Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<levelManager> ();
		checkpointPopup.enabled = false;
		openElevator.enabled = false;
		popupLifetime = 7;

		}
	// Update is called once per frame
	void Update () {
		if(elevatorScipt.xpressed == true)
		{
			openElevator.enabled = false;
		}
		popupLifetime -= Time.deltaTime;
		if (popupLifetime < 0) {
			//checkpointPopup.enabled = false;
			popupLifetime = 7;

				}
	}
		void OnTriggerEnter2D(Collider2D other)
		{
		if (other.name == "player" && leverScript.isPulled == true) {
						levelManager.currentCheckpoint = gameObject;
						Debug.Log ("Checkpoint Activated");
						checkpointActivated = true;
						checkpointPopup.enabled = true;
						checkpointNoise.GetComponent<AudioSource>().Play ();
				}
		}
}
