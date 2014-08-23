using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour {
	public tk2dSprite sprite;
	PlayerMotor playerMotor;

	void Awake(){
		playerMotor = GetComponent<PlayerMotor>();
	}

	int fCounter = 0;
	void FixedUpdate(){
		fCounter ++;

		if(playerMotor.horizontal != 0 || playerMotor.vertical != 0){
			if(Mathf.Abs(playerMotor.horizontal) >= Mathf.Abs(playerMotor.vertical)){
				WalkH(playerMotor.horizontal);
			} else if(Mathf.Abs(playerMotor.horizontal) <= Mathf.Abs(playerMotor.vertical)){
				WalkV(playerMotor.vertical);
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
			sprite.spriteId = 8 - offsetH;
		} else {
			sprite.spriteId = 5 - offsetH;
		}

		if((fCounter % v) == 0){
			offsetH = (offsetH + 1 == 3) ? 0 : offsetH + 1;
		}
	}
	void WalkV(float speed){
		int v = 10 - (int)(Mathf.Abs(speed*6));
		
		if(speed > 0){
			sprite.spriteId = 11 - offsetH;
		} else {
			sprite.spriteId = 2 - offsetH;
		}
		
		if((fCounter % v) == 0){
			offsetH = (offsetH + 1 == 3) ? 0 : offsetH + 1;
		}
	}
}













