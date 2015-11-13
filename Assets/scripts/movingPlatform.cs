using UnityEngine;
using System.Collections;

public class movingPlatform : MonoBehaviour {

	public int moveSpeed;
	public Transform leftWallCheck;
	public Transform rightWallCheck;
	public LayerMask whatIsWall;
	public bool hittingwall;
	public bool hittingwallRight;
	public bool movingRight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(movingRight)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		}
		if(!movingRight)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		}
		hittingwall = Physics2D.OverlapCircle (leftWallCheck.position,.2f, whatIsWall);
		hittingwallRight = Physics2D.OverlapCircle (rightWallCheck.position,.2f, whatIsWall);
		if(hittingwall)
		{
			movingRight = true;
		}
		if(hittingwallRight)
		{
			movingRight = false;
		}
	}
}
