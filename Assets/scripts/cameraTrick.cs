using UnityEngine;
using System.Collections;

public class cameraTrick : MonoBehaviour {
	public GameObject player;
	public GameObject box;
	public float playerPos;
	public float boxPos;
	public float diff;

	public bool playerHidden;
	public bool playerInView;
	public float maxAllowed;
	public bool detected;

	public Canvas redScreen;
	public float lifetime;




	// Use this for initialization
	void Start () {
		playerHidden = false;
		playerInView = false;
		detected = false;
		redScreen.enabled = false;
		lifetime = 5;
	}
	
	// Update is called once per frame
	void Update () {
		playerPos = player.transform.position.x;
		boxPos = box.transform.position.x;
		diff = Mathf.Abs (boxPos - playerPos);

		playerHidden = diff < maxAllowed ? true : false;

		if(!playerHidden && playerInView)
		{
			detected = true;
			redScreen.enabled = true;
		}

		if (detected) {
			lifetime -= Time.deltaTime;
		}
		if (lifetime < 0) {
			redScreen.enabled = false;
			Destroy(gameObject);
		} 

	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "player") {
			playerInView = true;
		}
	}
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.name == "player") {
			playerInView = false;
		}
	}
}
