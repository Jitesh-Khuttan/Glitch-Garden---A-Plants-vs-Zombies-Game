using UnityEngine;
using System.Collections;

public class CollisonEffect : MonoBehaviour {

	public Transform particle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisonTrigger2D(Collision2D collision) {
	
//		Instantiate(particle,this.transform.position,particle.rotation);
//		print ("Boom");
		
	}
}
