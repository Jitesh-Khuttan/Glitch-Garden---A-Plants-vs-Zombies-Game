using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		
		//print ("Triggered Activated by: " + collider.gameObject);
		Destroy(collider.gameObject);
	
	}
}
