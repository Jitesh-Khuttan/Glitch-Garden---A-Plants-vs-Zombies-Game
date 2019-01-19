using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

	public float health;
	private float currentHealth;
	private Slider powerSlider;
	// Use this for initialization
	void Start () {
		
		currentHealth = health;
		powerSlider = GetComponentInChildren<Slider>();
//		if(powerSlider)
//			print ("Power Slider Found of Object: " + name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void DealDamage(float damage){
		
		currentHealth  -= damage;
		powerSlider.value = currentHealth/health;
		if(currentHealth <=0) {
			//Trigger an animation here
			DestroyObject (gameObject);	//Remove it and call DestroyObject from Animation Event at the end of animation
			
		}	
	}
	
	public void DestroyObject(GameObject currentObject){
		Destroy(currentObject);
	}
	
}
