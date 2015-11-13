using UnityEngine;
using System.Collections;

public class deleteRightArrow : MonoBehaviour {
	public Canvas rightArrow;
	public static bool removeArrow;

	// Use this for initialization
	void Start () {
		removeArrow = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "player")
		{
			removeArrow = true;
			rightArrow.enabled = false;
		}
	}
}
