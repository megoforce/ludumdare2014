using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
	public GameObject characterPrefab;
	public void GenerateEnemies(){
		GameObject newEnemy = Instantiate(characterPrefab) as GameObject;
		CharacterProperties cp = newEnemy.GetComponent<CharacterProperties>();
		cp.Init(true);
		newEnemy.transform.position = new Vector3(2,2,0);
	}
}
