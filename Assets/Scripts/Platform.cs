using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public float upperLimit, lowerLimit;
	Rigidbody2D rb;   
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponentInChildren<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void open(){
		StartCoroutine (startLowering());
	}

	public void close(){
		StartCoroutine (startRaising());
	}

	IEnumerator startLowering(){
		do {
			rb.velocity = new Vector2 (rb.velocity.x, -.8f);
			yield return new WaitForSeconds (.015f);	
		} while(gameObject.transform.position.y >= lowerLimit && !Input.GetKeyDown (KeyCode.X));
		rb.velocity = new Vector2(rb.velocity.x, 0f);
	}

	IEnumerator startRaising(){
		do {
			rb.velocity = new Vector2 (rb.velocity.x, .8f);
			yield return new WaitForSeconds (.015f);
		} while(gameObject.transform.position.y <= upperLimit && !Input.GetKeyDown (KeyCode.X));
		rb.velocity = new Vector2(rb.velocity.x, 0f);
	}
}
