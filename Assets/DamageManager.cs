using UnityEngine;
using System.Collections;

public class DamageManager : MonoBehaviour {
	CharacterAnimations characterAnimations;
	void Awake(){
		characterAnimations = GetComponent<CharacterAnimations>();
	}
	public void Damage(){
		characterAnimations.sprite.color = Color.red;
		StartCoroutine(OffDamageEffects(.3f));
	}

	IEnumerator OffDamageEffects(float delay){
		yield return new WaitForSeconds(delay);
		characterAnimations.sprite.color = Color.white;
	}
}
