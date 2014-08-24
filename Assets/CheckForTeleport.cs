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
				if(myTransofrm.position.y > 30f){
					teleporting = true;
					teleportingInstance = Instantiate(teleportingPrefab) as GameObject;
					teleportingInstance.GetComponent<TeleportingText>().Teleporting("NORTH");
				}

				
			} else {

			}
			yield return new WaitForSeconds(1f);
		}
	}



}
