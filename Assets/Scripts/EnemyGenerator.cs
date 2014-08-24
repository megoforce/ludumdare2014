using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
	public GameObject characterPrefab;
	public void GenerateEnemies(){
		for(int i = 0; i < 10; i++){
			GameObject newEnemy = Instantiate(characterPrefab) as GameObject;
			CharacterProperties cp = newEnemy.GetComponent<CharacterProperties>();
			cp.Init(true);
			newEnemy.transform.position = new Vector3(2*i,RandomExt.RandomFloatBetween(0,10),0);
		}
	}
}
