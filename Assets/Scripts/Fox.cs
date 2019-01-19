using UnityEngine;
using System.Collections;


[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {

	private Animator foxAnimator;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		
		foxAnimator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		
		GameObject collidingObject = collider.gameObject;
		
		if(!collidingObject.GetComponent<Defender>()){
		  	return;
		 }
		  
		 if(collidingObject.GetComponent<Stone>()){
		  	foxAnimator.SetTrigger("Jump Trigger");	 
		 }
		 else{
		 	foxAnimator.SetBool("IsAttacking",true);
		 	attacker.Attack(collidingObject); 
		 }
		  
		  
	}
	
	void OnTriggerExit2D(Collider2D collider){
	}
}
