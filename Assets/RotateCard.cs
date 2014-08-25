using UnityEngine;
using System.Collections;

public class RotateCard : MonoBehaviour {
	int cardID;
	public TweenRotation firstRotationCard;
	public TweenRotation secondRotationCard;
	public TweenRotation secondRotationLabel;
	public AudioClip foundCardSound;
	public void Init(int _cardID){

		cardID = _cardID;
		GetComponent<UISprite>().spriteName = "card-"+(cardID+1)+"-back";
		Time.timeScale = 0;
		MonophonicTracks.instance.Play(foundCardSound,15,1,.6f);
		firstRotationCard.Play(true);
		secondRotationLabel.gameObject.GetComponent<UILabel>().text = CardUtility.GetCardName(cardID);
	}
	public void firstRotFinished(){
		GetComponent<UISprite>().spriteName = "card-"+(cardID+1)+"-front";
		secondRotationCard.Play(true);
		secondRotationLabel.Play(true);
		GlobalStuff.instance.gUIManager.RefreshGUIValues();

	}
	public void secondRotFinished(){
		StartCoroutine(DestroyDelayed());
	}
	IEnumerator DestroyDelayed(){
		float timer = 3;
 		while(true){
			float pauseEndTime = Time.realtimeSinceStartup + 1f;
			while (Time.realtimeSinceStartup < pauseEndTime){
				yield return 0;
			}
			Debug.Log(timer);
			timer-=1;
			if(timer == 0){
				Debug.Log ("Start");
				Time.timeScale = 1;
				Destroy(gameObject.transform.parent.gameObject);
				StopCoroutine("DestroyDelayed");
			}
		}

	}
}
