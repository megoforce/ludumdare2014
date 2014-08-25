using UnityEngine;
using System.Collections;
using InControl;

public class CharacterMotor : MonoBehaviour {
	public AttackingTrigger left;
	public AttackingTrigger right;
	public AttackingTrigger up;
	public AttackingTrigger down;
	public GameObject attackExplosionPlayer;
	public GameObject attackExplosionEnemy;
	public bool alive;
	public tk2dTileMap tileMap;
	public AudioClip hurt;
	GameObject myAttackExplosion;

	float ampVelocity = 30f;
	Transform myTransform;
	public Rigidbody myRigidbody;

	CharacterProperties characterProperties;

	void Awake(){
		myTransform = transform;
		characterProperties = GetComponent<CharacterProperties>();
		myTransform.position = new Vector3(41,41,myTransform.position.z);
		alive=true;
		if(characterProperties.AI==false) {
			RefreshStatusMessage();
		}
	}
	void Start(){
		myAttackExplosion = (characterProperties.AI) ? attackExplosionEnemy : attackExplosionPlayer;

	}

	public GameObject healthPrefab;
	public GameObject armorPrefab;
	void FixedUpdate () {

		if(!characterProperties.AI){
			// current tile
			int x = (int)(transform.position.x*(256f/82f));
			int y = (int)(transform.position.y*(256f/82f));

			x=x+1;
			y=y+1;
			if(x>0 && x<tileMap.width && y>0 && y<tileMap.height) {
//				print(x+","+y+" = "+tileMap.GetTile(x,y,1));
				int currentTile = tileMap.GetTile(x,y,1);
				//helath
				if(currentTile == 7 || currentTile == 13){ 
					GameObject hp = Instantiate(healthPrefab,new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z-.5f),Quaternion.identity) as GameObject;
					hp.transform.parent = myTransform;
					tileMap.SetTile(x,y,1,-1);
					if(Random.value < .5f){
						characterProperties.health = (characterProperties.health+1 > 99) ? 99 : characterProperties.health+2;
						PlayerPrefs.SetInt("health",characterProperties.health);
						RefreshStatusMessage();
					}
					tileMap.Build();
				}else if(currentTile == 8 || currentTile == 1 || currentTile == 2){ //stone
					GameObject hp = Instantiate(armorPrefab,new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z-.5f),Quaternion.identity) as GameObject;
					hp.transform.parent = myTransform;
					if(Random.value < .5f){
						characterProperties.armor = (characterProperties.armor+1 > 99) ? 99 : characterProperties.armor+2;
						PlayerPrefs.SetInt("armor",characterProperties.armor);
						RefreshStatusMessage();
					}

				}
				//stones 8 1 2



			}
			InputDevice inputDevice = InputManager.ActiveDevice;
			characterProperties.horizontal = inputDevice.LeftStick.Right.LastValue - inputDevice.LeftStick.Left.LastValue;
			characterProperties.vertical = inputDevice.LeftStick.Up.LastValue - inputDevice.LeftStick.Down.LastValue;
			if(inputDevice.Action1.WasPressed && !characterProperties.attacking)
				characterProperties.attacking = true;
		} 
		Vector3 f = (characterProperties.horizontal*Vector3.right + characterProperties.vertical*Vector3.up)*ampVelocity;



		myRigidbody.AddForce(f);

		if(characterProperties.attacking)
			CheckForAttacking();



	}
	void Damage(float fdamage) {
		if(!characterProperties.AI)
			MonophonicTracks.instance.Play(hurt,10,1,.5f);

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
		PlayerPrefs.SetInt("hp",characterProperties.health);
		PlayerPrefs.SetInt("armor",characterProperties.armor);

		GlobalStuff.instance.gUIManager.hp.text=characterProperties.health.ToString();
		GlobalStuff.instance.gUIManager.armor.text=characterProperties.armor.ToString();
		GlobalStuff.instance.gUIManager.keys.text=PlayerPrefs.GetInt("keys").ToString() +"/5";
	}
	void Die() {
		characterProperties.alive=false;
		if(!characterProperties.AI){
			Time.timeScale = 0;
			//TODO gui!!
			//GameDataLoader.ResetData();
			//Application.LoadLevel("home");
		}

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













