using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour {
	public AudioClip fx;
	void OnClick(){
		MonophonicTracks.instance.Play(fx);
		GameDataLoader.ResetData();
		Application.LoadLevel("intro");
	}
}
