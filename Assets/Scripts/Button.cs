using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject prefabDefender;
	public static GameObject selectedDefender;
	private Text costText;

	private Button[] buttonArray;

	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();
		costText = GetComponentInChildren<Text>();
		if (!costText) {
			Debug.LogWarning(name + " cost not found.");
		}
		else {
			costText.text = prefabDefender.GetComponent<Defender>().starCost.ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		
		foreach (Button thisButton in buttonArray ) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = prefabDefender;
		
		print (selectedDefender);
	}
}
