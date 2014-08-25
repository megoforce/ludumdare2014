using UnityEngine;
using System.Collections;
using InControl;

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
			yrenkoObject.text = "Master. THE CRYSTAL CITY IT'S COLLAPSING!!";

			yield return new WaitForSeconds(2f);
			activeYrenko = false;
			activeMaestro = true;
			maestroObject.text = "Yrenko, the balance has been broken";

			yield return new WaitForSeconds(2f);
			maestroObject.text = "You must back to earth to restablish the connection...";

			yield return new WaitForSeconds(2f);
			maestroObject.text = "...between the nature and the human beings";

			yield return new WaitForSeconds(3f);
			activeMaestro = false;
			activeYrenko = true;
			yrenkoObject.text = "But master, that's imposible! The earth is full of demons!!";

			yield return new WaitForSeconds(3f);
			activeYrenko = false;
			activeMaestro = true;
			maestroObject.text = "Young Yrenko, your destiny is already written";

			yield return new WaitForSeconds(2f);
			maestroObject.text = "You are the only one who can use the mask of Andacollo";

			yield return new WaitForSeconds(2f);
			maestroObject.text = "Get the 5 ELEMENTAL CARDS. stored on the TOTEMS";

			yield return new WaitForSeconds(2f);
			maestroObject.text = "Each totem spawn on a place on the earth who has that climate";

			yield return new WaitForSeconds(2f);
			maestroObject.text = "Search for those climates on weather channels, and live feeds";

			yield return new WaitForSeconds(3f);
			activeMaestro = false;
			activeYrenko = true;
			yrenkoObject.text = "Ok master, i will find those cards!";


			yield return new WaitForSeconds(3f);
			activeYrenko = false;
			activeMaestro = true;
			maestroObject.text = "A last thing. Our faith of in your hand";

			yield return new WaitForSeconds(5f);
			Application.LoadLevel("home");

		}

	}

	void OnMouseOver() {
		if(playintro){
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

		InputDevice inputDevice = InputManager.ActiveDevice;
		if(playintro && inputDevice.Action1.WasPressed){
			Application.LoadLevel("home");
		}
	}
}
