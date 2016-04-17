﻿using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class DialogPopup : MonoBehaviour {

	DialogData dialogData;
	public bool disabled;
	public string name;
	SequenceData data;
	bool present;
	// Use this for initialization
	void Start () {
		dialogData = new DialogData ();
		data = new SequenceData ();
	}
	
	// Update is called once per frame
	void Update () {
		if (present && Input.GetKeyDown (KeyCode.X) && !disabled) {
			GameManager.hideDialog ();
			GameManager.hideGameMsgCanvas ();
			GameManager.incrementClues ();
			disabled = true;
			displayText ();
		}
	}
		
	void displayText(){
		Speech[] convo = null;
		if (name == "revere") {
			convo = dialogData.revere;
		}else if(name == "washington"){
			convo = dialogData.washington;
		}else if(name == "mail"){
			convo = dialogData.mail;
		}else if(name == "henry"){
			convo = dialogData.henry;
		}else if(name == "hancock"){
			convo = dialogData.hancock;
		}

		GameManager.displayText (convo, true);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && !disabled) {
			present = true;
			GameManager.displayGameMessage (data.info);
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player" && !disabled) {
			present = false;
			disabled = false;
			GameManager.hideGameMsgCanvas ();
		}
	}
}