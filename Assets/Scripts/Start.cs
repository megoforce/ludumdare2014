using UnityEngine;
using System.Collections;

public class Start : MonoBehaviour {
	public TweenAlpha tween;
	public GameObject particles;
	public GameObject menu;
	public GameObject intro;
	public GameObject startButton;

	void Hola() {
		tween.Play(true);


		startButton.SetActive(false);
		//Application.LoadLevel("SomeLevel");
	}
	public void EndFade(){
		menu.SetActive(false);
		particles.SetActive(false);
		intro.SetActive(true);
		intro.GetComponent<IntroScript>().playintro=true;
		intro.GetComponent<IntroScript>().startAnimation();
		tween.gameObject.SetActive(false);
	}

}
