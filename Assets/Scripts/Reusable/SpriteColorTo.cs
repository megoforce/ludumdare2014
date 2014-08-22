using UnityEngine;
using System.Collections;

public class SpriteColorTo : MonoBehaviour {
	public bool autoPlay = false;
	public Color from;
	public Color to;
	public float delay = 0;
	public float duration = 1;
	public bool repeatForever = false;
	bool playing = false;
	SpriteRenderer spriteRenderer;

	void Awake(){
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	void Start(){
		if(autoPlay)
			PlayForward();
	}

	public void Stop(){
		StopAllCoroutines();
		playing = false;

	}

	public void PlayForward(){
		StartCoroutine(DelayNPlay(true));
	}

	IEnumerator DelayNPlay(bool forward){
		playing = true;
		yield return new WaitForSeconds(delay);
		StartCoroutine(Play(forward));
	}

	IEnumerator Play(bool forward){
		do{
			float p = 0;
			float t0 = Time.time;
			while(p < 1){
				p = (Time.time - t0) / duration;
				spriteRenderer.color = forward ? Color.Lerp(from,to,p) : Color.Lerp(to,from,p);
				yield return new WaitForEndOfFrame();
			}
			spriteRenderer.color = to;
		}while(repeatForever && playing);
	}
}
