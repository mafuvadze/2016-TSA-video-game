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
		images = new Sprite[]{Media.getPrologueImage("one"),
			Media.getPrologueImage("two"), 
			Media.getPrologueImage("three"),
			Media.getPrologueImage("four"), 
			Media.getPrologueImage("five")};
		messages = new string[]{text1, text2, text3, text4, text5};
		container.sprite = images [pos];
		text.text = messages [pos];
	}

	public void nextImage(){
		pos++;

		//change level once end of slide show is reached
		if (pos == 5) {
			container.CrossFadeAlpha (0f, 3.5f, false);
			StartCoroutine (switchLevels());
		}

		container.sprite = images [pos];
		text.text = messages [pos];
	}

	IEnumerator switchLevels(){
		yield return new WaitForSeconds (3.5f);
		SceneManager.LoadScene ("Level01");
	}
}
