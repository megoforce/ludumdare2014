using UnityEngine;
using System.Collections;

public class CharacterAnimations : MonoBehaviour {
	public tk2dSprite sprite;
	CharacterProperties characterProperties;
	void Awake(){
		characterProperties = GetComponent<CharacterProperties>();
	}

	int fCounter = 0;
	void FixedUpdate(){
		fCounter ++;

		if(characterProperties.horizontal != 0 || characterProperties.vertical != 0){
			if(Mathf.Abs(characterProperties.horizontal) >= Mathf.Abs(characterProperties.vertical)){
				WalkH(characterProperties.horizontal);
			} else if(Mathf.Abs(characterProperties.horizontal) <= Mathf.Abs(characterProperties.vertical)){
				WalkV(characterProperties.vertical);
			}
		}
	}
	/*
		0 1 2 down
		3 4 5 left
		6 7 8 right
		9 10 11 up
	 */

	int offsetH = 0;

	void WalkH(float speed){
		int v = 10 - (int)(Mathf.Abs(speed*6));

		if(speed > 0){
			sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+(8 - offsetH).ToString());
		} else {
			sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+(5 - offsetH).ToString());
		}

		if((fCounter % v) == 0){
			offsetH = (offsetH + 1 == 3) ? 0 : offsetH + 1;
		}
	}
	void WalkV(float speed){
		int v = 10 - (int)(Mathf.Abs(speed*6));
		
		if(speed > 0){
			sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+(11 - offsetH).ToString());
		} else {
				sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+(2 - offsetH).ToString());
		}
		
		if((fCounter % v) == 0){
			offsetH = (offsetH + 1 == 3) ? 0 : offsetH + 1;
		}
	}
}













