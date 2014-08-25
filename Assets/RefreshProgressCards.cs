using UnityEngine;
using System.Collections;

public class RefreshProgressCards : MonoBehaviour {
	public UISprite[] cards;


	public void Refresh(){
		for(int i = 0; i < 5; i++){
			if(PlayerPrefs.GetInt("card-"+(i+1)) == 1){
				cards[i].spriteName = "card-"+(i+1)+"-front";
			} else {
				cards[i].spriteName = "card-"+(i+1)+"-back";
			}
		}
	}
}
