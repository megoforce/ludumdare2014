using UnityEngine;
using System.Collections;

public class Despawner : MonoBehaviour {
	public void Despawn(){
		if(gameObject.activeInHierarchy){
			SmartPool.Despawn(gameObject);
		}
	}
}
