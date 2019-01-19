using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float currentSpeed,damage;
	private GameObject collidingObject;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
	}
	
	
	void OnTriggerEnter2D(Collider2D collider) {

		Attacker attacker = collider.gameObject.GetComponent<Attacker>();
		Health health = collider.gameObject.GetComponent<Health>();
		
		if(attacker && health) {
			health.DealDamage(damage);
			Destroy(gameObject);
		}
	}
}
