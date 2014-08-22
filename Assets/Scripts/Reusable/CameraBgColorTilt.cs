using UnityEngine;
using System.Collections;

public class CameraBgColorTilt : MonoBehaviour {

	public Color color1;
	public Color color2;
	public float timePerColor = .5f;
	public float delay = 0;
	Camera cam;

	void Awake(){
		cam = GetComponent<Camera>();
	}
	void Start () {
		StartCoroutine(ColorChanger());
	}
	IEnumerator ColorChanger(){
		yield return new WaitForSeconds(delay);

		while(true){
			cam.backgroundColor = color1;
			yield return new WaitForSeconds(timePerColor);
			cam.backgroundColor = color2;
			yield return new WaitForSeconds(timePerColor);
		}
	}
}
