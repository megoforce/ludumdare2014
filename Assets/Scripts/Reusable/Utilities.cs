using UnityEngine;
using System.Collections;

public static class Utilities {
	public static IEnumerator DestroyDelayed(GameObject go, float delay){
		yield return new WaitForSeconds(delay);
		GameObject.Destroy(go);
	}

}
