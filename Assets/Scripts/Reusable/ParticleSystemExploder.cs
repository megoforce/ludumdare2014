using UnityEngine;
using System.Collections;

public class ParticleSystemExploder : MonoBehaviour {
	ParticleSystem ps;

	void Awake(){
		ps = GetComponent<ParticleSystem>();
		ps.enableEmission = false;
	}
	void OnEnable(){
		TriggerExplosion();
	}

	void TriggerExplosion(){
		ps.enableEmission = true;
		ps.Play();
		StartCoroutine(EmissionOff(ps.duration));
	}
	IEnumerator EmissionOff(float delay){
		yield return new WaitForSeconds(delay);
		ps.Stop();
		ps.enableEmission = false;
		gameObject.transform.parent.SendMessage("Despawn");	
	}
}
