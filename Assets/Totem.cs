using UnityEngine;
using System.Collections;

public class Totem : MonoBehaviour {
	public Sprite[] totems;

	int totemID = 0;
	public void Init(int totemID, int x, int y){
		GetComponent<SpriteRenderer>().sprite = totems[totemID];

	}

}
