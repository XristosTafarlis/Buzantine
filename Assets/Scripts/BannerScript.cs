using UnityEngine;

public class BannerScript : MonoBehaviour {
	private bool flag = false;
	private void Update() {
		if (transform.rotation.x < 0.05 && flag == false) {
			transform.Rotate(5f * Time.deltaTime, 5f * Time.deltaTime, 5f * Time.deltaTime);
		} else {
			flag = true;
			transform.Rotate(-5f * Time.deltaTime, -5f * Time.deltaTime, -5f * Time.deltaTime);
		}

		if (transform.rotation.x < -0.05) {
			flag = false;
		}
	}
}