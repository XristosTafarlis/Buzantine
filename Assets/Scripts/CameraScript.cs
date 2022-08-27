using UnityEngine;

public class CameraScript : MonoBehaviour {
	[ Header ( "References" ) ]
	[ SerializeField ] private Transform target;
	[ SerializeField ] private Rigidbody2D rb;

	[ Header ( "Variables" ) ]
	[ Range ( 1 , 50 )]
	[ SerializeField ] private float smoothing;
	[ Tooltip ( "Bottom left" ) ]
	[ SerializeField ] private Vector2 minPos;
	[ Space ( 15 ) ]
	[ Tooltip( "Top right" ) ]
	[ SerializeField ] private Vector2 maxPos;
 
	private void Start ( )
	{
		if ( PlayerPrefs.HasKey ( "X" ) == true || PlayerPrefs.HasKey ( "Y" ) == true )
		{
			transform.position = new Vector3 ( PlayerPrefs.GetFloat ( "X" ), PlayerPrefs.GetFloat ( "Y" ), -10 );
		}
		else
		{
			transform.position = new Vector3 ( -62f, -10f, -10 );
		}
	}

	private void FixedUpdate ( )
	{
		if ( transform.position != target.position ) {
			Vector3 targetPos = new Vector3 ( target.position.x, target.position.y, transform.position.z );

			targetPos.x = Mathf.Clamp ( targetPos.x, minPos.x, maxPos.x );
			targetPos.y = Mathf.Clamp ( targetPos.y, minPos.y, maxPos.y );

			transform.position = Vector3.Lerp ( transform.position, targetPos, smoothing / 100 );
		}
	}
}