using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile; //Which projectile the shooter will fire.
	private GameObject projectileParent;
	private Transform gunTransform;
	private Animator animator;
	private AttackerSpawner myLaneSpawner;

	// Use this for initialization
	void Start () {
	
		animator = GameObject.FindObjectOfType<Animator>();
		projectileParent = GameObject.Find("Projectiles");
		if(!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
		
		gunTransform = gameObject.transform.GetChild(1);	//Getting Gun Child
		
		SetMyLaneSpawner();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(IsAttackerAheadInLane()) {
			animator.SetBool("IsAttacking",true);
		}
		else {
			animator.SetBool("IsAttacking",false);
		}
	
	}
	
	void SetMyLaneSpawner() {
	
		AttackerSpawner[] SpawnersArray = GameObject.FindObjectsOfType<AttackerSpawner>();
		foreach(AttackerSpawner spawner in SpawnersArray) {
			if(spawner.transform.position.y == gameObject.transform.position.y) {
				
				myLaneSpawner = spawner;
				return;
			}
		}
		
		Debug.LogError(name + "Can't find the spawner");
	}
	
	bool IsAttackerAheadInLane() {
		
		if(myLaneSpawner.transform.childCount <= 0 )
			return false;
		
		foreach(Transform attacker in myLaneSpawner.transform) {
			if(attacker.transform.position.x > transform.position.x)
				return true;
		}
		
		return false;
	}
	
	private void Fire() {
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		
		/*The instantiated projectile will have Projectile GameObject's Transform as its parent because
		  we want the projectiles that are already fired to stay, even when attacker has destroyed the defender who 
		  fired that projectile */
		newProjectile.transform.SetParent(projectileParent.transform);
		
		//Setting the position of the fired projectile.
		newProjectile.transform.position = gunTransform.position;
		
	}
}
