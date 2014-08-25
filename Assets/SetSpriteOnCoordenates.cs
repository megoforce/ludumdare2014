using UnityEngine;
using System.Collections;

public class SetSpriteOnCoordenates : MonoBehaviour {

	float lat, lng;
	void OnEnable () {
		lat = PlayerPrefs.GetFloat("lat");
		lng = PlayerPrefs.GetFloat("lng");

		float pixelLat = lat*(131f/90f);
		float pixelLng = lng*(256f/180f);
		transform.localPosition = new Vector3(pixelLng,pixelLat,0);
	}

}
