using UnityEngine;
using System.Collections;

public class BackPressed : MonoBehaviour {
	public AudioClip fx;
	public ProgressSwitcher progressSwitcher;
	void OnClick(){
		MonophonicTracks.instance.Play(fx);
		progressSwitcher.Hide();

	}
}
