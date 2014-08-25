using UnityEngine;
using System.Collections;

public class MonophonicTracks : MonoBehaviour {


	private static MonophonicTracks _instance;
	
	public static MonophonicTracks instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<MonophonicTracks>();
				
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}



	public int monophonicTracks = 16;

	AudioSource[] audioSources;
	void Awake(){

		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	

		audioSources = new AudioSource[monophonicTracks];
		CreateTracks();
	}

	void CreateTracks(){
		for(int i = 0; i < monophonicTracks; i++){
			audioSources[i] = gameObject.AddComponent<AudioSource>();
		}
	}

	public void Play(AudioClip clip, int track, float pitch, float volume, float pan){
		audioSources[track].Stop();
		audioSources[track].pitch = pitch;
		audioSources[track].volume = volume;
		audioSources[track].pan = pan;
		audioSources[track].clip = clip;
		audioSources[track].Play();
	}
	public void Play(AudioClip clip, int track, float pitch, float volume){
		Play(clip,track,pitch,volume,0);
	}
	public void Play(AudioClip clip, int track, float pitch){
		Play(clip,track,pitch,1,0);
	}
	public void Play(AudioClip clip, int track){
		Play(clip,track,1,1,0);
	}
	public void Play(AudioClip clip){
		Play(clip,0,1,1,0);
	}
	public void Stop(int track){
		audioSources[track].Stop();
	}
}
