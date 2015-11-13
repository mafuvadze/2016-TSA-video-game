using UnityEngine;
using System.Collections;

public class enemyPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	public LayerMask whatIsGround;
	public LayerMask whatIsTraps;
	public bool hittingwall;

	private bool atEdge;
	private bool atTrap;
	public Transform edgeCheck;
	public GameObject player;
	public bool facingRight;
	public Transform groundCheck;
	public bool grounded;
	public Transform firePoint;
	public int speed;
	public float enemySize;
	public bool playerShooting;
	public GameObject projectile;
	public bool moving;
	public Animator anim;

	// Use this for initialization
	void Start () {
		moving = false;
		anim = GetComponent<Animator> ();
		if(tag == "enemy" && name != "boss")
		{
			enemySize = 1.3f;
		}
		if(tag == "enemy" && name == "boss")
		{
			enemySize = 2f;
		}
		facingRight = true;
		grounded = true;
		playerShooting = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(moveSpeed != 0)
		{
			moving = true;
		}
		if(moveSpeed == 0)
		{
			moving = false;
		}
		anim.SetBool ("walking",moving  );
		anim.SetBool ("jumping", !grounded);
		if(playerShooting)
		{
			float random =  Mathf.Round(Random.Range(1,10));
			if(random  > 6)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y,14);
			}

		}
		if (Mathf.Abs ((Mathf.Abs (player.transform.position.x)) - (Mathf.Abs (transform.position.x))) > 1) 
		{
			moveSpeed = 3;
		}
		/*if(Mathf.Abs((Mathf.Abs(player.transform.position.x))-(Mathf.Abs(transform.position.x))) > 7)
		{
			reverseTime.enemyReady = false;
		}*/
		if(Mathf.Abs((Mathf.Abs(player.transform.position.x))-(Mathf.Abs(transform.position.x))) < 2.8)
		{
			moveSpeed = 0;
			if((player.transform.position.x) < (transform.position.x) && moveRight)
			{
				moveRight = !moveRight;
				//reverseTime.enemyReady = true;
				facingRight = false;
			}
			if((player.transform.position.x) > (transform.position.x) && !moveRight)
			{
				moveRight = !moveRight;
				facingRight = true;
			}
		}
		if(moveRight && gameObject.tag == "enemy")
		{
			transform.localScale = new Vector3(-enemySize,enemySize,1f);
		}
		if(!moveRight && gameObject.tag == "enemy")
		{
			transform.localScale = new Vector3(enemySize,enemySize,1f);
		}

		hittingwall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);
		atEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsGround);
		atTrap = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsTraps);
		grounded = Physics2D.OverlapCircle (groundCheck.position, wallCheckRadius, whatIsGround);
		if(atTrap)
		{
			print ("at the trap");
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y,14);
		}
		if(hittingwall && grounded)
		{
			moveRight = true;
		}
		if(!atEdge && grounded)
		{
			moveRight = false;
		}

		if (moveRight) {
						GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
				} else {
						GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
				}
	
	}
}
