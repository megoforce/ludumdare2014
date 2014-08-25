using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {
	public tk2dTextMesh maestroObject;
	public tk2dTextMesh yrenkoObject;
	public GameObject objectYrenko;
	public GameObject objectMaestro;
	private bool activeMaestro = false;
	private bool activeYrenko =false;

	// Use this for initialization
	void Start () {
		objectMaestro.SetActive(false);
		objectYrenko.SetActive(false);
		StartCoroutine(IntroText());
	}

	IEnumerator IntroText()
	{
		yield return new WaitForSeconds(1f);
		activeYrenko = true;
		yrenkoObject.text = "Why did you bring me here?";

		yield return new WaitForSeconds(2f);
		activeYrenko = false;
		activeMaestro = true;
		maestroObject.text = "Our world it's falling apart Yrenko";

		yield return new WaitForSeconds(2f);
		maestroObject.text = "We have lost the WEATHER CARDS that keep our planet togheter";

		yield return new WaitForSeconds(2f);
		maestroObject.text = "If we don't find the cards soon, our dimension will collapse";

		yield return new WaitForSeconds(3f);
		activeMaestro = false;
		activeYrenko = true;
		yrenkoObject.text = "Why do i have to bother about this?";

		yield return new WaitForSeconds(3f);
		activeYrenko = false;
		activeMaestro = true;
		maestroObject.text = "Your are the only one who can defeat the demons Yrenko";

		yield return new WaitForSeconds(2f);
		maestroObject.text = "I cannot use the full potential of the mask, im too old";

		yield return new WaitForSeconds(2f);
		maestroObject.text = "But i've teached you well";

		yield return new WaitForSeconds(3f);
		activeMaestro = false;
		activeYrenko = true;
		yrenkoObject.text = "OK ";

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
