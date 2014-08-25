using UnityEngine;
using System.Collections;

public class LoadSceneOnClick : MonoBehaviour {
	public string sceneName;
	void OnClick(){
		Application.LoadLevel(sceneName);
	}
}
