using UnityEngine;

public class Bow : MonoBehaviour{
	
	[Header("References")]
	[SerializeField] GameObject arrow;
	[SerializeField] Transform shotPoint;
	[SerializeField] AudioSource shotSource;
	
	[Header("Variables")]
	float launchForce;
	float fireRate;
	float nextFire = 0f;
	
	void Start(){
		FireRate();
		SetLaunchForce();
	}
	
	//Bow mouse follow and shot when click
	
	void Update(){	
		Vector2 bowPosition = transform.position;
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 direction = mousePosition - bowPosition;
		transform.right = direction;

		if (Input.GetMouseButtonDown(0) && Time.time >= nextFire){
			nextFire = Time.time + 1f/fireRate; 
			Shoot();
		}
	}
	
	void SetLaunchForce(){
		if(MainMapCanvasScript.hasWonOstrogoths && MainMapCanvasScript.hasWonSassanids){
			launchForce = 13f;
		}else if(MainMapCanvasScript.hasWonOstrogoths || MainMapCanvasScript.hasWonSassanids){
			launchForce = 11.5f;
		}else{
			launchForce = 10f;
		}
	}
	
	void FireRate(){
		if(LevelSystem.level == 1){
			fireRate = 1f;
		}else if(LevelSystem.level == 2){
			fireRate = 1.1f;
		}else if(LevelSystem.level == 3){
			fireRate = 1.2f;
		}else if(LevelSystem.level == 4){
			fireRate = 1.3f;
		}else if(LevelSystem.level == 5){
			fireRate = 1.5f;
		}else if(LevelSystem.level == 6){
			fireRate = 1.8f;
		}else if(LevelSystem.level == 7){
			fireRate = 2.3f;
		}else if(LevelSystem.level == 8){
			fireRate = 3.1f;
		}else if(LevelSystem.level == 9){
			fireRate = 4.4f;
		}else if(LevelSystem.level >= 10){
			fireRate = 6.5f;
		}
	}

	void Shoot() {
		shotSource.pitch = Random.Range(0.95f, 1.05f);
		shotSource.Play();
		GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
		newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
	}
}
