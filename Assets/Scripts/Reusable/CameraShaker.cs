using UnityEngine;
using System.Collections;

public class CameraShaker : MonoBehaviour {
	public bool affectsX = true;
	public bool affectsY = true;
	public bool affectsZ = true;
	float vel;
//	Vector3 originalPosition;
	float currentAmp = 0;
	float maxAmp = 0;
	float maxDuration = 0;
	
	Transform myTransform;
	void Awake(){
		myTransform = transform;
	}
	public void SmallShake(){
		Shake(5,8,10);
	}

	public void BigShake(){
		Shake(30,7,30);
	}

	public void HugeShake(){
		Shake(100,7,120);
	}
	
	public void Shake(float amplification,float velocity,float duration){
//		originalPosition = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		currentAmp = maxAmp = amplification;
		maxDuration = duration;
		vel = velocity;
		StartCoroutine(doShake());
	}

	IEnumerator doShake(){
		while(currentAmp > 0){
			float noiseX = affectsX ? -currentAmp*.5f + currentAmp*Mathf.PerlinNoise(0,Time.time*vel) : 0;
			float noiseY = affectsY ? -currentAmp*.5f + currentAmp*Mathf.PerlinNoise(20,Time.time*vel) : 0;
			float noiseZ = affectsZ ? -currentAmp*.5f + currentAmp*Mathf.PerlinNoise(40,Time.time*vel) : 0;
			
			transform.position = new Vector3(myTransform.position.x+noiseX,myTransform.position.y+noiseY,myTransform.position.z+noiseZ);
			currentAmp -= 0.16f*60.0f*(maxAmp/maxDuration);
			yield return new WaitForEndOfFrame();
		}
	}
	
}
