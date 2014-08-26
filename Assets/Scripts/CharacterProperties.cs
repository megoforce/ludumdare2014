using UnityEngine;
using System.Collections;

public class CharacterProperties : MonoBehaviour {
	public bool AI = false;
	public int health = 99;
	public int armor = 99;
	public float horizontal;
	public float vertical;
	public string spriteName;
	public int level = 0;
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


		if(!AI){
			int cardsCounter = 0;
			for(int i = 0; i < 5; i++)
				if(PlayerPrefs.GetInt("card-"+(i+1)) == 1)
					cardsCounter++;
			level = cardsCounter;
			spriteName = spriteName+"-"+level;
			health = PlayerPrefs.GetInt("health");
			armor = PlayerPrefs.GetInt("armor");
			characterAnimations = GetComponent<CharacterAnimations>();
			characterAnimations.sprite.spriteId = characterAnimations.sprite.GetSpriteIdByName(spriteName+"/1");
		} else {
			spriteName = "enemy-"+Random.Range(0,2).ToString();
		}
	}
	void Start(){
		if(!AI){
			RefreshPlayer();
		}
	}
	public void RefreshPlayer(){
		int cardsCounter = 0;
		for(int i = 0; i < 5; i++)
			if(PlayerPrefs.GetInt("card-"+(i+1)) == 1)
				cardsCounter++;

		level = cardsCounter;
		spriteName = "player-"+level;
		health = PlayerPrefs.GetInt("health");
		armor = PlayerPrefs.GetInt("armor");
		characterAnimations = GetComponent<CharacterAnimations>();
		characterAnimations.sprite.spriteId = characterAnimations.sprite.GetSpriteIdByName(spriteName+"/1");
	}

}
