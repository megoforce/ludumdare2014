using UnityEngine;
using System.Collections;
using System;
using InControl;

public class PlayerMotor : MonoBehaviour {
	float ampVelocity = .07f;
	Transform myTransform;
	public float horizontal;
	public float vertical;

	void Awake(){
		myTransform = transform;
	}
	void Update () {
		InputDevice inputDevice = InputManager.ActiveDevice;
		horizontal = inputDevice.LeftStick.Right.LastValue - inputDevice.LeftStick.Left.LastValue;
		vertical = inputDevice.LeftStick.Up.LastValue - inputDevice.LeftStick.Down.LastValue;
		myTransform.position += (horizontal*Vector3.right + vertical*Vector3.up)*ampVelocity * Time.deltaTime*60f;


	}
}
