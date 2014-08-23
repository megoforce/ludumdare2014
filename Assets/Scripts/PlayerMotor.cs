using UnityEngine;
using System.Collections;
using System;
using InControl;

public class PlayerMotor : MonoBehaviour {
	float ampVelocity = 70f;
	Transform myTransform;
	public Rigidbody myRigidbody;
	public float horizontal;
	public float vertical;

	void Awake(){
		myTransform = transform;
		myTransform.position = new Vector3(20,20,myTransform.position.z);
	}
	void FixedUpdate () {
		InputDevice inputDevice = InputManager.ActiveDevice;
		horizontal = inputDevice.LeftStick.Right.LastValue - inputDevice.LeftStick.Left.LastValue;
		vertical = inputDevice.LeftStick.Up.LastValue - inputDevice.LeftStick.Down.LastValue;
		Vector3 f = (horizontal*Vector3.right + vertical*Vector3.up)*ampVelocity;
		myRigidbody.AddForce(f);


	}
}
