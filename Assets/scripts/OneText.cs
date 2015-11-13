using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OneText : MonoBehaviour {

	 	Text txt;
		public float letterPause = 0.035f;
		//public AudioClip sound;
		public GUIStyle font;
		public string message;
		string text;
		public GameObject pic2Check;
		//public GameObject sound;
		
		void Start () 
		{
			txt = gameObject.GetComponent<Text>(); 
			txt.text = text;
			//message = "";
			text = "";
			StartCoroutine(TypeText());
		}
		
		IEnumerator TypeText () 
		{
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
		if(txt.text == message && openingScene.picnumber == 2)
		{
			//Destroy(pic2Check.gameObject);
			//StopAllCoroutines();
		}
		if(txt.text != message)
		{
			//sound.GetComponent<AudioSource>().Play ();
		}
		if(txt.text == message && openingScene.picnumber ==1)
		{
			//sound.GetComponent<AudioSource>().mute = true;
			//sound.audio.Stop();
		}
		if(openingScene.picnumber == 2)
		{
			//sound.GetComponent<AudioSource>().mute = false;
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
