using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour {

	private Transform ringTransform;
	private SpriteRenderer ringRenderer;
	public float startScale = 1.65f;
	public float scaleSpeed = 0.1F;
	private float opacity = 0.15f;

	// Use this for initialization
	void Start () {
		ringTransform = GetComponent<Transform> ();
		ringRenderer = GetComponent<SpriteRenderer> ();
		ringTransform.localScale = new Vector3 (startScale, startScale, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (ringTransform.localScale.x <= 0.1 && ringTransform.localScale.y <= 0.1) {
			Destroy (gameObject);
		}
		opacity += 0.01f;
		ringRenderer.color = new Color (1f, 1f, 1f, opacity);
		ringTransform.localScale -= new Vector3(scaleSpeed, scaleSpeed, 0);
		//ringTransform.localScale = Vector3.Lerp (ringTransform.localScale, Vector3.zero, scaleSpeed * Time.deltaTime);
	}
}
