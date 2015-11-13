using UnityEngine;
using System.Collections;

public class healthRegen : MonoBehaviour {
	public float lifetime;

	// Use this for initialization
	void Start () {
		lifetime = 60;
	
	}
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;
		if(lifetime < 0)
		{
			if(healthManager.playerHealth < 100)
			{
				healthManager.HurtPlayer(-20);
			}
			lifetime = 60;
		}
	
	}
}
