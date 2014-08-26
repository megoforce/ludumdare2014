using UnityEngine;
using System.Collections;

public class CharacterAnimations : MonoBehaviour {
	public tk2dSprite sprite;
	CharacterProperties characterProperties;
	public bool damaged;

	public AudioClip step;
	public AudioClip punch;
	void Awake(){
		characterProperties = GetComponent<CharacterProperties>();
		// sprite.SortingOrder = 10;
	}

	int fCounter = 0;
	int attackingFramesCounter = 0;
	void FixedUpdate(){
		fCounter ++;
		if(characterProperties.alive){
			if(!damaged){
				if(!characterProperties.attacking){
					attackingFramesCounter = 0;

					if(characterProperties.horizontal != 0 || characterProperties.vertical != 0){
						if(Mathf.Abs(characterProperties.horizontal) >= Mathf.Abs(characterProperties.vertical)){
							WalkH(characterProperties.horizontal);
						} else if(Mathf.Abs(characterProperties.horizontal) <= Mathf.Abs(characterProperties.vertical)){
							WalkV(characterProperties.vertical);
						}
					} else {
						StopAnimation();
					}
				} else {
					AttackingAnimations();
				}
			} else {
				DamagedAnimation();
			}
		} else {
			DeadSprite();
		}
	}

	void DeadSprite(){
		/*
		 * 29 down
		 * 31 up
		 * 33 left
		 * 35 right
		 */
		int frame = 29;
		if(characterProperties.looking == CharacterProperties.Looking.up)
			frame = 31;
		else if(characterProperties.looking == CharacterProperties.Looking.down)
			frame = 29;
		else if(characterProperties.looking == CharacterProperties.Looking.left)
			frame = 33;
		else if(characterProperties.looking == CharacterProperties.Looking.right)
			frame = 35;

		sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+frame);
	}
	public void Damage(){
		damaged = true;
	}
	void DamagedAnimation(){
		/* 28 down 
		 * 30 up
		 * 32 left
		 * 34 right
		 */
		int frame = 30;
		if(characterProperties.looking == CharacterProperties.Looking.up)
			frame = 30;
		else if(characterProperties.looking == CharacterProperties.Looking.down)
			frame = 28;
		else if(characterProperties.looking == CharacterProperties.Looking.left)
			frame = 32;
		else if(characterProperties.looking == CharacterProperties.Looking.right)
			frame = 34;

		sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+frame);
	}
	/*
	 * STOP
	 * */
	void StopAnimation(){
		
		if(characterProperties.looking == CharacterProperties.Looking.up){
			sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+(10).ToString());
		}
		else if(characterProperties.looking == CharacterProperties.Looking.right){
			sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+(7).ToString());
		}
		else if(characterProperties.looking == CharacterProperties.Looking.down){
			sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+(1).ToString());
		}
		else if(characterProperties.looking == CharacterProperties.Looking.left){
			sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+(4).ToString());
		}
	}

	/**ATTACK
	 * 12 13 14 down
	 * 15 16 17 left
	 * 18 19 20 right
	 * 21 22 23 up
	 * */

	int animationFrames = 0;
	void AttackingAnimations(){
		if(animationFrames == 0){
			MonophonicTracks.instance.Play(punch,10,.5f,.1f);
		}
		if(characterProperties.looking == CharacterProperties.Looking.up){
			sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+(21 + animationFrames).ToString());
		}
		else if(characterProperties.looking == CharacterProperties.Looking.right){
			sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+(18 + animationFrames).ToString());
		}
		else if(characterProperties.looking == CharacterProperties.Looking.down){
			sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+(12 + animationFrames).ToString());
		}
		else if(characterProperties.looking == CharacterProperties.Looking.left){
			sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+(15 + animationFrames).ToString());
		}

		if((attackingFramesCounter % 5) == 0){
			animationFrames++;
			if(animationFrames == 3){
				animationFrames = 0;
				characterProperties.attacking = false;
			}
		}
		attackingFramesCounter ++;


	}
	/*	WALK
		0 1 2 down
		3 4 5 left
		6 7 8 right
		9 10 11 up
	 */

	int offset = 0;

	void WalkH(float speed){
		int v = 7 - (int)(Mathf.Abs(speed*6));

		if(speed > 0){
			characterProperties.looking = CharacterProperties.Looking.right;
			sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+(8 - offset).ToString());
		} else {
			characterProperties.looking = CharacterProperties.Looking.left;
			sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+(5 - offset).ToString());
		}

		if((fCounter % v) == 0){
			offset = (offset + 1 == 3) ? 0 : offset + 1;
		}
		if(!characterProperties.AI && offset == 0){
			MonophonicTracks.instance.Play(step,10,2.5f+Mathf.Abs(speed/3f),.1f);
		}
	}
	void WalkV(float speed){
		int v = 7 - (int)(Mathf.Abs(speed*6));
		
		if(speed > 0){
			characterProperties.looking = CharacterProperties.Looking.up;
			sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+(11 - offset).ToString());
		} else {
			characterProperties.looking = CharacterProperties.Looking.down;
			sprite.spriteId = sprite.GetSpriteIdByName(characterProperties.spriteName+"/"+(2 - offset).ToString());
		}
		
		if((fCounter % v) == 0){
			offset = (offset + 1 == 3) ? 0 : offset + 1;
		}
		if(!characterProperties.AI && offset == 0){
			MonophonicTracks.instance.Play(step,10,2.5f+Mathf.Abs(speed/3f),.1f);
		}
	}

}













