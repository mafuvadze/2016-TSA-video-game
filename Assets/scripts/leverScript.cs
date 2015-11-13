using UnityEngine;
using System.Collections;

public class leverScript : MonoBehaviour {

	public static bool isPulled ;
	public Canvas leverOption;
	public Canvas leverMessage;
	public Canvas rightArrow;
	public Canvas leftArrow;
	public bool pullInput;
	public GameObject popupSoundSource;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rightArrow.enabled = true;
		leftArrow.enabled = false;
		leverMessage.enabled = false;
		isPulled = false;
		leverOption.enabled = false;
		pullInput = false;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		anim.SetBool ("isPulled", isPulled);
		if(pullInput)
		{
			if (Input.GetKey (KeyCode.X) || Input.GetButton("Submit"))
			{
				isPulled = true;
				print ("lever pulled");
				elevatorScipt.playerAtElavator = false;
				leverOption.enabled = false;
				rightArrow.enabled = false;
				leftArrow.enabled = true;
				pullInput = false;
				leverMessage.enabled = true;
			}

		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.name == "player")
		{
			leverOption.enabled = false;
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "player")
		{
			if(isPulled == false)
			{
				popupSoundSource.GetComponent<AudioSource>().Play();
				leverOption.enabled = true;
				pullInput = true;
			}
		}
	}
	public void removeGUI()
	{
		leverOption.enabled = false;
	}
}
