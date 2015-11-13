using UnityEngine;
using System.Collections;

public class springScript : MonoBehaviour {

	public Animator anim;
	public bool spring;
	public float lifetime;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		lifetime = .15f;

	
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("spring", spring );
		if(spring == true)
		{
			lifetime -= Time.deltaTime;
		}
		if(lifetime < 0)
		{
			spring = false;
			lifetime = .15f;
		}
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "player")
		{
			spring = true;
			
		}
	}
}
