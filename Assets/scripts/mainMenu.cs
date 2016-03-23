using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
	
	public Image menu;
	public Text text;

	void Start(){
		text.CrossFadeAlpha (.25f, 4.5f, false);
		StartCoroutine (delay(4.5f));
	}
	public void playClicked()
	{
		menu.CrossFadeAlpha (0f, 4.5f, false);
		StartCoroutine (switchLevel());
	}

	IEnumerator switchLevel(){
		yield return new WaitForSeconds (4.5f);
		text.text = "";
		SceneManager.LoadScene ("Prologue");

	}

	IEnumerator delay(float time){
		yield return new WaitForSeconds (time);
		text.text = "";
	}
		
	public void quit()
	{
		Application.Quit ();
	}
}
