using UnityEngine;
using System.Collections;

public class GameDataLoader : MonoBehaviour {
	public bool forceReset = false;
	void Awake(){
		if(PlayerPrefs.GetInt("isNotFirstTime") != 1 || forceReset){
			print("Is first time");
			ResetData();
		}
	}
	public static void ResetData(){
		Debug.Log("Reset Data!");
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt("isNotFirstTime",1);
		
	}
}
