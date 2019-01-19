using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsController : MonoBehaviour {


	public LevelController levelManager;
	public Slider volumeSlider;
	public Slider difficultySlider;
	private MusicManager musicManager;
	
	// Use this for initialization
	void Start () {
		
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
		
	}
	
	// Update is called once per frame
	void Update () {
	
		musicManager.SetVolume(volumeSlider.value);
	
	}
	
	public void SaveAndExit(){
		
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);
		levelManager.changeLevel("01a Start");
	}
	
	public void SetDefaults(){
	
		PlayerPrefsManager.SetMasterVolume(0.5f);
		PlayerPrefsManager.SetDifficulty(2);
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
}
