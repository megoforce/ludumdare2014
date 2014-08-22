using UnityEngine;
using System.Collections;

public class TriggerAudio : MonoBehaviour {
	public AudioClip clip;
	public float delay;
	public int track = 0;
	public float vol = 1;
	void Start () {
		StartCoroutine(PlayAudio(delay));
	}
	
	IEnumerator PlayAudio(float delay){
		yield return new WaitForSeconds(delay);
		MonophonicTracks.instance.Play(clip,track,1,vol);
	}
}
