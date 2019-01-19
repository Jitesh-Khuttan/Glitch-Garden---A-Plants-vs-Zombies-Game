using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 5;
	
	private Slider slider;
	private AudioSource audioSource;
	private LevelController levelController;
	private bool isEndOfGame = false;
	public GameObject winLabel;

	// Use this for initialization
	void Start () {
	
		slider = GetComponent<Slider>();

		audioSource = GetComponent<AudioSource>();
		levelController = GameObject.FindObjectOfType<LevelController>();
		winLabel = GameObject.Find ("You Win");
		winLabel.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
		slider.value = (Time.timeSinceLevelLoad / levelSeconds);
		if(Time.timeSinceLevelLoad >= levelSeconds && !isEndOfGame) {	
			audioSource.Play();
			Invoke ("LoadNextLevel", audioSource.clip.length);
			winLabel.SetActive(true);
			isEndOfGame = true;
		}
	
	}
	
	private void LoadNextLevel() {
		
		levelController.LoadNextLevel();
	
	}
}
