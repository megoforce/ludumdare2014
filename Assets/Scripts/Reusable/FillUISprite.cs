using UnityEngine;
using System.Collections;

public class FillUISprite : MonoBehaviour {
	UISprite sprite;
	public bool showAtStart = false;
	public float duration;
	public float delay;

	// Use this for initialization
	void Awake () {
		sprite = GetComponent<UISprite>();
	}
	void Start(){
		if(showAtStart){
			Show();
		}
	}

	public void Show(){
		sprite.fillAmount = 0;
		StartCoroutine(ShowAnimated ());
	}
	IEnumerator ShowAnimated(){
		yield return new WaitForSeconds(delay);
		float t0 = Time.time;

		while(sprite.fillAmount < 1){
			sprite.fillAmount = (Time.time - t0) / duration;
			yield return new WaitForEndOfFrame();
		}

	}
}
