using UnityEngine;
using System.Collections;

public class movingPlatfromHori : MonoBehaviour {

	public int moveSpeed;
	public Transform leftWallCheck;
	public Transform rightWallCheck;
	public LayerMask whatIsWall;
	public LayerMask whatIsGround;
	public bool hittingwall;
	public bool hittingwallUp;
	public bool movingUp;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(movingUp)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,3.5f);
		}
		if(!movingUp)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,-3.5f);
		}
		hittingwall = Physics2D.OverlapCircle (leftWallCheck.position, .2f, whatIsGround);
		hittingwallUp = Physics2D.OverlapCircle (rightWallCheck.position,.2f, whatIsWall);
		if(hittingwall)
		{
			movingUp = true;
		}
		if(hittingwallUp)
		{
			movingUp = false;
		}
	}
}
