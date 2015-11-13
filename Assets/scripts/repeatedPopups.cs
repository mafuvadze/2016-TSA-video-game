using UnityEngine;
using System.Collections;

public class repeatedPopups : MonoBehaviour {
	public Canvas popup1;
	public Canvas popup2;
	public Canvas popup3;
	public float lifetime1;
	public float lifetime2;
	public bool triggerEntered;

	// Use this for initialization
	void Start () {
		popup1.enabled = false;
		popup2.enabled = false;
		popup3.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
				if (triggerEntered) {
						popup1.enabled = true;
						lifetime1 -= Time.deltaTime;
		
						if (lifetime1 < 0) {
								popup1.enabled = false;
								popup2.enabled = true;
								lifetime2 -= Time.deltaTime;
						}
						if (lifetime2 < 0) {
								popup2.enabled = false;
										

						}
						if (lifetime2 < 0 && leverScript.isPulled == false) {
								popup3.enabled = true;
						}
	
				
				}
		}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "player")
		{
			triggerEntered = true;
		}
	}
}
