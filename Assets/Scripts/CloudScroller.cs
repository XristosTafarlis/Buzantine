using UnityEngine;

public class CloudScroller : MonoBehaviour{
	float scrollSpeed;
	float offset;
	Material mat;

	void Start(){
		scrollSpeed = Random.Range(0.3f, 0.7f);
		mat = GetComponent<Renderer>().material;
	}
	void Update(){
		offset += (Time.deltaTime * scrollSpeed) / 10f;
		mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}