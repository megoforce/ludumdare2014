﻿using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour {
	void OnClick(){
		GameDataLoader.ResetData();
		Application.LoadLevel("intro");
	}
}
