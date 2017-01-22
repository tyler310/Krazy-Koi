using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2D;
	private Transform playerTransform;
	public GameObject gameController;
	public float rotationSpeed = 150;

	//Change this if you want different scores;
	public int scoreAmount = 50;


	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
		playerTransform = GetComponent<Transform> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Orb") {
			Transform orbTransform = other.GetComponent<Transform> ();

			//Vector2 direction = other.GetComponent<Transform> ().position - playerTransform.position;
			//Debug.DrawRay(playerTransform.position, direction, Color.red);

			Vector2 playerRelative = playerTransform.InverseTransformPoint(orbTransform.position);
			GameManager gameManager = gameController.GetComponent<GameManager> ();

			//If hit on black side
			if (playerRelative.x > 0 || playerRelative.x == 0 && playerRelative.y > 0) {
				if (other.GetComponent<Orb> ().CheckColor() == Color.black) {
					print ("Black: Correct!");
					//GetComponent<SpriteRenderer> ().color = Color.green;

					gameManager.UpdateScore (scoreAmount);
					gameManager.UpdateCombo (true);
				} else {
					//print ("Black: Incorrect!");
					//GetComponent<SpriteRenderer> ().color = Color.red;

					gameManager.UpdateScore (-scoreAmount);
					gameManager.UpdateCombo (false);
				}

			} 

			//If hit on white side
			else if (playerRelative.x < 0 || playerRelative.x == 0 && playerRelative.y < 0) {
				if (other.GetComponent<Orb> ().CheckColor() == Color.white) {
					print ("White: Correct!");
					//GetComponent<SpriteRenderer> ().color = Color.green;
					gameManager.UpdateScore (scoreAmount);
					gameManager.UpdateCombo (true);
				} else {
					print ("White: Incorrect!");
					//GetComponent<SpriteRenderer> ().color = Color.red;
					gameManager.UpdateScore (-scoreAmount);
					gameManager.UpdateCombo (false);
				}
			}


			Destroy (other.gameObject);
		}


	}

	void FixedUpdate() {
		if (Input.GetKey ("left") && Input.GetKey ("right")) {
			//do nothing
		} else {
			if (Input.GetKey ("left")) {
				rb2D.MoveRotation(rb2D.rotation + rotationSpeed * Time.fixedDeltaTime);
			}
			if (Input.GetKey ("right")) {
				rb2D.MoveRotation(rb2D.rotation - rotationSpeed * Time.fixedDeltaTime);
			}
		}

		//TODO: Add mobile Controls
	}

	void Update() {
		
	}
}
