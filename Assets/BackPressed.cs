using UnityEngine;
using System.Collections;

public class BackPressed : MonoBehaviour {
	public ProgressSwitcher progressSwitcher;
	void OnClick(){

		progressSwitcher.Hide();

	}
}
