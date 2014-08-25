using UnityEngine;
using System.Collections;

public class Start : MonoBehaviour {
	public GameObject particles;
	public GameObject menu;
	public GameObject intro;

	void Hola() {
		print("hola");
		menu.GetComponent<FadeObjectInOut>().FadeOut();
		particles.SetActive(false);
		intro.SetActive(true);
		intro.GetComponent<IntroScript>().playintro=true;
		//menu.FadeOut();
		//Application.LoadLevel("SomeLevel");
	}

}
