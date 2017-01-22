using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

	public GameObject gameController;
	public float[] SongArray;
	public Color[] ColorArray;
	public float[] AngleArray;
	public float songTime = 0;
	public Text songTimeText;
	public bool songStart = false;
	public int noteCount = 0;

	public AudioSource audioSource;


	// Use this for initialization
	void Start () {
		LoadSong ();
		audioSource = GetComponent<AudioSource>();
		InvokeRepeating("RandomBeatLoader", 2.0f, 1.0f);
	}

	// Update is called once per frame
	void Update () {
		//StartCoroutine(BeatLoader());
		if (songStart) {
			songTime += Time.deltaTime;
			songTimeText.text = "Current Time: " + songTime;
		}
	}

	void RandomBeatLoader(){
		//Load song map
		//Song map should include timing + color
		//When Song Start
		if (songStart != true) {
			songStart = true;
			StartSong ();
		}
		//Choose Random Angle
		int randAngle = Random.Range(0,360);

		//Wait Until Beat Time
		//Spawn Note
		Spawn spawner = gameController.GetComponent<Spawn>();
		spawner.ChooseSpawn (randAngle);
		if (Random.value > 0.5) {
			spawner.SpawnOrb (Color.white);
		} else {
			spawner.SpawnOrb (Color.black);
		}
		spawner.SpawnRing ();
	}

	IEnumerator BeatLoader(){
		//Wait 2 seconds this is sooo badddd
		yield return new WaitForSeconds(2f);
		//Over Length END SONG
		if (noteCount + 1 > SongArray.Length) {
			//END
		} else {
			float nextBeatTime = SongArray[noteCount];
			Color nextBeatColor = ColorArray[noteCount];
			float nextBeatAngle = AngleArray[noteCount];
			print (nextBeatTime + " " + nextBeatColor + " " + nextBeatAngle);
			if (songStart != true) {
				songStart = true;
				StartSong ();
			}
				
			//Wait Until Beat Time
			if (songTime < nextBeatTime) {
				//Do Nothing?
			} if(songTime > nextBeatTime){

				noteCount += 1;

				//Spawn Note
				Spawn spawner = gameController.GetComponent<Spawn>();
				spawner.ChooseSpawn (nextBeatAngle);
				spawner.SpawnOrb (nextBeatColor);
				spawner.SpawnRing ();
			}
		}
	}

	void LoadSong(){
		SongArray = new float[]{0.5f,1f,1.5f,3f,5f};
		ColorArray = new Color[]{Color.black,Color.black,Color.black,Color.black,Color.white};
		AngleArray = new float[]{0f,10f,20f,30f,40f};
	}

	void StartSong (){
		audioSource.Play();
	}
}
