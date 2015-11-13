using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class collectables : MonoBehaviour {
	public Text text;
	public GameObject message;

	// Use this for initialization
	void Start () {
		text = message.GetComponent<Text> ();

	
	}
	
	// Update is called once per frame
	void Update () {
		int col = PlayerPrefs.GetInt ("collected");
		text.text = string.Format ("Scroll {0} of 8",col);
	}
}
