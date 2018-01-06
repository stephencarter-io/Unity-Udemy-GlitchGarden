using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	private void Awake() {
		DontDestroyOnLoad(gameObject);
		Debug.Log("Don't destroy on load: " + name);
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];
		Debug.Log("Playing clip: " + thisLevelMusic);

		if (thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	public void ChangeVolume(float volume) {
		audioSource.volume = volume;
	}
	
	private void OnEnable() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnDisable() {
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
	
}
