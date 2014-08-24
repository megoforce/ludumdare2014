using UnityEngine;
using System.Collections;

public class GlobalStuff : MonoBehaviour {
	public static GlobalStuff instance = null;
	public GameObject player;
	public GUIManager gUIManager;
	public EnemyGenerator enemyGenerator;
	public WorldGenerator worldGenerator;
	public float lat;
	public float lng;

	void Awake(){
		if(instance == null){
			instance = this;
		}
	}
}
