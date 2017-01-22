using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SummaryManager : MonoBehaviour {

	public Button retryButton;
	public Text finalScore;
	public Text previousScore;

	// Use this for initialization
	void Start () {
		Button btn = retryButton.GetComponent<Button>();
		btn.onClick.AddListener(RestartGame);
			
		finalScore.text = ScoreHistory.CurrentScore.ToString();
		previousScore.text = ScoreHistory.HighScore.ToString();
	}
		

	void RestartGame(){
		SceneManager.LoadScene ("Main");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
