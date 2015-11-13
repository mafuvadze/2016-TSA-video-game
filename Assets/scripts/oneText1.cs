using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class oneText1 : MonoBehaviour {
	
	Text txt;
	public float letterPause = 0.035f;
	//public AudioClip sound;
	public GUIStyle font;
	public string message;
	string text;
	//public GameObject pic2Check;
	//public GameObject pic3Check;
	public bool textThere;
	//public GameObject sound;
	
	void Start () 
	{
		//sound.GetComponent<AudioSource>().mute = false;
		textThere = false;
		txt = gameObject.GetComponent<Text>(); 
		txt.text = text;
		//message = "";
		text = "";
		//StartCoroutine(TypeText());
	}
	
	IEnumerator TypeText () 
	{
		Debug.Log ("started");
		foreach (char letter in message.ToCharArray()) 
		{
			text += letter;
			//if (sound)
			//audio.PlayOneShot (sound);
			yield return 0;
			yield return new WaitForSeconds (letterPause);
		}      
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(0, 0, 256, 1024), text, font);    
	}
	
	void Update()
	{
		if(textThere == false && openingScene.picnumber == 2)
		{
			textThere = true;
			StartCoroutine(TypeText());
		}
		Debug.Log(openingScene.picnumber);
		if(txt.text == message && openingScene.picnumber == 3)
		{
			//Destroy (pic3Check.gameObject);
			//StopAllCoroutines();
		}
		if(txt.text != message)
		{
			//sound.GetComponent<AudioSource>().Play ();
		}
		if(txt.text == message && openingScene.picnumber == 2)
		{
			//sound.GetComponent<AudioSource>().mute = true;
		}
		txt.text = text;
		//Debug.Log (text);
		if(Input.GetKeyDown (KeyCode.Return))
		{
			StopAllCoroutines();
			text = message;
		}
	}
}
