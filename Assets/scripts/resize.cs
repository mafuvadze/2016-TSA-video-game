using UnityEngine;
using System.Collections;

public class resize : MonoBehaviour {
	public float sizeX;
	public float sizeY;
	public float currentSizeX;
	public float currentSizeY;
	public float CPX;
	public float CPY;
	public float lifetime;

	// Use this for initialization
	void Start () {
		sizeX = transform.localScale.x;
		sizeY = transform.localScale.y;
		lifetime = 10;
	}
	
	// Update is called once per frame
	void Update () {
		//currentSizeX = bulletMovement.enemyX;
		//currentSizeY = bulletMovement.enemyY;
		CPX = transform.localScale.x;
		CPY = transform.localScale.y;
		if(transform.localScale.x != sizeX)
		{
			lifetime -= Time.deltaTime;
		}
		if(lifetime < 0 && sizeX != transform.localScale.x)
		{
			transform.localScale = new Vector3(sizeX, sizeY, 1f);
			lifetime = 10;
		}

	
	}
}
