using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class loading : MonoBehaviour {

	Text txt;
	public float loadingLevel;

	// Use this for initialization
	void Start () {
		loadingLevel = 0f;
		txt = gameObject.GetComponent<Text>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
