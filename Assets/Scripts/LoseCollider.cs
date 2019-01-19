using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelController levelManager;
	private CrossingValue crossingValue;
	private int attackersPassed;
	private int maximumAttackersLeft;
	private int[] maximamAttackersAllowed = {7,5,3};		//Values are doubled coz trigger happens twice when attacker enters Lose Collider
	// Use this for initialization
	void Start () {

		levelManager = GameObject.FindObjectOfType<LevelController>();
		crossingValue = GameObject.FindObjectOfType<CrossingValue>();
		attackersPassed = 0;
		print ("Crossing Value Object: " + crossingValue);
		if(!crossingValue) { Debug.LogWarning("crossing Value Not Found"); }
		maximumAttackersLeft = maximamAttackersAllowed[Application.loadedLevel - 3];
		crossingValue.UpdateDisplay(maximumAttackersLeft);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
	
		attackersPassed += 1;
		maximumAttackersLeft -= 1;
		print ("Attackers Passed: " + attackersPassed);
		print("Attackers Left: " + maximumAttackersLeft);
		crossingValue.UpdateDisplay(maximumAttackersLeft);
		
	
		if( attackersPassed >= maximamAttackersAllowed[Application.loadedLevel - 3]) {
			levelManager.changeLevel("03 Lose");
		}
	
	}
	
	public int MaximumAttackersLeft() {
		return maximumAttackersLeft;
	}
	
	
}
