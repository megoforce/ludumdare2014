using UnityEngine;
using System.Collections;

public class CheckForTeleport : MonoBehaviour {

	Transform myTransofrm;
	public GameObject teleportingPrefab;
	GameObject teleportingInstance;
	bool teleporting = false;
	public AudioClip teleportingFX;
	void Awake () {
		myTransofrm = transform;
	}
	void Start(){
		if(!GetComponent<CharacterProperties>().AI){
			StartCoroutine(CheckForTeleporting());
		}
	}

	IEnumerator CheckForTeleporting(){
		while(true){
			if(!teleporting){
				if(myTransofrm.position.y > 82f-15f){ //NORTH
					teleporting = true;
					teleportingInstance = Instantiate(teleportingPrefab) as GameObject;
					PlayerPrefs.SetString("direction","NORTH");
					teleportingInstance.GetComponent<TeleportingText>().Teleporting();

					MonophonicTracks.instance.Play(teleportingFX,1,RandomExt.RandomFloatBetween(.9f,1.1f));
				} else if(myTransofrm.position.y < 15f){ //SOUTH
					teleporting = true;
					teleportingInstance = Instantiate(teleportingPrefab) as GameObject;
					PlayerPrefs.SetString("direction","SOUTH");
					teleportingInstance.GetComponent<TeleportingText>().Teleporting();

					MonophonicTracks.instance.Play(teleportingFX,1,RandomExt.RandomFloatBetween(.9f,1.1f));

				} else if(myTransofrm.position.x < 15f){ //WEST
					teleporting = true;
					teleportingInstance = Instantiate(teleportingPrefab) as GameObject;
					PlayerPrefs.SetString("direction","WEST");
					teleportingInstance.GetComponent<TeleportingText>().Teleporting();

					MonophonicTracks.instance.Play(teleportingFX,1,RandomExt.RandomFloatBetween(.9f,1.1f));
				} else if(myTransofrm.position.x > 82f-15f){ //EAST
					teleporting = true;
					PlayerPrefs.SetString("direction","EAST");
					teleportingInstance = Instantiate(teleportingPrefab) as GameObject;
					teleportingInstance.GetComponent<TeleportingText>().Teleporting();

					MonophonicTracks.instance.Play(teleportingFX,1,RandomExt.RandomFloatBetween(.9f,1.1f));
				}
			} else {
				if(myTransofrm.position.y < 82f-15f && myTransofrm.position.y > 15f && myTransofrm.position.x > 15f && myTransofrm.position.x < 82f-15f){ 
					teleporting = false;
					MonophonicTracks.instance.Stop(1);
					teleportingInstance.GetComponent<TeleportingText>().Cancel();
				}
			}
			yield return new WaitForSeconds(.5f);
		}
	}

	public  static void SetNextChunkTeleport(){
		print("SetNextChunkTeleport()!!!"+PlayerPrefs.GetString("direction"));
		string direction = PlayerPrefs.GetString("direction");
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
		} else if(direction == "WEST"){
			float lng = PlayerPrefs.GetFloat("lng");
			if(lng-10 < -180){
				lng += 350;
			} else {
				lng -= 10;
			}
			PlayerPrefs.SetFloat("lng",lng);
		} else if(direction == "EAST"){
			
			float lng = PlayerPrefs.GetFloat("lng");
			if(lng+10 > 180){
				lng -= 350;
			} else {
				lng += 10;
			}
			PlayerPrefs.SetFloat("lng",lng);
		}

	}

}
