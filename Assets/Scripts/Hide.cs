using UnityEngine;
using System.Collections;

public class Hide : MonoBehaviour {
	public float wait;
	public GameObject obj;
	// Use this for initialization
	void Start () {
		StartCoroutine (Wait ());
	}

	IEnumerator Wait(){
		obj.SetActive (false);
		yield return new WaitForSeconds(wait);
		obj.SetActive (true);
	}

}
