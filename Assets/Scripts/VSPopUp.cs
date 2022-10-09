using UnityEngine.UI;
using UnityEngine;

public class VSPopUp : MonoBehaviour {
	[SerializeField] private Image image;

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			image.enabled = true;
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			image.enabled = false;
		}
	}
}