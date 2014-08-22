using UnityEngine;
using System.Collections;

public class TargetFramerate : MonoBehaviour {
	void Awake() {
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
	}
}
