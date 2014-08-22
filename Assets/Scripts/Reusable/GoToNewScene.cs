using UnityEngine;
using System.Collections;

public class GoToNewScene : MonoBehaviour {
	public string sceneName;
	public GameObject loadingScreen;

	public void GoToScene(){
		Instantiate(loadingScreen);
		StartCoroutine(LoadLevelAsync());
	}

	IEnumerator LoadLevelAsync(){
		AsyncOperation loading = Application.LoadLevelAsync(sceneName);
		yield return loading;
	}
}
