using UnityEngine;

public class Arrow : MonoBehaviour {
	[ Header ( "References" ) ]
	[ SerializeField ] private Sprite HittSprite;
	[ SerializeField ] private GameObject trail;
	private Rigidbody2D rb;
	private bool hasHit;

	private void Start ( ) {
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update ( ) {
		//Arrow rotation mathematics
		if ( hasHit == false ) {
			float angle = Mathf.Atan2( rb.velocity.y, rb.velocity.x ) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis( angle, Vector3.forward );
		}
	}

	private void OnTriggerEnter2D ( Collider2D other ) {		/*[Arrow on hit physics]*/
		GetComponent<SpriteRenderer>( ).sprite = HittSprite;	//Remove tip of arrow
		Destroy ( trail, 0.1f );
		if ( other.gameObject.tag.Equals ( "Ground" ) ) {
			GetComponent<AudioSource>( ).pitch = Random.Range( 0.85f, 1.15f );
			GetComponent<AudioSource>( ).Play( );
		}
        transform.parent = other.transform;						//Child the arrow to the target
        GetComponent<CircleCollider2D>( ).enabled = false;		//Disabling the colliders of thrown arrows
        hasHit = true;											//Disabling rotation of arrow
        rb.velocity = Vector2.zero;								//Stopping arrow
        rb.isKinematic = true;									//Stopping gravity for thrown arrow
        Destroy( gameObject, 20.0f );							//Destroying arrow after 20 seconds

	}
}