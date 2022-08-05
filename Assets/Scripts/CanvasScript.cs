using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour{
	[SerializeField] GameObject player;
	[SerializeField] Text text;
	[SerializeField] Image crosshair;
	[SerializeField] GameObject bow;
	Canvas myCanvas;

	void Start(){
		myCanvas = GetComponent<Canvas>();
	}

	void Update(){
		TextUpdater();
		CrosshairFolowMouse();
		if(bow.GetComponent<Bow>().canFire == true){
			crosshair.color = Color.green;
		}else{
			crosshair.color = Color.red;
		}
	}

	void CrosshairFolowMouse(){
		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
		crosshair.transform.position = myCanvas.transform.TransformPoint(pos);
	}

	void TextUpdater(){
		if(player.GetComponent<PlayerScript>().endTheGame == true){
			if(player.GetComponent<PlayerScript>().wonTheGame == true){
				text.text = "Victory!";
				text.color = new Color(0.36f, 0.88f, 0.42f, 1f);
			}else{
				text.color = new Color(0.88f, 0.36f, 0.42f, 1f);
			}
		}
	}
}
