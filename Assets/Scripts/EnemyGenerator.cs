using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
	public GameObject characterPrefab;
	public void GenerateEnemies(){
		GameObject newEnemy = Instantiate(characterPrefab) as GameObject;
		CharacterProperties cp = newEnemy.GetComponent<CharacterProperties>();
		print("cp"+cp);
		print("new enemy"+newEnemy);
		cp.AI = true;
		cp.spriteName = "enemy";
		newEnemy.transform.position = new Vector3(2,2,0);
	}
}
