using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public float jumpHeight, groundCheckRadius, size, moveVelocity, moveTolerance, maxSpeed, RIGHT, LEFT;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	private bool grounded, moving, paused;
	public Animator anim;
	private Rigidbody2D myrigidbody2D;
	private KeyCode jumpKey = KeyCode.W, pauseKey = KeyCode.P;
	public Canvas pauseMenu;
	private static bool movementDisabled;

	// Use this for initialization
	void Start () {
		GetComponent<player> ().enabled = true;
		moving = false;
		paused = false;
		myrigidbody2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		pauseMenu.enabled = false;
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

		if (!movementDisabled) {
			movementListener ();
			jumpListener ();
		}
		pauseListener ();
	}

	void jumpListener(){
		if (Input.GetKey(jumpKey) && grounded) {
			//make player jump to certain height
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
		}
	}

	void pauseListener(){
		if (Input.GetKeyDown (pauseKey)) {
			if (paused) {
				resume ();
			} else {
				pause ();
			}
		}

	}

	void movementListener(){
		moveVelocity = maxSpeed * Input.GetAxisRaw("Horizontal");

		//makes sure that the player is moving 
		if(Mathf.Abs(moveVelocity) < moveTolerance)
		{
			moving = true;
		}
		else if(moveVelocity == 0)
		{
			moving = false;
		}

		float movementValue = Input.GetAxisRaw("Horizontal");
		if (Mathf.Abs (movementValue) > 0.2 && !paused) {
			//turn player to face correct direction
			float direction = movementValue > 0 ? RIGHT : LEFT;
			direction *= size;
			transform.localScale = new Vector3 (direction, 1f, 1f);
			moving = true;
		} else {
			moving = false;
		}
		//move player left or right	
		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity,GetComponent<Rigidbody2D>().velocity.y);
	}

	//called when pause button (P) is pressed
	public void pause(){
		paused = true;
		pauseMenu.enabled = true;
		Time.timeScale = 0f;
	}

	public void resume(){
		paused = false;
		Time.timeScale = 1f;
		pauseMenu.enabled = false;
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