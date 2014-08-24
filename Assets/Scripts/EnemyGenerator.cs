using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
	public GameObject characterPrefab;
	public void GenerateEnemies(){
		for(int i = 0; i < 32; i++){
			GameObject newEnemy = Instantiate(characterPrefab) as GameObject;
			CharacterProperties cp = newEnemy.GetComponent<CharacterProperties>();
			cp.health=1;
			cp.Init(true);
			newEnemy.transform.position = new Vector3(RandomExt.RandomFloatBetween(0,10),RandomExt.RandomFloatBetween(0,10),0);
		}
	}
}
