using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[RequireComponent (typeof(Text))]
public class StarsDisplay : MonoBehaviour {

	private Text starText;
	private int stars;
	public enum Status {SUCCESS,FAILURE};
	
	void Start() {
		
		starText = GetComponent<Text>();
		
		int levelIndex = Application.loadedLevel;
		
		if(levelIndex == 3) 		stars = 200;
		else if(levelIndex == 4)	stars = 150;
		else if (levelIndex == 5)	stars = 130;
		else						stars = 200;
			
		UpdateDisplay();
		
	}

	public void AddStars(int amount) {
		stars += amount;
		UpdateDisplay();
		
		print (amount + " stars added");
	}
	
	public Status UseStars(int amount) {
	
		if(stars >= amount) {
			stars -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;	
	}
	
	private void UpdateDisplay() {
	
		starText.text = stars.ToString();
		
	}  
}
