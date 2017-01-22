using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FlipColor(){
		GetComponent<SpriteRenderer> ().color = (GetComponent<SpriteRenderer> ().color == Color.white)? Color.black : Color.white;
	}

	public void ChangeColor(Color desiredColor){
		GetComponent<SpriteRenderer> ().color = desiredColor;
	}

	public Color CheckColor(){
		return GetComponent<SpriteRenderer> ().color;
	}
}
