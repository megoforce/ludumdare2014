using UnityEngine;
using System.Collections;

public class Totem : MonoBehaviour {
	public Sprite[] totems;
	public Sprite[] totemsDiscovered;
	public GameObject cardAnimation;
	
	bool discovered = false;
	int totemID = 0;
	
	public void Init(int _totemID, int x, int y){
		totemID = _totemID;
		float worldX = x*(82f/256f);
		float worldY = y*(82f/256f);
		transform.position = new Vector3(worldX,worldY,-1);
		
		Refresh();
	}
	
	void Refresh(){
		if(PlayerPrefs.GetInt("card-"+(totemID+1)) == 1){
			discovered = true;
			GetComponent<SpriteRenderer>().sprite = totemsDiscovered[totemID];
		} else {
			GetComponent<SpriteRenderer>().sprite = totems[totemID];
		}
	}
	void OnTriggerEnter(Collider other){
		//other.gameObject.SendMessage("SayIt","hola!",SendMessageOptions.DontRequireReceiver);
		if(other.tag == "Player" && !discovered){
			PlayerPrefs.SetInt("card-"+(totemID+1),1);

			GameObject card =  Instantiate(cardAnimation) as GameObject;

			card.BroadcastMessage("Init",totemID);

			Refresh();
			
		}
	}


}
