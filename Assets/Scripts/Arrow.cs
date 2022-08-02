using UnityEngine;

public class Arrow : MonoBehaviour{

	[SerializeField] Sprite HittSprite;

	Rigidbody2D rb;
	bool hasHit;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
	}

	void Update(){
		//Arrow rotation mathematics
		if(hasHit == false){
			float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}

	void OnTriggerEnter2D(Collider2D other){					/*[Arrow on hit physics]*/

		if(other.gameObject.tag.Equals("Enemy")){				//Remove tip of arrow if target is an Enemy
			GetComponent<SpriteRenderer>().sprite = HittSprite;
		}
		if(other.gameObject.tag.Equals("Ground")){
			GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
			GetComponent<AudioSource>().Play();
		}
		transform.parent = other.transform;						//Child the arrow to the target
		GetComponent<CircleCollider2D>().enabled = false;		//Disabling the coliders of thrown arrows
		hasHit = true;											//Disablind rotation of arrow
		rb.velocity = Vector2.zero;								//Stoping arrow
		rb.isKinematic = true;									//Stoping gravity for thown arrow
		Destroy(gameObject, 20.0f);								//Destroying arrow after 20 seconds
	}
}