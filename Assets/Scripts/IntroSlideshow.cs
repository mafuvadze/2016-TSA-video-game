using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using AssemblyCSharp;

public class IntroSlideshow : MonoBehaviour {

	public Image container;
	public Text text;
	public string text1, text2, text3, text4, text5;
	private Sprite[] images;
	private string[] messages;
	private int pos;

	// Use this for initialization
	void Start () {
		pos = 0;
		messages = new string[]{text1, text2, text3, text4, text5};
		text.text = messages [pos];
	}

	public void nextImage(){
		pos++;

		//change level once end of slide show is reached
		if (pos == 5) {
			SceneManager.LoadScene ("Level01");
			return;
		}

		text.text = messages [pos];
	}
		
}
