using UnityEngine;
using System.Collections;
using InControl;

public class GUIManager : MonoBehaviour {
	public UILabel label1;
	public UILabel label2;
	public UILabel hp;
	public UILabel armor;
	public UILabel keys;
	public GlitchEffect glitchEffect;
	public CameraFilterPack_TV_Chromatical glitchChromatical;
	public ProgressSwitcher progressSwitcher;


	void Update(){
		InputDevice inputDevice = InputManager.ActiveDevice;

		if(inputDevice.Action3.WasPressed){
			if(!GlobalStuff.instance.paused){

				progressSwitcher.Show();
			} else {

				progressSwitcher.Hide();
			}

		}
	}

}
