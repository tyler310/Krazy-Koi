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
	public bool startGame = false;
	public float delay = 3.352394f;

	public AudioSource audioSource;


	// Use this for initialization
	void Start () {
		LoadSong ();
		audioSource = GetComponent<AudioSource>();
		//InvokeRepeating("RandomBeatLoader", 2.0f, 1.0f);
	}

	// Update is called once per frame
	void Update () {
		if (startGame == true) {
			//StartCoroutine(BeatLoader());
			if (songStart) {
				songTime += Time.deltaTime;
				songTimeText.text = "Current Time: " + songTime;
			}
		}
	}

	void RandomBeatLoader(){
		//When Song Start
		if (songStart != true) {
			songStart = true;
			StartSong ();
		}
		//Choose Random Angle
		int randAngle = Random.Range(0,360);

		//Wait Until Beat Time
		if (songTime > 55f) {
			//End Game
			gameController.GetComponent<GameManager>().EndGame ();
		}
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

		//Choose Random Angle
		int randAngle = Random.Range(0,360);
		if (noteCount + 1 > SongArray.Length) {
			//END
			gameController.GetComponent<GameManager>().EndGame ();
		} else {
			float nextBeatTime = SongArray[noteCount] - delay;
			//Color nextBeatColor = ColorArray[noteCount];
			//float nextBeatAngle = AngleArray[noteCount];
			//print (nextBeatTime + " " + nextBeatColor + " " + nextBeatAngle);
			if (songStart != true) {
				songStart = true;
				StartSong ();
			}
				
			//Wait Until Beat Time
			if (songTime < nextBeatTime ) {
				//Do Nothing?
			} if(songTime > nextBeatTime){

				noteCount += 1;

				//Spawn Note
				Spawn spawner = gameController.GetComponent<Spawn>();
				//spawner.ChooseSpawn (nextBeatAngle);
				//spawner.SpawnOrb (nextBeatColor);

				spawner.ChooseSpawn (randAngle);
				if (Random.value > 0.5) {
					spawner.SpawnOrb (Color.white);
				} else {
					spawner.SpawnOrb (Color.black);
				}
				spawner.SpawnRing ();
			}
		}
	}

	void LoadSong(){
		SongArray = new float[]{
			1.7f,
			1.8f,
			1.9f,
			2.4f,
			3.57f,
			4.1f,
			5.23f,
			5.48f,
			5.72f,
			7.2f,
			7.39f,
			7.51f,
			7.63f,
			8.12f,
			8.82f,
			9.29f,
			9.77f,
			10.25f,
			10.71f,
			11.2f,
			12.63f,
			12.85f,
			13.07f,
			13.35f,
			14.51f,
			15f,
			15.25f,
			16.92f,
			17.04f,
			17.16f,
			18.35f,
			18.73f,
			19.05f,
			19.42f,
			19.77f,
			20.19f,
			20.58f,
			21.03f,
			23.30f,
			23.59f,
			23.83f,
			24.16f,
			24.51f,
			24.84f,
			26.48f,
			26.72f,
			28.35f,
			28.60f,
			29.80f,
			30.01f,
			30.26f,
			30.51f,
			30.75f,
			31.21f,
			31.46f,
			31.70f,
			31.95f,
			32.19f,
			32.65f,
			32.89f,
			33.12f,
			33.40f,
			33.60f,
			34.10f,
			34.31f,
			34.55f,
			34.83f,
			35.05f,
			35.51f,
			35.75f,
			35.99f,
			36.25f,
			36.46f,
			36.94f,
			37.17f,
			37.42f,
			37.70f,
			37.89f,
			38.40f,
			38.61f,
			38.74f,
			38.85f};
		//ColorArray = new Color[]{Color.black,Color.black,Color.black,Color.black,Color.white};
		//AngleArray = new float[]{0f,10f,20f,30f,40f};
	}

	void StartSong (){
		audioSource.Play();
	}

	public void StartGame(){
		startGame = true;
		InvokeRepeating("RandomBeatLoader", 2.0f, 1.0f);

	}
}
