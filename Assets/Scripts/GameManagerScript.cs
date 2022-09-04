using UnityEngine;

public class GameManagerScript : MonoBehaviour {
	AudioSource soundtrack;
	[ SerializeField ] private AudioClip [ ] audioClips;

	private void Start ( ) {
		soundtrack = GetComponent<AudioSource>( );
		soundtrack.clip = audioClips [ Random.Range ( 0, audioClips.Length ) ];
		soundtrack.Play( );
	}
}