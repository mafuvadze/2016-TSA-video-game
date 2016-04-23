using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {
	// Use this for initialization
	Rigidbody2D rb;
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void open(){
		StartCoroutine (startRaising());
	}

	public void close(){
		Debug.Log ("close");
		StartCoroutine (startLowering());
	}

	IEnumerator startLowering(){
		do {
			rb.velocity = new Vector2 (rb.velocity.x, -2f);
			yield return new WaitForSeconds (.010f);
		} while(gameObject.transform.position.y >= -8f && !Input.GetKeyDown (KeyCode.X));
		rb.velocity = new Vector2(rb.velocity.x, -0f);
	}

	IEnumerator startRaising(){
		do {
			rb.velocity = new Vector2 (rb.velocity.x, 2f);
			yield return new WaitForSeconds (.010f);
		} while(gameObject.transform.position.y <= -3f && !Input.GetKeyDown (KeyCode.X));
		rb.velocity = new Vector2(rb.velocity.x, -0f);
	}


}
