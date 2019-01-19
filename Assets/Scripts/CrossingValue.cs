using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CrossingValue : MonoBehaviour {

	private Text crossingLeft;
	void Start () {
	}
	
	public void UpdateDisplay(int value) {
		
		crossingLeft = GetComponent<Text>();
		crossingLeft.text = value.ToString();
	}
}
