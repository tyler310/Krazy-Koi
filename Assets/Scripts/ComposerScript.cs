using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComposerScript : MonoBehaviour
{

    public int bpm;
    public float crotchet;
    public float lastBeat;
    public float offset = 0.2f;
    public float songPosition;

    private float lastTime, deltaTime, timer;

    public GameObject orb;
    public Transform orbSpawn;
    public AudioSource song;

    // Use this for initialization
    void Start()
    {
        lastBeat = 0;
        crotchet = 60/bpm;
    }

    // Update is called once per frame
    void Update()
    {
//        if (songPosition > lastBeat + crotchet)
//        {
            //            songPosition = (float)(AudioSettings.dspTime – dsptimesong) * song.pitch – offset;
            //
            //            Instantiate(orb, orbSpawn);
            //	        lastBeat += crotchet;

            deltaTime = GetComponent<AudioSource>().time - lastTime;
            timer += deltaTime;

            if (timer > lastBeat + crotchet)
            {
                //Create the note
                ((GameObject) Instantiate(orb, orbSpawn)).GetComponent<Transform>().parent = GetComponent<Transform>();
                timer -= (60f/bpm);
                lastBeat += crotchet;
            }
//        }
    }
} 
