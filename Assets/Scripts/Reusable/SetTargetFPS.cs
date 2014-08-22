using UnityEngine;
using System.Collections;

public class SetTargetFPS : MonoBehaviour {
	public int targetFPS = 60;
	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = targetFPS;
	}
}
