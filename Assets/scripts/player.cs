using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;
	public float moveSpeedPlatform;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	public bool onMovingPlatform;

	public Transform firePoints;
	public GameObject bullet;
	public GameObject backgroundMusic;
	public Transform muzzleFlash;
	public float size;
	public bool attack;
	public static int shrunk;
	public bool moving;
	public bool shooting;

	public Animator anim;
	private float moveVelocity;

	public bool onLadder;
	public float climbSpeed;
	private float climbVelocity;
	private float gravityStore;
	private Rigidbody2D myrigidbody2D;



	// Use this for initialization
	void Start () {
		GetComponent<player> ().enabled = true;
		moveSpeed = 5f;
		onMovingPlatform = false;
		climbSpeed = 5f;
		onLadder = false;
		moving = false;
		myrigidbody2D = GetComponent<Rigidbody2D> ();
		gravityStore = GetComponent<Rigidbody2D>().gravityScale;
		anim = GetComponent<Animator> ();
		backgroundMusic.GetComponent<AudioSource>().Play ();
		size = .9f;
		attack = false;
		shooting = false;
		}
	
	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	
	// Update is called once per frame
	void effect()
	{
		Transform clone = (Transform)Instantiate (muzzleFlash, firePoints.position, firePoints.rotation);
		clone.parent = firePoints;
		float size = Random.Range (0.3f, 0.5f);
		clone.localScale = new Vector3 (size, size, 1);
		Destroy (clone.gameObject, 0.02f);
		}
	void Update () {
		anim.SetBool ("moving", moving );
		anim.SetBool ("grounded", grounded);
		anim.SetBool ("attacking", attack);
		anim.SetBool ("shooting", attack);

	
		Debug.Log (moveVelocity);
		if(Mathf.Abs(moveVelocity) < 0.1)
		{
			moving = true;
		}
		if(moveVelocity == 0)
		{
			moving = false;
		}

		if(pauseEffect.isPaused == true)
		{
			backgroundMusic.GetComponent<AudioSource>().mute = true;
		}
		if(pauseEffect.isPaused == false)
		{
			backgroundMusic.GetComponent<AudioSource>().mute = false;
		}
		if(grounded)
		{
			//moveVelocity = 0f;
		}
		if(Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.Space))
		{
			shooting = true;
		}else{
			shooting = false;
		}
		if(attack)
		{
			attack = !attack;
		}
		if(onLadder)
		{
			myrigidbody2D.gravityScale = 0f;
			climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
			myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, climbVelocity);
		}
		if(!onLadder && (Application.loadedLevelName == "level05"))
		{
			myrigidbody2D.gravityScale = gravityStore;
		}

		if (Input.GetButton("Jump") && grounded) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
		
				}
		if (Input.GetKey(KeyCode.W) && grounded) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
			
		}
		if (Input.GetAxisRaw("Horizontal") > 0.2) {
			//moveVelocity = moveSpeed;
			//rigidbody2D.velocity = new Vector2(moveSpeed,rigidbody2D.velocity.y);
			transform.localScale = new Vector3 (size,1f,1f);
			moving = true;
		}
		if (Input.GetAxisRaw("Horizontal") < -0.2f) {
			//moveVelocity = -moveSpeed;
			//rigidbody2D.velocity = new Vector2(-moveSpeed,rigidbody2D.velocity.y);
			transform.localScale = new Vector3(-size,1f,1f);
			moving = true;

		}

		moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");

		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity,GetComponent<Rigidbody2D>().velocity.y);
		if (!(Input.GetKey (KeyCode.D)) && !(Input.GetKey (KeyCode.A)))
		{
			//moving = false;
		}
		if (Input.GetKeyDown (KeyCode.Space) && Time.timeScale == 1f) {
			//attack = true;
			Instantiate(bullet, firePoints.position, firePoints.rotation);
		
		}
		if (Input.GetButtonDown("Fire3") && Time.timeScale == 1f) {
			//attack = true;
			Instantiate(bullet, firePoints.position, firePoints.rotation);
			
		}
		if (onMovingPlatform)
		{
			if (Input.GetKeyDown (KeyCode.D))
			    {
					moveSpeed = moveSpeedPlatform;
				}
			if (Input.GetKeyDown (KeyCode.A))
			{
				moveSpeed = moveSpeedPlatform;
			}
		}




	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag =="movingPlatform")
		{
			onMovingPlatform = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag =="movingPlatform")
		{
			onMovingPlatform = false;
		}
	}
}