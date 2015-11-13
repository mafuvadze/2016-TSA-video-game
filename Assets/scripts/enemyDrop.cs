using UnityEngine;
using System.Collections;

public class enemyDrop : MonoBehaviour {

	public GameObject droppedItem;
	public GameObject enemy;
	public bool objectExists;
	public Canvas dropPopup;
	public Canvas dropPopup2;
	public float lifetimeForPopup;
	public float lifetimeForPopup2;
	public bool startCount;
	public float enemySize;


	// Use this for initialization
	void Start () {
		dropPopup.enabled = false;
		dropPopup2.enabled = false;
		startCount = false;
		objectExists = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy != null) {
						enemySize = (enemy.GetComponent<enemyPatrol> ().enemySize);
				}
		if(enemy == null)
		{
			dropPopup.enabled = true;
			
			startCount = true;
			if(startCount)
			{
				lifetimeForPopup -= Time.deltaTime;
			}
			if(lifetimeForPopup < 0)
			{
				dropPopup.enabled = false;
				dropPopup2.enabled = true;
				lifetimeForPopup2 -= Time.deltaTime;
			}
			if(lifetimeForPopup2 < 0)
			{
				dropPopup2.enabled = false;
			}
		}
		
		
	}
	void count()
	{

	}
}
