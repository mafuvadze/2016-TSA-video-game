using UnityEngine;
using System.Collections;

public class bossMovement : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;
	public GameObject enemy;
	public float size;
	
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
	
	// Use this for initialization
	void Start () {
		enemySize = 1.6f;
		facingRight = true;
		grounded = true;
		playerShooting = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(playerShooting)
		{
			float random =  Mathf.Round(Random.Range(1,10));
			if(random  > 6)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y,14);
			}
			
		}
		if (Mathf.Abs ((Mathf.Abs (player.transform.position.x)) - (Mathf.Abs (transform.position.x))) > 2.8) 
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
				reverseTime.enemyReady = true;
				facingRight = false;
			}
			if((player.transform.position.x) > (transform.position.x) && !moveRight)
			{
				moveRight = !moveRight;
				facingRight = true;
			}
		}
		if(moveRight)
		{
			transform.localScale = new Vector3(enemySize,enemySize,1f);
		}
		if(!moveRight)
		{
			transform.localScale = new Vector3(-enemySize,enemySize,1f);
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
			moveRight = !moveRight;
		}
		if(!atEdge && grounded)
		{
			moveRight = !moveRight;
		}
		
		if (moveRight) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		} else {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "projectiles") 
		{
			enemySize -= .1f;
			enemy.transform.localScale = new Vector3(enemySize, enemySize, 1f);
		}
	}
}
