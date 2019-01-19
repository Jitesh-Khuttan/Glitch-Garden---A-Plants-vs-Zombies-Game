using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	private StarsDisplay starDisplay;
	public int starCost;
	
	void Start() {
		
		starDisplay = GameObject.FindObjectOfType<StarsDisplay>();
		
	}
	
	public void AddStars(int amount) {
		starDisplay.AddStars(amount);
	}
	
	void OnTriggerEnter2D(){		
		//Debug.Log("Following Triggered: " + name);
	}
}
