using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour {

	public float jumpHeight, groundCheckRadius, size, moveVelocity, moveTolerance, maxSpeed, RIGHT, LEFT;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public bool grounded, moving;
	public Animator anim;
	private Rigidbody2D myrigidbody2D;
	private KeyCode jumpKey = KeyCode.UpArrow;
	public static bool movementDisabled, paused;

	// Use this for initialization
	void Start () {
		moving = false;
		paused = false;
		myrigidbody2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		movementDisabled = false;
	}

	void FixedUpdate()
	{
		//check to see if player is touching the ground or nah
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}


	// Update is called once per frame
	void Update () 
	{
		//update anim variables
		anim.SetBool ("moving", moving );
		anim.SetBool ("grounded", grounded);

		if (!movementDisabled && !player.paused) {
			movementListener ();
			jumpListener ();
		}
	}

	void jumpListener(){
		if ((Input.GetKey(jumpKey) && grounded)) {
			//make player jump to certain height
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
		}
	}

	void movementListener(){
		if (Input.GetKey (KeyCode.RightArrow)) {
			moveVelocity = maxSpeed;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			moveVelocity = maxSpeed * -1;
		} else {
			moveVelocity = 0;
		}


		//makes sure that the player is moving 
		if(Mathf.Abs(moveVelocity) < moveTolerance)
		{
			moving = true;
		}
		else if(moveVelocity == 0)
		{
			moving = false;
		}

		if (Mathf.Abs (moveVelocity) > moveTolerance && !paused) {
			//turn player to face correct direction
			float direction = moveVelocity > 0 ? RIGHT : LEFT;
			direction *= size;
			if (grounded) {
				transform.localScale = new Vector3 (direction, size, 1f);
			}
			moving = true;
		} else {
			moving = false;
		}
		//move player left or right	
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

	}
		
	public static void disableMovement(){
		movementDisabled = true;
	}

	public static void enableMovement(){
		movementDisabled = false;
	}

	//called when another game object collides with player
	void OnTriggerEnter2D(Collider2D other)
	{

	}
	void OnTriggerExit2D(Collider2D other)
	{

	}
}