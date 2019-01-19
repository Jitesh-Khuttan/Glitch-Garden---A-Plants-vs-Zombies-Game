using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	
	public static void SetMasterVolume(float volume){
		
		if(volume >= 0f && volume <= 1f){
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY,volume);
		}
		else{
			Debug.LogError("Volume value out of index");
		}
	}
	
	
	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	
	//Unlocking a level
	public static void UnlockLevel(int level){
	
		if(level <= (Application.levelCount - 1)) {
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(),1);		//1 indicates true i.e. level is unlocked.\
		}
		else{
			Debug.LogError("Error: Trying to unlock a level which does not exist.");
		}
	}
	
	public static bool IsLevelUnlocked(int level){
	
		if(level <= Application.levelCount - 1){
			if(PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1){
				return true;
			}	
		}
		else{
			Debug.LogError("Error: Checking for level that does not even exist.");
		}
		return false;
	}
	
	public static void SetDifficulty(float difficulty){
		if(difficulty >= 1f  && difficulty <= 3f){
			PlayerPrefs.SetFloat(DIFFICULTY_KEY,difficulty);
		}
		else{
			Debug.LogError("Error: Difficulty Value Out Of Bound!");
		}
	}
	
	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
	
}