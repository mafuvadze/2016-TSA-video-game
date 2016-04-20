using UnityEngine;
using System.Collections;

public class Rung : MonoBehaviour {
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
			rb.velocity = new Vector2 (-.8f, rb.velocity.y);
			yield return new WaitForSeconds (.015f);	
		} while(gameObject.transform.position.x >= lowerLimit && !Input.GetKeyDown (KeyCode.X));
		rb.velocity = new Vector2(0f, rb.velocity.y);
	}

	IEnumerator startRaising(){
		do {
			rb.velocity = new Vector2 (.8f, rb.velocity.y);
			yield return new WaitForSeconds (.015f);
		} while(gameObject.transform.position.x <= upperLimit && !Input.GetKeyDown (KeyCode.X));
		rb.velocity = new Vector2(0f, rb.velocity.y);
	}
}
