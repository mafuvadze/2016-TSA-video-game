using UnityEngine;
using System.Collections;

public class elevatorScipt : MonoBehaviour {

	public static bool playerAtElavator;
	public Animator anim;
	public bool isLeverPulled;
	public static bool popupShown;
	public float nextLevelTime;
	public GameObject elevatorSoundEffect;
	public static bool xpressed;
	public float lifetime;
	public Canvas loading;
	public GameObject music;
	
	// Use this for initialization
	void Start () {
		playerAtElavator = false;
		loading.enabled = false;
		anim = GetComponent<Animator> ();
		isLeverPulled = false;
		popupShown = false;
		nextLevelTime = 3;
		xpressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(playerAtElavator && leverScript.isPulled == true)
		{
			lifetime -= Time.deltaTime;
			if(lifetime < 0 || Input.GetKeyDown(KeyCode.X))
			{
				loading.enabled = true;
				music.SetActive(false);
				Application.LoadLevel ("level03");
			}
		}
		anim.SetBool ("isLeverPulled", leverScript.isPulled);
		anim.SetBool ("playerAtElevator", playerAtElavator);
		if(playerAtElavator && leverScript.isPulled == true)
		{
			elevatorSoundEffect.GetComponent<AudioSource>().Play();
			GetComponent<AudioSource>().Play();
			if(Input.GetKey (KeyCode.X) || Input.GetButton("Submit"))
			{
				xpressed = true;
				loading.enabled = true;
				Application.LoadLevel ("level03");
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "player") {
			lifetime = 3;
			playerAtElavator = true;
			popupShown = true;
				}
		if (other.tag == "elevator") {
			playerAtElavator = false;
		} 	
		
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "player") {
			playerAtElavator = false;
			//popupShown = true;
		}
	}
}