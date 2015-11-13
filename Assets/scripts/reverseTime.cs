using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class reverseTime : MonoBehaviour {
	public float timeRecordAmount = 8.0f;
	public KeyCode timeRewindKey;
	public bool recordMoment = false;
	public GameObject target;
	public float elaspedTime;
	public float currentTime;
	public List<Vector3> targetMovements = new List<Vector3>();
	public static bool enemyReady;
	public static bool GoBackInTime;
	
	
	// Use this for initialization
	void Start () {
		enemyReady = false;
		GoBackInTime = false;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (enemyReady) {
						recordMoment = true;
		
				} else {
						recordMoment = false;
				}
		if (recordMoment) {
			elaspedTime = elaspedTime + Time.deltaTime;
			RecordTargetsMovementForSeconds (target, timeRecordAmount);
		} else {
			elaspedTime = 0;
			
		}
	}
	
	
	void RecordTargetsMovementForSeconds(GameObject target, float seconds)
	{
		//Debug.Log ("Record for " + seconds);

			//Debug.Log ("Elasped time " + elaspedTime);
		if (elaspedTime <= seconds) 
		{
			elaspedTime = 0;
			Vector3 moment;
			moment.x = target.transform.position.x;
			moment.y = target.transform.position.y;
			moment.z = target.transform.position.z;
			targetMovements.Add (moment);
		}
		 if(GoBackInTime)
		{
			StartCoroutine(ReverseTime(target, targetMovements));
			recordMoment = false;
		}
	}
	void ClearTargetMovements()
	{
		targetMovements.Clear ();
	}
	
	void SetTarget(GameObject target)
	{
		this.target = target;
	}
	
	List<Vector3> getTargetsMovements()
	{
		return targetMovements;
	}
	
	IEnumerator ReverseTime(GameObject target, List<Vector3> past)
	{
		recordMoment = false;
		//reverse the list so we go through our actions last > first
		past.Reverse ();
		//GameObject clone = Instantiate (target, target.transform.position, target.transform.rotation) as GameObject;
		//clone.GetComponent<MouseLook> ().enabled = false;
		//clone.GetComponent<Shoot> ().enabled = false;
		//clone.GetComponent<LineRenderer> ().enabled = false;
		//clone.GetComponentsInChildren<Camera> () [0].enabled = false;
		
		for (int i = 0; i < past.Count; i++) {
			//Debug.Log (past.Count);
			
			Vector3 currPos = target.transform.position;
			//Debug.Log ("Index :" + i + " X pos " + past [i].x);
			//Debug.Log ("Index :" + i + " y pos " + past [i].y);
			//Debug.Log ("Index :" + i + " z pos " + past [i].z);
			
			Vector3 newPos = new Vector3 (past[i].x, past[i].y, past[i].z);
			//currPos = Vector3.Lerp (currPos, newPos, Time.deltaTime * 20);
			
			target.transform.position = newPos;
			yield return null;
		}
		ClearTargetMovements();
		//recordMoment = true;
	}
}