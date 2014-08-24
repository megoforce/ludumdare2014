using UnityEngine;
using System.Collections;

public class IAController : MonoBehaviour {
	CharacterProperties characterProperties;
	Transform myTransform;
	Transform playerTransform;

	void Awake(){
		characterProperties = GetComponent<CharacterProperties>();
		myTransform = transform;
		playerTransform = GlobalStuff.instance.player.transform;
	}

	void FixedUpdate () {
		if(characterProperties.AI && characterProperties.alive==true){

			//MOVE
			float deltaX = playerTransform.position.x - myTransform.position.x;
			float deltaY = playerTransform.position.y - myTransform.position.y;

			if(deltaX > 0){
				characterProperties.horizontal = .3f;
			} else if (deltaY < 0){
				characterProperties.horizontal = -.3f;
			} else {
				characterProperties.horizontal = 0;
			}

			if(deltaY > 0){
				characterProperties.vertical = .3f;
			} else if (deltaY < 0){
				characterProperties.vertical = -.3f;
			} else {
				characterProperties.vertical = 0;
			}


			//ATTACK
			float d = Vector3.Distance(GlobalStuff.instance.player.transform.position,myTransform.position);

			if(d < .5f && !characterProperties.attacking)
				characterProperties.attacking = true;
		} else {
			characterProperties.horizontal = 0;
			characterProperties.vertical = 0;
		}
	}
	
}
