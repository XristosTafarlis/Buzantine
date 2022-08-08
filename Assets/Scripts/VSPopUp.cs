using UnityEngine.UI;
using UnityEngine;

public class VSPopUp : MonoBehaviour{
	[SerializeField] Image image;

	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player")){
			image.enabled = true;
		}
	}
	void OnTriggerExit2D(Collider2D other) {
		if(other.CompareTag("Player")){
			image.enabled = false;
		}
	}
}
