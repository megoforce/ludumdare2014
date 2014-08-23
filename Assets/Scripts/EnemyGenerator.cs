using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
	public GameObject characterPrefab;
	public void GenerateEnemies(){
		GameObject newEnemy = Instantiate(characterPrefab) as GameObject;
		CharacterProperties cp = GetComponent<CharacterProperties>();
		cp.AI = true;
		cp.spriteName = "enemy";

	}
}
