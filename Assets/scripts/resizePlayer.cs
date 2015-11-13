using UnityEngine;
using System.Collections;

public class resizePlayer : MonoBehaviour {

	public GameObject resizeParticle;
	public GameObject player;
	public float size;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "player")
		{
			Instantiate(resizeParticle, other.transform.position, other.transform.rotation);
			player.transform.localScale = new Vector3(size,size,1f);
		

		}

	}
}
