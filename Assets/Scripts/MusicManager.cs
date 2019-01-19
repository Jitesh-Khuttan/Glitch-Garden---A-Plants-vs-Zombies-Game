using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] playMusicOnLevel;
	private AudioSource audioSource;

	void Awake(){
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	//Already declared function which get called when level is loaded and passes the index of the level as an argument.
	void OnLevelWasLoaded(int level){

//		print("Level Loaded  Index: " + level);
		AudioClip thisLevelAudio = playMusicOnLevel[level];
		
//		print ("Current Audio Name is: " + thisLevelAudio);

		if(thisLevelAudio){
//			print("Music Loaded!");
			audioSource.clip = thisLevelAudio; 
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	
	public void SetVolume(float volume){
		
		audioSource.volume = volume;
		
	}
}


