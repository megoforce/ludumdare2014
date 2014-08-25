using UnityEngine;
using System.Collections;

public class ProgressSwitcher : MonoBehaviour {
	public Collider backCollider;
	public TweenAlpha tweenFade;
	public void Show(){
		tweenFade.ResetToBeginning();
		tweenFade.Play(true);
		backCollider.enabled = true;
		Time.timeScale = 0;
	}

	public void Hide(){
		Time.timeScale = 1;
		tweenFade.ResetToBeginning();
		tweenFade.Play(false);
		backCollider.enabled = false;
	}
}
