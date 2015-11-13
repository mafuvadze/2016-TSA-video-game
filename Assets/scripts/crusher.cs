using UnityEngine;
using System.Collections;

public class crusher : MonoBehaviour {
	public Rigidbody2D crusherRB;
	public Transform upSensor;
	public Transform downSensor;

	public bool HittingUp;
	public bool HittingDown;

	public LayerMask whatIsGround;
	public LayerMask whatIsWall;

	public float moveSpeed;
	public bool movingUp;
	public float rand;

	public GameObject dust;
	public float lifetime;
	// Use this for initialization
	void Start () {
		crusherRB = GetComponent<Rigidbody2D> ();
		//moveSpeed = 3.5f;
		dust.SetActive (false);
		lifetime = 2.5f;
	
	}
	
	// Update is called once per frame
	void Update () {
		HittingUp = Physics2D.OverlapCircle (upSensor.position, .3f, whatIsWall);
		HittingDown = Physics2D.OverlapCircle (downSensor.position, .3f, whatIsGround);

		if(HittingUp)
		{
			moveSpeed = -moveSpeed;
			movingUp = false;
		}
		if(HittingDown)
		{
			dust.SetActive(true);
			moveSpeed = -moveSpeed;
			movingUp = true;
		}
		if(!HittingDown)
		{
			lifetime -= Time.deltaTime;
			if(lifetime < 0)
			{
				dust.SetActive(false);
				lifetime = 2.5f;
			}
		}

		if(movingUp)
		{
			crusherRB.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,moveSpeed);
		}
		if(!movingUp)
		{
			crusherRB.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,-moveSpeed);
		}



	
	}
}
