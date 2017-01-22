using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2D;
	private Transform playerTransform;
	public GameObject gameController;
	public AudioSource playerAudio;
	public ParticleSystem ps;
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

			var main = ps.main;

			//If hit on black side
			if (playerRelative.x > 0 || playerRelative.x == 0 && playerRelative.y > 0) {
				if (other.GetComponent<Orb> ().CheckColor() == Color.black) {
					print ("Black: Correct!");
					//GetComponent<SpriteRenderer> ().color = Color.green;
					main.startColor = Color.white;
					ps.Play();
					gameManager.UpdateScore (scoreAmount);
					gameManager.UpdateCombo (true);
				} else {
					//print ("Black: Incorrect!");
					//GetComponent<SpriteRenderer> ().color = Color.red;
					main.startColor = Color.red;
					ps.Play();
					gameManager.UpdateScore (-scoreAmount);
					gameManager.UpdateCombo (false);
				}

			} 

			//If hit on white side
			else if (playerRelative.x < 0 || playerRelative.x == 0 && playerRelative.y < 0) {
				if (other.GetComponent<Orb> ().CheckColor() == Color.white) {
					print ("White: Correct!");
					//GetComponent<SpriteRenderer> ().color = Color.green;
					main.startColor = Color.white;
					ps.Play();
					gameManager.UpdateScore (scoreAmount);
					gameManager.UpdateCombo (true);
				} else {
					print ("White: Incorrect!");
					//GetComponent<SpriteRenderer> ().color = Color.red;
					main.startColor = Color.red;
					ps.Play();
					gameManager.UpdateScore (-scoreAmount);
					gameManager.UpdateCombo (false);
				}
			}
			playerAudio.Play ();

			Destroy (other.gameObject);
		}


	}

	void FixedUpdate() {

		#if UNITY_STANDALONE || UNITY_WEBPLAYER

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

		#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

		for (int i = 0; i < Input.touchCount; ++i) {
			Touch touch = Input.GetTouch (i);
			if (touch.position.x < Screen.width/2)
			{
				rb2D.MoveRotation(rb2D.rotation + rotationSpeed * Time.fixedDeltaTime);
			}
			else if (touch.position.x > Screen.width/2)
			{
				rb2D.MoveRotation(rb2D.rotation - rotationSpeed * Time.fixedDeltaTime);
			}
		}

		#endif
			
	}

	void Update() {
		
	}
}
