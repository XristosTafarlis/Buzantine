using UnityEngine;

public class Bow : MonoBehaviour {

	[ Header ( "References" ) ]
	[ SerializeField ] private GameObject arrow;
	[ SerializeField ] private Transform shotPoint;
	[ SerializeField ] private AudioSource shotSource;

	[ Header ( "Variables" ) ]
	[ HideInInspector ] public float fireRate;
	[ HideInInspector ] public bool canFire = false;
	private float launchForce;
	private float nextFire = 0f;
	private float zRotation;

	private void Awake ( ) {
		FireRate ( );
	}

	private void Start ( )
	{
		SetLaunchForce ( );
	}

	private void Update ( )
	{
		MouseLook ( );
		ClampRotation ( );
		Fire ( );
	}

	private void SetLaunchForce ( )
	{
		if ( MainMapCanvasScript.hasWonOstrogoths && MainMapCanvasScript.hasWonSassanids )
		{
			launchForce = 13f;
		}
		else if ( MainMapCanvasScript.hasWonOstrogoths || MainMapCanvasScript.hasWonSassanids )
		{
			launchForce = 11.5f;
		}
		else
		{
			launchForce = 10f;
		}
	}

	private void FireRate ( )
	{
		if ( LevelSystem.level == 1 )
		{
			fireRate = 1f;
		}
		else if ( LevelSystem.level == 2 )
		{
			fireRate = 1.05f;
		}
		else if ( LevelSystem.level == 3 )
		{
			fireRate = 1.1f;
		}
		else if ( LevelSystem.level == 4 )
		{
			fireRate = 1.2f;
		}
		else if ( LevelSystem.level == 5 )
		{
			fireRate = 1.25f;
		}
		else if ( LevelSystem.level == 6 )
		{
			fireRate = 1.35f;
		}
		else if ( LevelSystem.level == 7 )
		{
			fireRate = 1.5f;
		}
		else if ( LevelSystem.level == 8 )
		{
			fireRate = 1.8f;
		}
		else if ( LevelSystem.level == 9 )
		{
			fireRate = 2f;
		}
		else if ( LevelSystem.level >= 10 )
		{
			fireRate = 3.5f;
		}
	}

	private void Fire ( )
	{
		//Bow followmouse and shoots when click
		if ( canFire == false && Time.time >= nextFire )
		{
			canFire = true;
		}
		if ( canFire == true )
		{
			if ( Input.GetMouseButtonDown ( 0 ) )
			{
				canFire = false;
				nextFire = Time.time + 1f / fireRate;
				Shoot ( );
			}
		}
	}

	private void MouseLook ( )
	{
		Vector2 bowPosition = transform.position;
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint ( Input.mousePosition );
		Vector2 direction = mousePosition - bowPosition;
		transform.right = direction;
	}

	private void ClampRotation ( )
	{
		zRotation = transform.eulerAngles.z;
		if ( transform.eulerAngles.z > 50f && zRotation < 180f )
		{
			zRotation = 49.9f;
		}
		else if ( zRotation < 310f && zRotation > 180f )
		{
			zRotation = 310.1f;
		}
		transform.eulerAngles = new Vector3 ( transform.eulerAngles.x, transform.eulerAngles.y, zRotation );
	}

	private void Shoot ( ) {
		GetComponentInChildren<Animator>( ).Play ( "Player_Shoot", 0, 0f );
		shotSource.pitch = Random.Range( 0.9f, 1.1f );
		shotSource.Play( );
		GameObject newArrow = Instantiate( arrow, shotPoint.position, shotPoint.rotation );
		newArrow.GetComponent<Rigidbody2D>( ).velocity = transform.right * launchForce;
	}
}
