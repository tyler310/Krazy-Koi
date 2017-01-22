using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

	public Button startButton;
	public RectTransform koiFish;
	public float koiSpeed;
	public float scaleSpeed;

	public Image background;
	public Image backgroundCircle;
	public Image startButtonUI;
	public Image title;

	private bool transition = false;

	void Start () {
		Button btn = startButton.GetComponent<Button>();
		btn.onClick.AddListener(StartLoadScene);
	}
	void Update(){
		KoiAnimation (transition);
	}

	void StartLoadScene(){
		TransitionAnimation ();
		StartCoroutine("LoadScene");
	}

	IEnumerator LoadScene(){
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene ("Main");
	}

	void KoiAnimation(bool transition){
		koiFish.Rotate(Vector3.forward * koiSpeed);
		if (transition) {
			koiSpeed += 0.2f;
			if (koiFish.localScale.x >= 0.3f && koiFish.localScale.y >= 0.3f) {
				koiFish.localScale -= new Vector3(scaleSpeed, scaleSpeed, 0);
			}
		}

	}

	void TransitionAnimation(){
		FadeUI ();
		transition = true;
	}

	void FadeUI(){
		background.CrossFadeAlpha(0.01f,1f,false);
		backgroundCircle.CrossFadeAlpha(0.01f,1f,false);
		startButtonUI.CrossFadeAlpha(0.01f,1f,false);

		Color c = startButtonUI.color;
		c.a = 0f;
		startButtonUI.color = c;
		title.CrossFadeAlpha(0.01f,1f,false);
	}

}
