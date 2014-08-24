using UnityEngine;
using System.Collections;

public class AudioTrack : MonoBehaviour {
	public AudioSource wind;
	public AudioSource music;
	public AudioSource synth;
	public AudioSource chorus;
	bool musicup;
	bool synthup;
	bool chorusup;

	// Use this for initialization
	void Start () {
		float speed = Random.Range (0, 100);
		wind.pitch = speed*0.0004f;
		music.volume = 0;
		musicup = true;
		synthup = true;
		chorusup = false;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (musicup == true) {
			music.volume = music.volume + 0.00024f;
			if(music.volume>0.9f) {
				musicup=false;
			}
		} else {
			music.volume = music.volume - 0.00024f;
			if(music.volume<0.1f) 
				musicup=true;
		}

		if (synth == true) {
			synth.volume = synth.volume + 0.00006f;
			if(synth.volume>0.5f) {
				synthup=false;
			}
		} else {
			synth.volume = synth.volume - 0.00006f;
			if(synth.volume<0.1f) 
				synthup=true;
		}
		if (chorusup == true) {
			chorus.volume = chorus.volume + 0.00012f;
			if(chorus.volume>0.6f) {
				chorusup=false;
			}
		} else {
			chorus.volume = chorus.volume - 0.00012f;
			if(chorus.volume<0.1f)  {
				chorusup=true;
			}
		}
	}
}
