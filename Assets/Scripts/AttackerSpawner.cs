using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {

	public GameObject[] attackerPrefabs;

	GameObject parentAttackerObject;
	void Start(){
		parentAttackerObject = GameObject.Find("Attacker");
		if(!parentAttackerObject) {
			parentAttackerObject = new GameObject("Attacker");
		}
	}

	// Update is called once per frame
	void Update () {
		
		foreach( GameObject thisAttacker in attackerPrefabs){
			//If it is the time to spawn an Attacker,them Spawn it
			if(isTimeToSpawn(thisAttacker)) {
				Spawn (thisAttacker);
			}
		}
	}
	
	bool isTimeToSpawn(GameObject attackerGameObject) {
		
		float meanSpawnDelay = attackerGameObject.GetComponent<Attacker>().appearAfterSeconds;
		float spawnsPerSecond = 1/meanSpawnDelay;
		
		/*If the meanSpawnDelay is less than Time.DeltaTime i.e. less than the frame rate, then this means we are trying to create 
		  an enemy every frame. So Log an error */
		 if(Time.deltaTime > meanSpawnDelay){
		 	Debug.LogWarning("Creating too many Attackers");
		 }
		 
		 float threshold = spawnsPerSecond * Time.deltaTime / 2;
		 
		 return (Random.value < threshold);	
 	}
	
	public void Spawn(GameObject myGameObject) {
	
		GameObject newObject = Instantiate(myGameObject,gameObject.transform.position,Quaternion.identity) as GameObject;
		newObject.transform.SetParent(gameObject.transform);
	}
}
