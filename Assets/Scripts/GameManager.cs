using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text ScoreText;
	public Text ComboText;
	public GameObject audioController;

	public int Score = 0;
	public int Combo = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			StartGame ();
		}
	}

	public void UpdateScore(int points){
		Score += points;
		//print ("Score: " + Score);
		ScoreText.text = Score.ToString();
	}

	void StartGame(){
		
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

}
