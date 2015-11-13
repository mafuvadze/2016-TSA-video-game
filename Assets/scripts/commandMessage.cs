using UnityEngine;
using System.Collections;

public class commandMessage : MonoBehaviour {

	public Canvas commands;
	public float lifetime;
	public GameObject popupSoundSource;

	// Use this for initialization
	void Start () {
		commands.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;	
		if (lifetime < 0)
		{
			commands.enabled = false;
			lifetime = 0;
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "player")
		{
			if(commands.enabled==false)
			{popupSoundSource.GetComponent<AudioSource>().Play();}
			commands.enabled = true;
			lifetime = 7;
		}
	}
	public void removeCommand()
	{
		commands.enabled = false;
	}
}
