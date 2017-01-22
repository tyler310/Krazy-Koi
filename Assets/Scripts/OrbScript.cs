using System.Collections;
using System.Collections.Generic;
using SynchronizerData;
using UnityEngine;

public class OrbScript : MonoBehaviour {

    public Vector3[] beatPositions;
    private BeatObserver beatObserver;
    private int beatCounter;

    // Use this for initialization
    void Start ()
    {
        beatObserver = GetComponent<BeatObserver>();
        beatCounter = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
        if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat)
        {
            transform.position = beatPositions[beatCounter];
            beatCounter = (++beatCounter == beatPositions.Length ? 0 : beatCounter);
        }

    }
}
