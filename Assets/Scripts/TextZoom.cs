using UnityEngine;
using UnityEngine.UI;

public class TextZoom : MonoBehaviour{
	Text text;
	
	void Start(){
		text = GetComponent<Text>();
	}
	
	public void Zoom(){
		text.fontSize += 5;
	}
	
	public void UnZoom(){
		text.fontSize -= 5;
	}
}