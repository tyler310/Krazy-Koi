using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFilter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().sprite.texture.filterMode = FilterMode.Point;
	}
}
