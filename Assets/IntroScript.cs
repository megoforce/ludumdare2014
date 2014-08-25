using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {
	public tk2dTextMesh maestroObject;
	public tk2dTextMesh yrenkoObject;
	public GameObject objectYrenko;
	public GameObject objectMaestro;
	private bool activeMaestro = false;
	private bool activeYrenko =false;

	public bool playintro=false;

	// Use this for initialization
	void Start () {
		objectMaestro.SetActive(false);
		objectYrenko.SetActive(false);
	}

	public void startAnimation() {
		StartCoroutine(IntroText());
	}
	

	IEnumerator IntroText() {
		if(playintro){
			yield return new WaitForSeconds(1f);
			activeYrenko = true;
			yrenkoObject.text = "Master. What's going on? Everything it's falling apart";

			yield return new WaitForSeconds(2f);
			activeYrenko = false;
			activeMaestro = true;
			maestroObject.text = "Yrenko, the crystal city it's in danger";

			yield return new WaitForSeconds(2f);
			maestroObject.text = "You must back to earth to restablish the connection...";

			yield return new WaitForSeconds(2f);
			maestroObject.text = "...between the earth and the human beigns";

			yield return new WaitForSeconds(3f);
			activeMaestro = false;
			activeYrenko = true;
			yrenkoObject.text = "How can achieve that?";

			yield return new WaitForSeconds(3f);
			activeYrenko = false;
			activeMaestro = true;
			maestroObject.text = "You must find the elemental cards, that are lose around the planet";

			yield return new WaitForSeconds(2f);
			maestroObject.text = "Be careful of the evil spirits, they will try to stop you ";

			yield return new WaitForSeconds(2f);
			maestroObject.text = "They are accountables for this tragedy, they are getting to close to the human race";

			yield return new WaitForSeconds(2f);
			maestroObject.text = "Search for the 4 totems that will transport you through the planet";

			yield return new WaitForSeconds(3f);
			activeMaestro = false;
			activeYrenko = true;
			yrenkoObject.text = "Ok master, i will find those cards";


			yield return new WaitForSeconds(3f);
			activeYrenko = false;
			activeMaestro = true;
			maestroObject.text = "Take this mask, will help you around";


			yield return new WaitForSeconds(2f);
			maestroObject.text = "A last thing, Our faith it's in your hand Yrenko";

			yield return new WaitForSeconds(5f);
			Application.LoadLevel("home");

		}

	}
	
	// Update is called once per frame
	void Update () {
		if(activeMaestro) {
			//turn off yrenko
			objectYrenko.SetActive(false);

			//turn on master
			objectMaestro.SetActive(true);
		}
		if (activeYrenko) {
			//turn on yrenko
			objectYrenko.SetActive(true);

			//turn off master
			objectMaestro.SetActive(false);
		}
	}
}
