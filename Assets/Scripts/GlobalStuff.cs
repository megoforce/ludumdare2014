using UnityEngine;
using System.Collections;

public class GlobalStuff : MonoBehaviour {
	public static GlobalStuff instance = null;
	public GameObject player;
	public GUIManager gUIManager;
	public EnemyGenerator enemyGenerator;
	public WorldGenerator worldGenerator;
	public float lat = 0;
	public float lng = 0;

	void Awake(){
		if(instance == null){
			instance = this;
		}
	}
}
