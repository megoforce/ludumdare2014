using UnityEngine;
using System.Collections;

public class RefreshHp : MonoBehaviour {
	UILabel label;
	CharacterProperties characterProperties;
	void Awake(){
		label = GetComponent<UILabel>();
		characterProperties = GlobalStuff.instance.player.GetComponent<CharacterProperties>();
	}
	IEnumerator UpdateLabel(){
		while(true){
			label.text = characterProperties.health.ToString();
			yield return new WaitForSeconds(.3f);
		}
	}
}
