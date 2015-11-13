using UnityEngine;
using System.Collections;

public class veryBeg : MonoBehaviour {

	public Canvas start;
	public float lifetime;

	// Use this for initialization
	void Start () {
		start.enabled = false;
		lifetime = 5.5f;
	
	}
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;
		if(lifetime < 0)
		{
			start.enabled = true;
		}
	
	}
}
