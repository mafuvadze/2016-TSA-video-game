using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public static GameObject dialog, pauseBtn, clues, points, pauseMenu, selector, blackScreen, gameMessenger;
	static Canvas pauseCanvas, selectorCanvas, blackScreenCanvas, pauseBtnCanvas, cluesCanvas, dialogCanvas, gameMsgCanvas;
	static Sprite pauseImg, blank;
	static Text cluesText, pointsText, yearGuess, text, gameMsgText;
	private const string pointsData = "POINTS", cluesData = "CLUES";
	static Image pauseSprite, icon;
	public static bool disableMovement, gameMsgShown, dialogShown, gameOver;
	public static Speech[] words;
	private static int pos;

	void Awake () {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		dialog = GameObject.Instantiate(Media.getPrefab ("Dialog"));
		pauseBtn = GameObject.Instantiate(Media.getPrefab ("Pause Button"));
		clues = GameObject.Instantiate(Media.getPrefab ("Clues Progress"));
		points = GameObject.Instantiate(Media.getPrefab ("Points"));
		pauseMenu = GameObject.Instantiate(Media.getPrefab ("Pause Menu"));
		selector = GameObject.Instantiate(Media.getPrefab("Year Selector"));
		blackScreen = GameObject.Instantiate (Media.getPrefab("Black Screen"));
		gameMessenger = GameObject.Instantiate (Media.getPrefab("In-Game Popup"));

		pauseCanvas = pauseMenu.GetComponentInChildren<Canvas> ();
		selectorCanvas = selector.GetComponentInChildren<Canvas> ();
		blackScreenCanvas = blackScreen.GetComponentInChildren<Canvas> ();
		pauseBtnCanvas = pauseBtn.GetComponentInChildren<Canvas> ();
		cluesCanvas = clues.GetComponentInChildren<Canvas> ();
		dialogCanvas = dialog.gameObject.GetComponent<Canvas> ();
		gameMsgCanvas = gameMessenger.GetComponent<Canvas> ();
		pauseCanvas.enabled = false;

		cluesText = cluesCanvas.GetComponentInChildren<Text> ();
		pointsText = points.GetComponentInChildren<Text> ();
		yearGuess = (selectorCanvas.GetComponentsInChildren<Text> ())[1];
		pauseSprite = (pauseBtnCanvas.GetComponentsInChildren<Image> ())[1];

		pauseImg = Media.getImage ("pause");
		blank = Media.getImage ("outline");
		pauseSprite.sprite = pauseImg;

		icon = (dialogCanvas.GetComponentsInChildren<Image> ())[1];
		text = dialogCanvas.GetComponentInChildren<Text>();
		gameMsgText = gameMsgCanvas.GetComponentInChildren<Text> ();

		hideBlackScreen ();
		hideSelector ();
		hideGameMsgCanvas ();

		gameOver = false;
		resetClues ();

		//reset player data on first level
		if (SceneManager.GetActiveScene ().name == "Level01") {
			PlayerPrefs.DeleteAll ();
			resetClues ();
			resetPoints ();
		} else {
			updateClues ();
			updatePoints ();
		}
			
	}


	public static void instantiateObj(GameObject obj){
		obj = GameObject.Instantiate (obj);
	}

	public static void destroyObj(GameObject obj){
		Destroy (obj);
	}

	public static void pause(){
		pauseCanvas.enabled = true;
		hidePauseBtn ();
		hideGameMsgCanvas ();
		hideDialog ();
	}

	public static void resume(){
		pauseCanvas.enabled = false;
		showPauseBtn ();

		if (gameMsgShown) {
			showGameMsgCanvas ();
		}

		if(dialogShown){
			showDialog ();
		}
	}

	public static void showSelector(){
		selectorCanvas.enabled = true;
	}

	public static void hideSelector(){
		selectorCanvas.enabled = false;
	}

	public static void showBlackScreen(){
		blackScreenCanvas.enabled = true;
	}

	public static void hideBlackScreen(){
		blackScreenCanvas.enabled = false;
	}

	public static void showPauseBtn(){
		pauseSprite.sprite = blank;
	}

	public static void hidePauseBtn(){
		pauseSprite.sprite = pauseImg;
	}

	public static void showClues(){
		cluesCanvas.enabled = true;
	}

	public static void hideClues(){
		cluesCanvas.enabled = false;
	}

	public static void incrementClues(){
		int currentValue = PlayerPrefs.GetInt (cluesData);
		PlayerPrefs.SetInt (cluesData, ++currentValue);
		updateClues ();
	}

	public static void incrementPoints(int value){
		int currentValue = PlayerPrefs.GetInt (pointsData);
		PlayerPrefs.SetInt (pointsData, currentValue + value);
		updatePoints ();
	}

	public static void updateClues(){
		cluesText.text = "Clues: " + PlayerPrefs.GetInt (cluesData) + " of 3";
	}
	public static void updatePoints(){
		pointsText.text = "Score: " + PlayerPrefs.GetInt (pointsData);
	}

	public static void resetClues(){
		PlayerPrefs.SetInt (cluesData, 0);
		updateClues ();
	}

	public static void resetPoints(){
		PlayerPrefs.SetInt (pointsData, 0);
		updatePoints ();
	}

	public void onSubmitClicked(){
		int year = getYearEntered();

		string msg = "You guessed " + year + ". The correct year was " + getCorrectYear() 
			+ "\nYou scored " + calculatePoints(year, getCorrectYear()) + " points";
			Speech s1 = new Speech ("Game", "Level complete","messick");
			Speech s2 = new Speech ("Game", msg,"messick");
			Speech[] end = new Speech[]{s1, s2};
			gameOver = true;
			displayText (end, true);

	}

	private static int calculatePoints (int guess, int correct){
		int diff = Mathf.Abs (correct - guess);
		int score = 100 - diff;
		if (score >= 0) {
			incrementPoints (score);
			updatePoints ();
			return score;
		} else {
			return 0;
		}

	}

	private static int getYearEntered(){
		int year = int.Parse (yearGuess.text);
		return year;
	}

	public static void showDialog(){
		dialogCanvas.enabled = true;
	}

	public static void hideDialog(){
		dialogCanvas.enabled = false;
	}

	public static void setDialogIcon(Sprite img){
		icon.sprite = img;
	}

	public static void setDialogText(string msg){
		instance.startTextCoroutine(msg);
	}

	public void startTextCoroutine(string msg){
		//can't start coroutine from static method so l made a filler method
		StartCoroutine (showTextCoroutine(msg));
	}

	IEnumerator showTextCoroutine(string msg){
		foreach (char letter in msg.ToCharArray()) {
			text.text += letter;
			yield return new WaitForSeconds (.010f);
		}
	}

	public static void displayText(Speech[] dialog, bool disablePlayer){
		words = dialog;
		disableMovement = disablePlayer;

		pos = 0;
		dialogShown = true;
		if (disableMovement) {
			player.disableMovement ();
			Player2.disableMovement ();
		}
		showBlackScreen ();
		showText ();
	}

	public static void showText(){
		Speech speech = words [pos];
		string src = speech.getSrc ();
		string message = speech.getMsg ();
		Sprite pic = speech.getIcon ();
		GameManager.setDialogIcon (pic);
		text.text = "";
		text.text = "<color=#1e90ff>" + src + "</color>\n";
		GameManager.setDialogText (message);
		if (disableMovement) {
			player.disableMovement ();
			Player2.disableMovement ();
		}
		showDialog ();
	}

	public void incrementPos(){
		if ((pos + 1)< (words.Length)) {
			pos++;
			showText ();
		} else {
			finish ();
			if (gameOver) {
				if (SceneManager.GetActiveScene ().name == "Level01") {
					SceneManager.LoadScene ("Level02");
				}else if (SceneManager.GetActiveScene ().name == "Level02") {
					SceneManager.LoadScene ("Level03");
				}else if (SceneManager.GetActiveScene ().name == "Level03") {
					SceneManager.LoadScene ("Level04");
				}
			}
		}
	}

	public static void finish(){
		//end of dialog reached
		dialogShown = false;
		hideDialog ();
		hideBlackScreen ();
		if (disableMovement) {
			player.enableMovement ();
			Player2.enableMovement ();
		}
	}


	public static void showGameMsgCanvas(){
		gameMsgCanvas.enabled = true;
	}

	public static void hideGameMsgCanvas(){
		gameMsgCanvas.enabled = false;
	}

	public static void displayGameMessage(MessageSeq[] seq){
		showGameMsgCanvas ();
	
		gameMsgShown = true;
		if (seq [0].getDuration() != -1f) {
			instance.continueGameMessage (seq);
		} else {
			gameMsgText.text = seq [0].getMsg ();
		}
	}

	public void continueGameMessage(MessageSeq[] seq){
		StartCoroutine (showGameMessage(seq));
	} 

	IEnumerator showGameMessage(MessageSeq[] seq){
		foreach (MessageSeq sequence in seq){
			gameMsgText.text = sequence.getMsg ();
			//yield return 0;
			yield return new WaitForSeconds (sequence.getDuration());
		}
			
		hideGameMsgCanvas ();
		gameMsgShown = false;
	}

	public static int getCorrectYear(){
		if (SceneManager.GetActiveScene ().name.Equals ("Level01")) {
			return 1775;
		} else if (SceneManager.GetActiveScene ().name.Equals ("Level02")) {
			return 1868;
		} else {
			return -1;
		}
	}
		
	// Update is called once per frame
	void Update () {
	
	}
}
