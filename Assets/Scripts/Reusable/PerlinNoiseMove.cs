using UnityEngine;
using System.Collections;

public class PerlinNoiseMove : MonoBehaviour {
	public Vector3 original;
	public Vector3 amplification;
	public float timeScale;

	Transform myTransform;
	Vector3 randVect;
	void Awake(){
		randVect = new Vector3(RandomExt.RandomFloatBetween(0,1000),RandomExt.RandomFloatBetween(0,1000),RandomExt.RandomFloatBetween(0,1000));
		myTransform = transform;
	}

	void Update () {
		Vector3 movement = new Vector3(amplification.x*(-.5f+Mathf.PerlinNoise(randVect.x,Time.time*timeScale)),
		                               amplification.y*(-.5f+Mathf.PerlinNoise(randVect.y,Time.time*timeScale)),
		                               amplification.z*(-.5f+Mathf.PerlinNoise(randVect.z,Time.time*timeScale)));
		myTransform.localPosition = original + movement;
	}
}
