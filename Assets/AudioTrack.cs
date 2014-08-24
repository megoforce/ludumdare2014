using UnityEngine;
using System.Collections;

public class AudioTrack : MonoBehaviour {
	public AudioSource wind;

	// Use this for initialization
	void Start () {
		float speed = Random.Range (0, 100);
		wind.pitch = speed*0.0004f;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
