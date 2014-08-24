using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackingTrigger : MonoBehaviour {
	public List<GameObject> inColliderObjects;
	CharacterProperties characterProperties;

	void Awake(){
		characterProperties = transform.parent.parent.GetComponent<CharacterProperties>();
	}
	void OnTriggerEnter(Collider other){
		if(characterProperties.spriteName == "player" && other.tag == "NotPlayer"){
			print("enemy in range!");
			inColliderObjects.Add(other.gameObject);
		}
		if(characterProperties.spriteName == "enemy" && other.tag == "Player"){
			inColliderObjects.Add(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other){
		if(characterProperties.spriteName == "player" && other.tag == "NotPlayer"){
			inColliderObjects.Remove(other.gameObject);
		}
		if(characterProperties.spriteName == "enemy" && other.tag == "Player"){
			inColliderObjects.Remove(other.gameObject);
		}
	}
}
