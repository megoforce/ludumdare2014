using UnityEngine;
using System.Collections;

public class TeleportingText : MonoBehaviour {
	CameraFilterPack_TV_Chromatical cameraFX;
	public UILabel countdown;
	UILabel label;
	void Awake(){
		label = GetComponent<UILabel>();
		cameraFX = Camera.main.GetComponent<CameraFilterPack_TV_Chromatical>();
	}

	public void Teleporting(){
		StartCoroutine(TeleportingCountdown());
	}

	public void Cancel(){
		cameraFX.enabled = false;
		StopAllCoroutines();
		Destroy(gameObject);
	}

	IEnumerator TeleportingCountdown(){
		//Start camera fx
		label.text = "TELEPORTING "+PlayerPrefs.GetString("direction")+" IN... ";
		cameraFX.enabled = true;

		for(int i = 3; i > 0;i--){
			countdown.text = i.ToString();
			yield return new WaitForSeconds(1f);
		}
		CheckForTeleport.SetNextChunkTeleport();
		Application.LoadLevel("home");
	}


}
