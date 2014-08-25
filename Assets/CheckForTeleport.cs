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
					teleportingInstance.GetComponent<TeleportingText>().Teleporting("NORTH");
					MonophonicTracks.instance.Play(teleportingFX,1,RandomExt.RandomFloatBetween(.9f,1.1f));
				} else if(myTransofrm.position.y < 15f){ //SOUTH
					teleporting = true;
					teleportingInstance = Instantiate(teleportingPrefab) as GameObject;
					teleportingInstance.GetComponent<TeleportingText>().Teleporting("SOUTH");
					MonophonicTracks.instance.Play(teleportingFX,1,RandomExt.RandomFloatBetween(.9f,1.1f));
				} else if(myTransofrm.position.x < 15f){ //WEST
					teleporting = true;
					teleportingInstance = Instantiate(teleportingPrefab) as GameObject;
					teleportingInstance.GetComponent<TeleportingText>().Teleporting("WEST");
					MonophonicTracks.instance.Play(teleportingFX,1,RandomExt.RandomFloatBetween(.9f,1.1f));
				} else if(myTransofrm.position.x > 82f-15f){ //EAST
					teleporting = true;
					teleportingInstance = Instantiate(teleportingPrefab) as GameObject;
					teleportingInstance.GetComponent<TeleportingText>().Teleporting("EAST");
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



}
