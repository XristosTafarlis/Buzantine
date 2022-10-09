using UnityEngine;

public class CloudScroller : MonoBehaviour {
	private float scrollSpeed;
	private float offset;
	private Material mat;

	private void Start() {
		scrollSpeed = Random.Range(0.3f, 0.7f) * (Random.Range(0, 2) * 2 - 1);
		mat = GetComponent<Renderer>().material;
	}

	private void Update() {
		offset = offset + (Time.deltaTime * scrollSpeed) / 10f;
		mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}