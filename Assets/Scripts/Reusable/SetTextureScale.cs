using UnityEngine;
using System.Collections;

public class SetTextureScale : MonoBehaviour {

	public float size;
	private float ratioX;
	private float ratioY;
	public float offsetX;
	public float offsetY;

	void Start() {
		ratioX = size * (1/transform.lossyScale.y);
		ratioY = size * (1/transform.lossyScale.x);
		fixEverything();

	}

	public void fixEverything() {
		renderer.material.SetTextureScale("_MainTex", new Vector2(ratioX, ratioY));
		renderer.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
	}
	
}