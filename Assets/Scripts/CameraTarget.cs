using UnityEngine;
using System.Collections;

public class CameraTarget : MonoBehaviour {

	public Transform player1, player2;
	float x1, x2, y1, y2, z1, z2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		x1 = player1.position.x;
		x2 = player2.position.x;
		y1 = player1.position.y;
		y2 = player2.position.y;
		z1 = player1.position.z;
		z2 = player2.position.z;

		gameObject.transform.position = new Vector3 ((x1 + x2)/2, (y1 + y2)/2, (z1 + z2)/2);
	}
}
