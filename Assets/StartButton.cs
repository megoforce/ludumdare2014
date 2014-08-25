using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	public TweenRotation containerIntro;
	public TweenAlpha tweenAlphaFade;
	public AudioClip clickSound;
	public void OnClick(){
		containerIntro.Play(true);
		tweenAlphaFade.Play(true);
		Screen.fullScreen = true;
		MonophonicTracks.instance.Play(clickSound);
	}
}
