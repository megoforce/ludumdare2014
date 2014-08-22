using UnityEngine;
using System.Collections;

public class DestroyDelayed : MonoBehaviour {
	public float delay;
	void Start(){
		StartCoroutine(SelfDestroy(delay));
	}

	IEnumerator SelfDestroy(float delay){
		yield return new WaitForSeconds(delay);
		Destroy(gameObject);
	}
}
