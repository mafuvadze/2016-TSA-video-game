using UnityEngine;
using System.Collections;

public class redScreenRemove : MonoBehaviour {

	public float lifetime;

	// Use this for initialization
	void Start () {
		lifetime = 1.5f;
	
	
	}
	
	// Update is called once per frame
	void Update () {
		if(enabled == true)
		{
			lifetime -= Time.deltaTime;
			if(lifetime < 0)
			{
				enabled = false;
				lifetime = 1.5f;
			}
		}
	
	}
}
