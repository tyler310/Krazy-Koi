using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	public GameObject orbPrefab;
	public GameObject ringPrefab;
	public Transform spawnTransform;
	public float spawnRadius;
	public float orbSpeed;
	public float spawnDegrees = 0;
	// Use this for initialization
	public float diffTimer = 0;
	public bool startedTimer = false;

	void Start () {
	}

	void FixedUpdate () {
	}

	void Update(){
		if (startedTimer == true) {
			diffTimer += Time.deltaTime;
		}
		if (Input.GetKeyDown ("q")) {
			//Black
			SpawnOrb (Color.black);
			SpawnRing ();
		}
		else if (Input.GetKeyDown ("e")) {
			//White
			SpawnOrb (Color.white);
			SpawnRing ();
		}
		if (Input.GetKeyDown ("1")) {
			if (spawnDegrees == 360) {
				spawnDegrees = 0;		
			}
			spawnDegrees += 10;
			print (spawnDegrees);
			ChooseSpawn (spawnDegrees);
		}else if(Input.GetKeyDown ("3")){
			if (spawnDegrees == 0) {
				spawnDegrees = 360;		
			}
			spawnDegrees -= 10;
			print (spawnDegrees);
			ChooseSpawn (spawnDegrees);
		}
	}

	public void SpawnOrb(Color desiredColor){
		GameObject orbClone = (GameObject)Instantiate(orbPrefab, spawnTransform.position, spawnTransform.rotation);
		Vector2 movement = new Vector2 (0.0f, 0.0f) - new Vector2(spawnTransform.position.x, spawnTransform.position.y);
		orbClone.GetComponent<Rigidbody2D>().velocity = movement * orbSpeed;
		orbClone.GetComponent<Orb>().ChangeColor (desiredColor);
		StartTimer ();
	}

	public void SpawnRing(){
		GameObject ringClone = (GameObject)Instantiate(ringPrefab, Vector3.zero, Quaternion.identity);
	}
		
	void MoveSpawn(Vector3 newPos){
		spawnTransform.position = newPos;
	}

	public void ChooseSpawn(float ang){
		Vector3 pos;
		pos.x = spawnRadius * Mathf.Sin(ang * Mathf.Deg2Rad);
		pos.y = spawnRadius * Mathf.Cos(ang * Mathf.Deg2Rad);
		pos.z = 0;
		MoveSpawn (pos);
	}

	public void StartTimer(){
		startedTimer = true;
	}
	public void EndTimer(){
		startedTimer = false;
		print (diffTimer);
	}
}
