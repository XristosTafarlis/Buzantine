using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour{
	[Header("References")]
	[SerializeField] GameObject player;
	[SerializeField] GameObject rotationPoint;
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
		fireRate = rotationPoint.GetComponent<Bow>().fireRate;
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
		if(rotationPoint.GetComponent<Bow>().canFire == true || crosshair.fillAmount <= 0f /*Good enough*/ ){
			count = 1f / fireRate;
			crosshair.color = Color.green;
			crosshair.fillAmount = 1f;
		}
		if(rotationPoint.GetComponent<Bow>().canFire == false){
			count -= Time.deltaTime;
			crosshair.color = Color.red;
			crosshair.fillAmount = count / (1f / fireRate);
		}
	}

	void WaveCountDisplay(){
		if(GameManager.GetComponent<WaveSpawner>().waveCount == 1){
			wavesText.text = "Last wave";
		}else if(GameManager.GetComponent<WaveSpawner>().waveCount == 2){
			wavesText.text = "Wave 2 of 3";
		}else if(GameManager.GetComponent<WaveSpawner>().waveCount == 3){
			wavesText.text = "Wave 1 of 3";
		}
	}
}