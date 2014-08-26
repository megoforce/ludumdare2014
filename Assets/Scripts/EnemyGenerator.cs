using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
	public GameObject characterPrefab;
	public void GenerateEnemies(){
		for(int i = 0; i < 100+(int)(Random.value*50); i++){
			GameObject newEnemy = Instantiate(characterPrefab) as GameObject;
			CharacterProperties cp = newEnemy.GetComponent<CharacterProperties>();
			int level=Random.Range(0,99);
			cp.health=Random.Range(1,level);
			cp.armor=Random.Range(1,level);

			cp.Init(true);
			newEnemy.transform.position = new Vector3(RandomExt.RandomFloatBetween(0,82),RandomExt.RandomFloatBetween(0,82),0);
		}
	}
}
