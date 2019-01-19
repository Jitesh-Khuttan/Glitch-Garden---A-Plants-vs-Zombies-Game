using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	//[Range (-1.5f,1f)]
	[Tooltip ("The time after which the Attacker appears on the scene")]
	public float appearAfterSeconds;
	private float currentSpeed;
	private GameObject currentTarget;
	private Health currentTargetHealth;
	private Animator currentAnimation;
//	private static float foxTimer = 0f,lizardTimer = 0f;
//	private GameObject spawnersHierarchy;

	// Use this for initialization
	void Start () {	
		Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
		myRigidBody.isKinematic = true;
		currentAnimation = gameObject.GetComponent<Animator>(); 
//		spawnersHierarchy = GameObject.Find("Spawners");	
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3.left is equivalent to writing (-1,0,0). So it provides the unit direction for movement.
		//So basically it is a unit vector in negative x direction.
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		
		/*To continue the walking of the object after the target is destroyed, just check if the currentTarget exists or not.
		  CurrentTarget's Existence should only be checked if the gameObject is in Attacking State*/
//		if(currentAnimation.GetBool("IsAttacking")){
			if(!currentTarget){
				currentAnimation.SetBool("IsAttacking",false);
//			}
		} 
		
//		foxTimer += Time.deltaTime;
//		lizardTimer += Time.deltaTime;
//		
//		if(GetComponent<Fox>()){	//Means this a fox gameobject
//			if(foxTimer >= appearAfterSeconds) {
//				int randomValue = Random.Range(0,4);
//				//Generates a random value and accordingly selects the spawner from SpawnersHierarchy to instantiate an Attacker
//				Transform instantiator = spawnersHierarchy.transform.GetChild(randomValue);
//				instantiator.GetComponent<AttackerSpawner>().Spawn(gameObject);
//				foxTimer = 0f;
//			}
//		} 
//		else if (GetComponent<Lizard>()){
//			if(lizardTimer >= appearAfterSeconds) {
//				int randomValue = Random.Range(0,4);
//				//Generates a random value and accordingly selects the spawner from SpawnersHierarchy to instantiate an Attacker
//				Transform instantiator = spawnersHierarchy.transform.GetChild(randomValue);
//				instantiator.GetComponent<AttackerSpawner>().Spawn(gameObject);
//				lizardTimer = 0f;
//			}
//		
//		}  
	}
	
	public void SetSpeed(float speed){
		currentSpeed = speed;
	}
	
	void OnTriggerEnter2D(){
	
		//Debug.Log("Following Triggered: " + name);
	}
	
	public void StrikeCurrentTarget(float damage){
		currentTargetHealth = currentTarget.GetComponent<Health>();
			
		if(currentTarget && currentTargetHealth){
			currentTargetHealth.DealDamage(damage);
		}		 
	} 
	
	public void Attack(GameObject collidingObject){
	
		currentTarget = collidingObject;
	
	}
	
}
