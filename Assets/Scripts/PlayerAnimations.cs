using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAnimations : MonoBehaviour {
	public tk2dSprite sprite;
	PlayerMotor playerMotor;


	void Awake(){
		playerMotor = GetComponent<PlayerMotor>();
	}

	void Update(){

	}
}
