using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {
	[ Header ( "References" ) ]
	[ SerializeField ] private GameObject player;
	[ SerializeField ] private GameObject rotationPoint;
	[ SerializeField ] private GameObject GameManager;
	[ Space ( 10 ) ]
	[ SerializeField ] private Text text;
	[ SerializeField ] private Text wavesText;
	[ SerializeField ] private Image crosshair;
	[ Space ( 10 ) ]
	//[SerializeField] Image formations;

	private float fireRate;
	private float count;
	private Canvas myCanvas;

	private void Start( )
	{
		myCanvas = GetComponent<Canvas>( );
		fireRate = rotationPoint.GetComponent<Bow>( ).fireRate;

		//if(formations != null){
		//	GetComponent<Canvas>( ).sortingOrder = 5;
		//	Invoke("DestroyFormations", 5f);
		//}

	}

	private void Update ( )
	{
		TextUpdater ( );
		CrosshairFollowMouse ( );
		FireIndicator ( );
		WaveCountDisplay ( );
	}

	//private void DestroyFormations( ){
	//	GetComponent<Canvas>( ).sortingOrder = -5;
	//	Destroy(formations);
	//}

	private void CrosshairFollowMouse ( )
	{
		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle ( myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos );
		crosshair.transform.position = myCanvas.transform.TransformPoint ( pos );
	}

	private void TextUpdater ( )
	{
		if ( player.GetComponent<PlayerScript>( ).endTheGame == true )
		{
			if ( player.GetComponent<PlayerScript>( ).wonTheGame == true )
			{
				text.text = "Victory!";
				text.color = new Color ( 0.36f, 0.88f, 0.42f, 1f );
			}
			else
			{
				text.color = new Color ( 0.88f, 0.36f, 0.42f, 1f );
			}
		}
	}

	private void FireIndicator ( )
	{
		if ( rotationPoint.GetComponent<Bow>( ).canFire == true || crosshair.fillAmount <= 0f /*Good enough*/ )
		{
			count = 1f / fireRate;
			crosshair.color = Color.green;
			crosshair.fillAmount = 1f;
		}
		if ( rotationPoint.GetComponent<Bow>( ).canFire == false )
		{
			count = count - Time.deltaTime;
			crosshair.color = Color.red;
			crosshair.fillAmount = count / ( 1f / fireRate );
		}
	}

	private void WaveCountDisplay ( )
	{
		if ( GameManager.GetComponent<WaveSpawner>( ).waveCount == 1 )
		{
			wavesText.text = "Last wave";
		}
		else if ( GameManager.GetComponent<WaveSpawner>( ).waveCount == 2 ){
			wavesText.text = "Wave 2 of 3";
		}
		else if ( GameManager.GetComponent<WaveSpawner>( ).waveCount == 3 ){
			wavesText.text = "Wave 1 of 3";
		}
	}
}