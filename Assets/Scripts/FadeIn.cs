using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class FadeIn : MonoBehaviour {

	public float fadeInTime;
	private Image fadePanel;
	private Color imageColor = Color.black;
	private MusicManager musicManager;
	
	// Use this for initialization
	void Start () {
		fadePanel = this.GetComponent<Image>();
		print ("The value of Alpha of imageColor is: " + imageColor.a);
		
		//To Make the volume appropriate when it enter the Start Screen.
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		musicManager.SetVolume(PlayerPrefsManager.GetMasterVolume());
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Time.timeSinceLevelLoad < fadeInTime){
		
			/* If we divide the time of the frame with the total time in which panel needs to be faded away,
			then we could actually get % amount, by which we can decrease our alpha value */
			
			float alphaAmountToChange = Time.deltaTime / fadeInTime;
			imageColor.a -= alphaAmountToChange;
			fadePanel.color = imageColor;
			
		}
		else{
			
			gameObject.SetActive(false);
		}
	
	}
}
