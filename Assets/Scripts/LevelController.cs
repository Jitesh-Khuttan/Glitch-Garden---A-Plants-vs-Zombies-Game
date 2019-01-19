using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public float timeToLoadNextLevel;
	void Start(){
	
		if(timeToLoadNextLevel > 0){
			Invoke ("LoadNextLevel",timeToLoadNextLevel);
		}	
	}

	public void changeLevel(string name){
		//Since The value of static variable "breakableBricks" persists when levels change, therefore we need to make it 0 whenevre
		//level change happens 0;
		Application.LoadLevel(name);
	}
	
	public void quitGame(){
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	
}
