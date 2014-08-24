using UnityEngine;
using System.Collections;

public class GlobalStuff : MonoBehaviour {
	public static GlobalStuff instance = null;
	public GameObject player;
	public GUIManager gUIManager;
	public EnemyGenerator enemyGenerator;

	void Awake(){
		if(instance == null){
			instance = this;
		}
	}
}
