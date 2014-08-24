using UnityEngine;
using System.Collections;

public class CheckForTeleport : MonoBehaviour {

	Transform myTransofrm;
	public GameObject teleportingPrefab;
	GameObject teleportingInstance;
	bool teleporting = false;
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
				if(myTransofrm.position.y > 80f-15f){ //NORTH
					teleporting = true;
					teleportingInstance = Instantiate(teleportingPrefab) as GameObject;
					teleportingInstance.GetComponent<TeleportingText>().Teleporting("NORTH");
				} else if(myTransofrm.position.y < 15f){ //SOUTH
					teleporting = true;
					teleportingInstance = Instantiate(teleportingPrefab) as GameObject;
					teleportingInstance.GetComponent<TeleportingText>().Teleporting("SOUTH");
				} else if(myTransofrm.position.x < 15f){ //WEST
					teleporting = true;
					teleportingInstance = Instantiate(teleportingPrefab) as GameObject;
					teleportingInstance.GetComponent<TeleportingText>().Teleporting("WEST");
				} else if(myTransofrm.position.x > 80f-15f){ //EAST
					teleporting = true;
					teleportingInstance = Instantiate(teleportingPrefab) as GameObject;
					teleportingInstance.GetComponent<TeleportingText>().Teleporting("EAST");
				}
			} else {
				if(myTransofrm.position.y < 80f-15f && myTransofrm.position.y > 15f && myTransofrm.position.x > 15f && myTransofrm.position.x < 80f-15f){ 
					teleporting = false;
					teleportingInstance.GetComponent<TeleportingText>().Cancel();
				}
			}
			yield return new WaitForSeconds(.5f);
		}
	}



}
