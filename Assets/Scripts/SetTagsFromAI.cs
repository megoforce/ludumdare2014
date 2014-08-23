using UnityEngine;
using System.Collections;

public class SetTagsFromAI : MonoBehaviour {
	public GameObject character;
	public GameObject sprite;
	void Awake(){
		if(!GetComponent<CharacterProperties>().AI){
			character.tag = "Player";
			sprite.tag = "PlayerSprite";
		} else {
			character.tag = "NotPlayer";
			sprite.tag = "NotPlayerSprite";
		}
	}
}
