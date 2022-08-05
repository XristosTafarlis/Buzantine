using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour{
	[Header("References")]
	[SerializeField] GameObject player;
	[SerializeField] GameObject bow;
	[SerializeField] GameObject GameManager;
	[Space(10)]
	[SerializeField] Text text;
	[SerializeField] Text wavesText;
	[SerializeField] Image crosshair;

	float fireRate;
	float count;
	Canvas myCanvas;

	void Start(){
		myCanvas = GetComponent<Canvas>();
		fireRate = bow.GetComponent<Bow>().fireRate;
		count = fireRate;
	}

	void Update(){
		TextUpdater();
		CrosshairFolowMouse();
		FireIndicator();
		WaveCountDisplay();
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

	void FireIndicator(){
		//Lord showed me how to write this, cause I am not sure how I thought of it
		if(bow.GetComponent<Bow>().canFire){
			count = fireRate;
			crosshair.fillAmount = 1f;
			crosshair.color = Color.green;
		}else{
			count = count - Time.deltaTime;
			crosshair.fillAmount = 1f - count;
			crosshair.color = Color.red;
		}
	}

	void WaveCountDisplay(){
		if(GameManager.GetComponent<WaveSpawner>().waveCount == 1){
			wavesText.text = "Last wave";
		}else {
			wavesText.text = GameManager.GetComponent<WaveSpawner>().waveCount + " waves";
		}
	}
}