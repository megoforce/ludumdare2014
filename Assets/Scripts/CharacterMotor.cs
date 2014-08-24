using UnityEngine;
using System.Collections;
using System;
using InControl;

public class CharacterMotor : MonoBehaviour {
	public AttackingTrigger left;
	public AttackingTrigger right;
	public AttackingTrigger up;
	public AttackingTrigger down;

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

		if(characterProperties.attacking)
			CheckForAttacking();
	}

	void CheckForAttacking(){
		//Up
		if(characterProperties.looking == CharacterProperties.Looking.up){
			foreach(GameObject damagedObject in up.inColliderObjects){
				damagedObject.BroadcastMessage("Damage");
				Vector3 delta = damagedObject.transform.position - myTransform.position;
				damagedObject.rigidbody.AddRelativeForce(delta.normalized*5f,ForceMode.Impulse);
			}
		}
		//Right
		else if(characterProperties.looking == CharacterProperties.Looking.right){
			foreach(GameObject damagedObject in right.inColliderObjects){
				damagedObject.BroadcastMessage("Damage");
				Vector3 delta = damagedObject.transform.position - myTransform.position;
				damagedObject.rigidbody.AddRelativeForce(delta.normalized*5f,ForceMode.Impulse);
			}
		}
		//Down
		else if(characterProperties.looking == CharacterProperties.Looking.down){
			foreach(GameObject damagedObject in down.inColliderObjects){
				damagedObject.BroadcastMessage("Damage");
				Vector3 delta = damagedObject.transform.position - myTransform.position;
				damagedObject.rigidbody.AddRelativeForce(delta.normalized*5f,ForceMode.Impulse);
			}
		}
		//Left
		else if(characterProperties.looking == CharacterProperties.Looking.left){
			foreach(GameObject damagedObject in left.inColliderObjects){
				damagedObject.BroadcastMessage("Damage");
				Vector3 delta = damagedObject.transform.position - myTransform.position;
				damagedObject.rigidbody.AddRelativeForce(delta.normalized*5f,ForceMode.Impulse);
			}
		}
	}


	IEnumerator Attacking(){
		characterProperties.attacking = true;
		yield return new WaitForSeconds(.4f);
		characterProperties.attacking = false;
	}
}













