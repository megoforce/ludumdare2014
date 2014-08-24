using UnityEngine;
using System.Collections;
using System;
using InControl;

public class CharacterMotor : MonoBehaviour {
	public Collider left;
	public Collider right;
	public Collider up;
	public Collider down;

	float ampVelocity = 70f;
	Transform myTransform;
	public Rigidbody myRigidbody;

	CharacterProperties characterProperties;

	void Awake(){
		myTransform = transform;
		characterProperties = GetComponent<CharacterProperties>();
		myTransform.position = new Vector3(20,20,myTransform.position.z);
	}
	void FixedUpdate () {

		if(!characterProperties.AI){
			InputDevice inputDevice = InputManager.ActiveDevice;
			characterProperties.horizontal = inputDevice.LeftStick.Right.LastValue - inputDevice.LeftStick.Left.LastValue;
			characterProperties.vertical = inputDevice.LeftStick.Up.LastValue - inputDevice.LeftStick.Down.LastValue;
			if(inputDevice.Action1.IsPressed && !characterProperties.attacking)
				StartCoroutine(Attacking());


		} 
		Vector3 f = (characterProperties.horizontal*Vector3.right + characterProperties.vertical*Vector3.up)*ampVelocity;

		if(characterProperties.AI)
			f*=.8f;

		myRigidbody.AddForce(f);
	}

	void CheckForAttacking(){

	}


	IEnumerator Attacking(){
		characterProperties.attacking = true;
		yield return new WaitForSeconds(.4f);
		characterProperties.attacking = false;
	}
}













