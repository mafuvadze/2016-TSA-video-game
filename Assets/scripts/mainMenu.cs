using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
	
	public Image menu;
	public void playClicked()
	{
		menu.CrossFadeAlpha (0f, 4.5f, false);
		StartCoroutine (switchLevel());
	}

	IEnumerator switchLevel(){
		yield return new WaitForSeconds (4.5f);
		SceneManager.LoadScene ("openingMessage");

	}
		
	public void quit()
	{
		Application.Quit ();
	}
	public void credits()
	{
		print ("Credits Button Clicked");
	}
}
