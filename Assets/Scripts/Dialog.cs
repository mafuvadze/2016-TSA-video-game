using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

	public static Dialog instance;

	private Canvas container;
	public float delay;
	private int pos;
	private bool disableMovement, dialogShown;
	private DialogData dialogData;
	AssemblyCSharp.Speech[] words;

	void Awake () {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		dialogData = new DialogData ();
		hide ();

		//display (dialogData.test, true);
	}

	void hide () {
		GameManager.hideDialog ();
		GameManager.hideBlackScreen ();
		dialogShown = false;
	}

	void Update(){
		pauseListener ();
	}

	public void display(AssemblyCSharp.Speech[] words, bool disableMovement){
		GameManager.displayText (words, disableMovement);
		dialogShown = true;
	}
		
	public void finish(){
		//end of dialog reached
		dialogShown = false;
	}


	//temporarily disables the canvas while paused
	void pauseListener(){
		if (player.paused && dialogShown) {
			GameManager.hideDialog ();
			GameManager.hideBlackScreen ();
		} else if (!player.paused && dialogShown) {
			GameManager.showDialog ();
			GameManager.showBlackScreen ();
		}

	}
}
