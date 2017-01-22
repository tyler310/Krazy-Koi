using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Text ScoreText;
	public Text ComboText;
	public GameObject audioController;

	public Text rightInstructions;
	public Text leftInstructions;
	public Text clickToStart;
	public Image rightOverlay;
	public Image leftOverlay;

	public int Score = 0;
	public int Combo = 0;
	public bool gameStarted = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameStarted == false) {
			#if UNITY_STANDALONE || UNITY_WEBPLAYER
			if (Input.GetMouseButtonDown(0)) {
				gameStarted = true;
				StartGame ();
			}

			#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
			for (int i = 0; i < Input.touchCount; ++i) {
				if (Input.GetTouch (i).phase == TouchPhase.Began) {
					gameStarted = true;
					StartGame ();
				}
			}
			#endif
			if (Input.GetKeyDown("t")) {
				gameStarted = true;
				StartGame ();
			}
		}
		if (Input.GetKeyDown("n")) {
			EndGame ();
		}
	}

	public void UpdateScore(int points){
		Score += points;
		//print ("Score: " + Score);
		ScoreText.text = Score.ToString();
	}

	void StartGame(){
		audioController.GetComponent<AudioManager> ().StartGame();
		FadeUI ();
	}

	public void EndGame(){
		ScoreHistory.CurrentScore = Score;
		if (Score > ScoreHistory.HighScore) {
			ScoreHistory.HighScore = Score;
		}
		print (ScoreHistory.CurrentScore);
		SceneManager.LoadScene ("summary_screen");
	}

	public void UpdateCombo(bool hit){
		if (hit) {
			Combo += 1;
		} else {
			//COMBO BREAKERRRR
			Combo = 0;
		}
		//print ("CCCCCOMBO: " + Combo);
		ComboText.text = Combo.ToString();
	}

	void FadeUI(){
		rightInstructions.CrossFadeAlpha(0f,1f,false);
		leftInstructions.CrossFadeAlpha(0f,1f,false);
		rightOverlay.CrossFadeAlpha(0f,1f,false);
		leftOverlay.CrossFadeAlpha(0f,1f,false);
		clickToStart.CrossFadeAlpha(0f,1f,false);
	}
}
