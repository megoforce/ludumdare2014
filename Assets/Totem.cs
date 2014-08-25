using UnityEngine;
using System.Collections;

public class Totem : MonoBehaviour {
	public Sprite[] totems;

	int totemID = 0;
	public void Init(int totemID, int x, int y){
		GetComponent<SpriteRenderer>().sprite = totems[totemID];
		float worldX = x*(82f/256f);
		float worldY = y*(82f/256f);
		transform.position = new Vector3(worldX,worldY,-1);
	}

	void OnTriggerEnter(Collider other){
		other.gameObject.SendMessage("SayIt","hola!",SendMessageOptions.DontRequireReceiver);
	}
}
