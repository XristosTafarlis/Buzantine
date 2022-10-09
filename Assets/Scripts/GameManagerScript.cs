using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {
	AudioSource soundtrack;
	[SerializeField] private AudioClip[] audioClips;

	private void Start() {
		soundtrack = GetComponent<AudioSource>();
		soundtrack.clip = audioClips[Random.Range(0, audioClips.Length)];
		soundtrack.Play();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(0);
	}
}