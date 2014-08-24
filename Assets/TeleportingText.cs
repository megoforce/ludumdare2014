using UnityEngine;
using System.Collections;

public class TeleportingText : MonoBehaviour {
	CameraFilterPack_TV_Chromatical cameraFX;
	public UILabel countdown;
	string direction;
	UILabel label;
	void Awake(){
		label = GetComponent<UILabel>();
		cameraFX = Camera.main.GetComponent<CameraFilterPack_TV_Chromatical>();
	}

	public void Teleporting(string dir){
		direction = dir;
		StartCoroutine(TeleportingCountdown());
	}

	public void Cancel(){
		StopAllCoroutines();
		Destroy(gameObject);
	}

	IEnumerator TeleportingCountdown(){
		//Start camera fx
		label.text = "TELEPORTING "+direction+" IN... ";
		cameraFX.enabled = true;

		for(int i = 3; i > 0;i--){
			countdown.text = i.ToString();
			yield return new WaitForSeconds(1f);
		}
		//TODO teleport!!
		if(direction == "NORTH"){
			float lat = PlayerPrefs.GetFloat("lat");
			if(lat+10 > 90){
				lat -= 170;
			} else {
				lat += 10;
			}
			PlayerPrefs.SetFloat("lat",lat);
		} else if(direction == "SOUTH"){
			float lat = PlayerPrefs.GetFloat("lat");
			if(lat-10 < -90){
				lat += 170;
			} else {
				lat -= 10;
			}
			PlayerPrefs.SetFloat("lat",lat);
		}

		 

		Application.LoadLevel("home");
	}
}
