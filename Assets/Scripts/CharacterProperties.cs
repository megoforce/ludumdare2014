using UnityEngine;
using System.Collections;

public class CharacterProperties : MonoBehaviour {
	public bool AI = false;
	public int health = 99;
	public int armor = 99;
	public float horizontal;
	public float vertical;
	public string spriteName;
	public bool attacking = false;
	public bool alive=true;
	public int power=1;
	public int speed=1;
	public enum Looking{up,right,left,down};
	public Looking looking = Looking.down;
	CharacterAnimations characterAnimations;
	public void Init(bool enemy){
		AI = enemy;
		spriteName = (enemy) ? "enemy" : "player";
		characterAnimations = GetComponent<CharacterAnimations>();
		characterAnimations.sprite.spriteId = characterAnimations.sprite.GetSpriteIdByName(spriteName+"/1");
		tag = (enemy) ? "NotPlayer" : "Player";
		characterAnimations.sprite.gameObject.tag = (enemy) ? "NotPlayerSprite" : "PlayerSprite";
	}


}
