using UnityEngine;
using System.Collections;

public class ProgressSwitcher : MonoBehaviour {

	public GameObject progress;

	public void Show(){

		GlobalStuff.instance.paused = true;
		progress.SetActive(true);
		Time.timeScale = 0;
		
	}

	public void Hide(){
		GlobalStuff.instance.paused = false;
		Time.timeScale = 1;
		progress.SetActive(false);
	}
}
