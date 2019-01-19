using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private Camera cam;
	private GameObject DefenderHierarchy;
	private StarsDisplay starDisplay;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		DefenderHierarchy = GameObject.Find("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarsDisplay>();
		
		if(!DefenderHierarchy) {
			DefenderHierarchy = new GameObject("Defenders");
		}
	}	
	
	// Update is called once per frame
	void Update () {
	}
	
	
	void OnMouseDown() {
	
		Vector2 boxPosition = CalculateWorldPointOfMouseClick(Input.mousePosition);
		Vector2 rounedBoxPosition = SnapToGrid(boxPosition);
		GameObject defender = Button.selectedDefender;
		
		int defenderCost = defender.GetComponent<Defender>().starCost;
		
		if(starDisplay.UseStars(defenderCost) == StarsDisplay.Status.SUCCESS) {
			GameObject newDefender = Instantiate(Button.selectedDefender,rounedBoxPosition,Quaternion.identity) as GameObject;	//Quaternion.identity means No Rotation
			newDefender.transform.SetParent(DefenderHierarchy.transform);	
		}
		else {

			Debug.LogError("Not enough Stars");
		}
		
	}
	
	Vector2 SnapToGrid(Vector2 rawPosition) {
		float newPositionX,newPositionY;
		
//		if(positionY - 0.5 < Mathf.Floor(positionY) ) {
//			newPositionY = Mathf.Floor(positionY);
//		}
//		else {
//			newPositionY = Mathf.Ceil(positionY);
//		}
//		
//		if(positionX - 0.5 < Mathf.Floor(positionX) ) {
//			newPositionX = Mathf.Floor(positionX);
//		}
//		else{
//			newPositionX = Mathf.Ceil(positionX);
//		}
	
		newPositionX = Mathf.RoundToInt(rawPosition.x);
		newPositionY = Mathf.RoundToInt(rawPosition.y);	
		
		return new Vector2(newPositionX,newPositionY);	
	}
	
	Vector2 CalculateWorldPointOfMouseClick(Vector3 screenCoordinates) {
		Vector3 worldCoordinates3 = cam.ScreenToWorldPoint(screenCoordinates);
		
		Vector2 worldCoordinates2 = new Vector2(worldCoordinates3.x,worldCoordinates3.y);
		return worldCoordinates2;
	}
	
}
