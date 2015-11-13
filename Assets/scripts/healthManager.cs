using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthManager : MonoBehaviour {
	public static int playerHealth;
	public int maxPlayerHealth;

	public Canvas hearts5;
	public Canvas hearts4;
	public Canvas hearts3;
	public Canvas hearts2;
	public Canvas hearts1;
	
	public bool hurt;
	public float hurtTime;

	Text text;

	private levelManager levelManager;
	public static bool isDead;
	//public GameObject arm;

	// Use this for initialization
	void Start () {
		if(Application.loadedLevelName == "level01")
		{
			PlayerPrefs.SetInt ("health", maxPlayerHealth);
			playerHealth = maxPlayerHealth;
		}
		hurtTime = 0.3f;
		hurt = false;
		text = GetComponent<Text> ();
		levelManager = FindObjectOfType<levelManager> ();
		isDead = false;
		hearts5.enabled = true;
		hearts4.enabled = false;
		hearts3.enabled = false;
		hearts2.enabled = false;
		hearts1.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (PlayerPrefs.GetInt ("health"));
		PlayerPrefs.SetInt ("health", playerHealth);
		playerHealth = PlayerPrefs.GetInt ("health");
		if(isDead)
		{
			//arm.gameObject.SetActive(false);
		}
		if(!isDead)
		{
			//arm.gameObject.SetActive(true);
		}
		if(hurt == true)
		{
			hurtTime -= Time.deltaTime;	
		}
		if(hurtTime < 0)
		{
			hurt = false;
		}
		if (playerHealth <= 0 && !isDead ) {
			//arm.gameObject.SetActive(false);
			playerHealth = 0;
			levelManager.RespawnPlayer();
			isDead = true;

		}

		text.text = "" + playerHealth;

		if(playerHealth <=100 && playerHealth > 80)
		{
			hearts5.enabled = true;
			hearts4.enabled = false;
			hearts3.enabled = false;
			hearts2.enabled = false;
			hearts1.enabled = false;
		}
		if(playerHealth <= 80 && playerHealth >= 60)
		{
			hearts5.enabled = false;
			hearts4.enabled = true;
			hearts3.enabled = false;
			hearts2.enabled = false;
			hearts1.enabled = false;
		}
		if(playerHealth <= 60 && playerHealth > 40)
		{
			hearts5.enabled = false;
			hearts4.enabled = false;
			hearts3.enabled = true;
			hearts2.enabled = false;
			hearts1.enabled = false;
		}
		if(playerHealth <= 40 && playerHealth > 20)
		{
			hearts5.enabled = false;
			hearts4.enabled = false;
			hearts3.enabled = false;
			hearts2.enabled = true;
			hearts1.enabled = false;
		}
		if(playerHealth <= 20 && playerHealth > 0)
		{
			hearts5.enabled = false;
			hearts4.enabled = false;
			hearts3.enabled = false;
			hearts2.enabled = false;
			hearts1.enabled = true;
		}
		if(playerHealth == 0)
		{
			hearts5.enabled = false;
			hearts4.enabled = false;
			hearts3.enabled = false;
			hearts2.enabled = false;
			hearts1.enabled = false;
		}
	}
	public static void HurtPlayer(int damageToGive)
	{
		playerHealth -= damageToGive;
	}
	public void FullHealth()
	{
		playerHealth = maxPlayerHealth;
	}
}
