using UnityEngine;
using System.Collections;
using InControl;

public class GUIManager : MonoBehaviour {
	public UILabel label1;
	public UILabel label2;
	public UILabel hp;
	public UILabel armor;
	public UILabel cards;
	public GlitchEffect glitchEffect;
	public CameraFilterPack_TV_Chromatical glitchChromatical;
	public ProgressSwitcher progressSwitcher;
	public RefreshProgressCards refreshProgressCards;
	public GameObject map;

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

	public void RefreshGUIValues(){
		hp.text = PlayerPrefs.GetInt("health").ToString();
		armor.text = PlayerPrefs.GetInt("armor").ToString();
		int cardsCounter = 0;
		for(int i = 0; i < 5; i++)
			if(PlayerPrefs.GetInt("card-"+(i+1)) == 1)
				cardsCounter++;


		cards.text = cardsCounter.ToString()+"/5";
		refreshProgressCards.Refresh();

	}
















}
