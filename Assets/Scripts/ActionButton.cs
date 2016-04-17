using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AssemblyCSharp;

public class ActionButton : MonoBehaviour {

	private Image img;
	// Use this for initialization
	void Start () {
		img = gameObject.GetComponentInChildren<Image> ();
		img.sprite = Media.getImage ("pause");
	}
	
	// Update is called once per frame
	void Update () {
		if (player.paused) {
			GameManager.showPauseBtn ();
		} else {
			GameManager.hidePauseBtn ();
		}
	}
}
