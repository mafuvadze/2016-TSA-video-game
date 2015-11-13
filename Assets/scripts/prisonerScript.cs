using UnityEngine;
using System.Collections;

public class prisonerScript : MonoBehaviour {

	public GameObject player;
	public Transform groundCheck;
	public Transform wallCheck;
	public Transform wallCheckAbove;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public LayerMask whatIsProtected;
	public LayerMask whatIsWall;
	public LayerMask whatIsTrap;
	private bool grounded;
	public Animator anim;
	public static float moveSpeed;
	public bool hittingwall;
	public bool hittingTrap;
	public bool hittingwallAbove;
	public bool hittingLaser;
	public bool playerRight;
	public float jumpHeight;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();


	
	}
	
	// Update is called once per frame
	void Update () {
		if (hittingLaser) {
			moveSpeed = 0;
		}
		if(hittingwallAbove)
		{
			jumpHeight = 0;
			moveSpeed = 0;
		}
		if(!hittingwallAbove)
		{
			jumpHeight = 14;
		}
		if(moveSpeed != 0)
		{
			if(playerRight == true)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			}
			if(playerRight == false)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			}
		}
		if(hittingwall)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y,jumpHeight);
			if(wallCheck.transform.position.x > transform.position.x)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			}
			if(wallCheck.transform.position.x < transform.position.x)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			}

		}
		hittingLaser = Physics2D.OverlapCircle (wallCheck.position, groundCheckRadius, whatIsProtected);
		hittingwall = Physics2D.OverlapCircle (wallCheck.position, groundCheckRadius, whatIsWall);
		hittingwallAbove = Physics2D.OverlapCircle (wallCheckAbove.position, groundCheckRadius, whatIsWall);
		hittingTrap = Physics2D.OverlapCircle (wallCheck.position, groundCheckRadius, whatIsTrap);
		if (Mathf.Abs ((Mathf.Abs (player.transform.position.x)) - (Mathf.Abs (transform.position.x))) > 3 && !hittingTrap && !hittingLaser) 
		{
			moveSpeed = 3.9f;
		}
		if (Mathf.Abs ((Mathf.Abs (player.transform.position.x)) - (Mathf.Abs (transform.position.x))) < 3) 
		{
			moveSpeed =0;
		}
		anim.SetFloat ("speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		anim.SetBool ("grounded", grounded);
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		if ((player.transform.position.x) > (transform.position.x))
		{
			transform.localScale = new Vector3(.9f,.8f,1f);
			playerRight = true;
		}
		if ((player.transform.position.x) < (transform.position.x))
		{
			transform.localScale = new Vector3(-.9f,.8f,1f);
			playerRight = false;
		}
		if(hittingTrap)
		{
			moveSpeed = 0;
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "trap")
		{
			moveSpeed = 0;
		}
		
	}
}
