using UnityEngine;
using System.Collections;

public class openingScene : MonoBehaviour {

	public Canvas pic1;
	public Canvas pic2;
	public Canvas pic3;
	public Canvas pic4;
	public Canvas pic5;
	public Canvas pic6;
	public static int picnumber;
	//public GameObject pic2Check;

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().Play ();
		picnumber = 1;
		pic1.enabled = true;
		pic2.enabled = false;
		pic3.enabled = false;
		pic4.enabled = false;
		pic5.enabled = false;
		pic6.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(pic6.enabled)
		{
			picnumber = 6;
		}
		if(pic5.enabled)
		{
			picnumber = 5;
		}
		if(pic4.enabled)
		{
			picnumber = 4;
		}
		//Debug.Log (picnumber);
		if(pic1.enabled == true)
		{
			picnumber = 1;
		}
		if(pic2.enabled == true)
		{
			picnumber = 2;
		}
		if(pic3.enabled == true)
		{
			picnumber = 3;
		}
		if(pic4.enabled == true)
		{
			picnumber = 4;
		}
		if(pic4.enabled == true)
		{
			picnumber = 5;
		}
		if(pic5.enabled == true)
		{
			picnumber = 6;
		}





	
	}
	public void NextButtonClicked()
	{
		if(pic4.enabled)
		{
			picnumber = 4;
		}
		if(pic5.enabled)
		{
			picnumber = 5;
		}
		if(picnumber == 1)
		{
			pic1.enabled = false;
			pic2.enabled = true;
			pic3.enabled = false;
			pic4.enabled = false;
			pic5.enabled = false;
			pic6.enabled = false;
			
		}
		if(picnumber ==2)
		{
			pic1.enabled = false;
			pic2.enabled = false;
			pic3.enabled = true;
			pic4.enabled = false;
			pic5.enabled = false;
			pic6.enabled = false;
			//Destroy(pic2Check);
	
		}
		if(picnumber == 3)
		{
			pic1.enabled = false;
			pic2.enabled = false;
			pic3.enabled = false;
			pic4.enabled = true;
			pic5.enabled = false;
			pic6.enabled = false;
		
		}
		if(picnumber ==4)
		{
			Debug.Log("pic 5");
			pic1.enabled = false;
			pic2.enabled = false;
			pic3.enabled = false;
			pic4.enabled = false;
			pic5.enabled = true;
			pic6.enabled = false;
			
		}
		if(picnumber ==5)
		{
			pic1.enabled = false;
			pic2.enabled = false;
			pic3.enabled = false;
			pic4.enabled = false;
			pic5.enabled = false;
			pic6.enabled = true;
			
		}
		if(picnumber == 5)
		{
			Application.LoadLevel ("level01");
		}

	}
}
