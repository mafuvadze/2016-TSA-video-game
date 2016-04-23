using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicOverlap : MonoBehaviour {

	public AudioSource audio;
	public string stopLevel;
	// Use this for initialization
	void Start () {
		audio.Play ();
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (SceneManager.GetActiveScene ().name.Equals (stopLevel)) {
			audio.Stop ();
		}
		*/
	}
}
