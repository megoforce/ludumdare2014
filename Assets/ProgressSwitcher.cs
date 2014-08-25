using UnityEngine;
using System.Collections;

public class ProgressSwitcher : MonoBehaviour {

	public GameObject progress;
	public AudioClip fx;
	public void Show(){
		MonophonicTracks.instance.Play(fx);
		GlobalStuff.instance.paused = true;
		progress.SetActive(true);
		Time.timeScale = 0;
		
	}

	public void Hide(){
		MonophonicTracks.instance.Play(fx);
		GlobalStuff.instance.paused = false;
		Time.timeScale = 1;
		progress.SetActive(false);
	}
}
