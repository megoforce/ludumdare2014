using UnityEngine;
using System.Collections;
using System;
using InControl;

public class CharacterMotor : MonoBehaviour {
	public AttackingTrigger left;
	public AttackingTrigger right;
	public AttackingTrigger up;
	public AttackingTrigger down;
	public GameObject attackExplosionPlayer;
	public GameObject attackExplosionEnemy;
	public int health;
	public int armor;
	public bool alive;
	GameObject myAttackExplosion;

	float ampVelocity = 70f;
	Transform myTransform;
	public Rigidbody myRigidbody;

	CharacterProperties characterProperties;

	void Awake(){
		myTransform = transform;
		characterProperties = GetComponent<CharacterProperties>();
		myTransform.position = new Vector3(20,20,myTransform.position.z);
		armor=99;
		alive=true;
		if(characterProperties.AI==false) {
			RefreshStatusMessage();
		}
	}
	void Start(){
		myAttackExplosion = (characterProperties.AI) ? attackExplosionEnemy : attackExplosionPlayer;

	}
	void FixedUpdate () {

		if(!characterProperties.AI){
			InputDevice inputDevice = InputManager.ActiveDevice;
			characterProperties.horizontal = inputDevice.LeftStick.Right.LastValue - inputDevice.LeftStick.Left.LastValue;
			characterProperties.vertical = inputDevice.LeftStick.Up.LastValue - inputDevice.LeftStick.Down.LastValue;
			if(inputDevice.Action1.IsPressed && !characterProperties.attacking)
				characterProperties.attacking = true;
		} 
		Vector3 f = (characterProperties.horizontal*Vector3.right + characterProperties.vertical*Vector3.up)*ampVelocity;

		if(characterProperties.AI)
			f*=.8f;

		myRigidbody.AddForce(f);

		if(characterProperties.attacking)
			CheckForAttacking();

	}
	void Damage(float fdamage) {

		if(characterProperties.alive==true) {
			int damage=(int)fdamage;
			int finaldamage=damage;
			if(RandomExt.RandomFloatBetween(0,100) < characterProperties.armor) {
				finaldamage=(finaldamage-(characterProperties.armor/10));
				characterProperties.armor=characterProperties.armor-damage;
			} 
			if(finaldamage<0) finaldamage=0;
			if(characterProperties.armor<0) characterProperties.armor=0;
			characterProperties.health=characterProperties.health-finaldamage;
			if(characterProperties.AI==false) {
				RefreshStatusMessage();
			}
//			Debug.Log("d: "+damage.ToString()+" fd:"+finaldamage.ToString());
			if(characterProperties.health<1) Die();
			
		}

	}
	void RefreshStatusMessage() {
		GlobalStuff.instance.gUIManager.hp.text="HEALTH:"+characterProperties.health.ToString()+" ARMOR:"+characterProperties.armor.ToString()+" KEYS:0/64";
	}
	void Die() {
		characterProperties.alive=false;
	}
	void CheckForAttacking(){
		int damage=1;
		//Up
		if(characterProperties.looking == CharacterProperties.Looking.up){
			foreach(GameObject damagedObject in up.inColliderObjects){
				damagedObject.BroadcastMessage("Damage",damage);
				Instantiate(myAttackExplosion,damagedObject.transform.position,Quaternion.Euler(0,-180,-180));
				Vector3 delta = damagedObject.transform.position - myTransform.position;
				damagedObject.rigidbody.AddRelativeForce(delta.normalized*5f,ForceMode.Impulse);
			}
		}
		//Right
		else if(characterProperties.looking == CharacterProperties.Looking.right){
			foreach(GameObject damagedObject in right.inColliderObjects){
				damagedObject.BroadcastMessage("Damage",damage);
				Instantiate(myAttackExplosion,damagedObject.transform.position,Quaternion.Euler(0,-180,-180));
				Vector3 delta = damagedObject.transform.position - myTransform.position;
				damagedObject.rigidbody.AddRelativeForce(delta.normalized*5f,ForceMode.Impulse);
			}
		}
		//Down
		else if(characterProperties.looking == CharacterProperties.Looking.down){
			foreach(GameObject damagedObject in down.inColliderObjects){
				damagedObject.BroadcastMessage("Damage",damage);
				Instantiate(myAttackExplosion,damagedObject.transform.position,Quaternion.Euler(0,-180,-180));
				Vector3 delta = damagedObject.transform.position - myTransform.position;
				damagedObject.rigidbody.AddRelativeForce(delta.normalized*5f,ForceMode.Impulse);
			}
		}
		//Left
		else if(characterProperties.looking == CharacterProperties.Looking.left){
			foreach(GameObject damagedObject in left.inColliderObjects){
				damagedObject.BroadcastMessage("Damage",damage);
				Instantiate(myAttackExplosion,damagedObject.transform.position,Quaternion.Euler(0,-180,-180));

				Vector3 delta = damagedObject.transform.position - myTransform.position;
				damagedObject.rigidbody.AddRelativeForce(delta.normalized*5f,ForceMode.Impulse);
			}
		}
	}



}













