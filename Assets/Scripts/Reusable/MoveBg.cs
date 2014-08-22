using UnityEngine;
using System.Collections;

public class MoveBg : MonoBehaviour {
	public float amp;
	public Vector2 vel;

	void Update () {
		renderer.material.mainTextureOffset = new Vector2(Time.time*vel.x,amp*Mathf.Sin(Time.time*vel.y));
	}

}
