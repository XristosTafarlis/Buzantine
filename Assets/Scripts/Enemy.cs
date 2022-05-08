using UnityEngine;

public class Enemy : MonoBehaviour{
	
	Rigidbody2D rb;
	Animator anim;
	
	[Header("Refferences")]
	[SerializeField] Transform groundCheck;
	[SerializeField] LayerMask groundLayer;
	[SerializeField] LayerMask enemyLayer;
	
	[Header("Variables")]
	[SerializeField] float speed;				//Enemy speed
	[SerializeField] int damage;				//Enemy damage
	[SerializeField] int life;					//Enemy life
	
	[Header("Raycast")]
	[SerializeField] Transform stopCheck;		//Raycast start
	[SerializeField] float length;				//Raycast lenth
	RaycastHit2D hit;							//Raycast hit
	bool stop;									//Bool if player is stoped
	
	GameObject target;							//Attack refference
	bool isGrounded;							//Checking if enemy is grounded

	void Start(){
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		anim.Play("Enemy_Walking", -1, Random.Range(0.0f, 1.0f));
	}

	void Update(){
		Walk();
		CheckForEnemy();
		Death();
		GroundCheck();
	}
	
	void OnTriggerEnter2D(Collider2D other) {			//Arrow physics
		if(other.gameObject.tag.Equals("Arrow")){                                                       //Getting hit by an arrow
			life -= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().damage;     //Getting the damage that the player does
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag.Equals("Player")){
			anim.SetBool("EnemyAttacks", true);		//Playing attack animation
			target = other.gameObject;				//Passing player object on a variable
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.tag.Equals("Enemy")){
			anim.SetBool("EnemyIsStill", false);           //Ending idling animation
		}
	}
	
	void GroundCheck(){
		if(groundCheck != null){
			isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
			if(isGrounded){
				rb.gravityScale = 1f;
			}else{
				rb.gravityScale = 4f;
			}
		}
	}
	
	void Walk(){
		if(stop == false){
			rb.velocity = new Vector2(-speed, 0);	//Making enemy move
		}
	}
	
	void CheckForEnemy(){
		if(life > 0){
			//Check if there is another enemy close in front
			hit = Physics2D.Raycast(stopCheck.position, Vector2.left, length);
		}
		
		if (hit){
			if (hit.collider.gameObject.tag.Equals("Enemy")){
				if(rb.velocity.x > -0.1f){
					anim.SetBool("EnemyIsStill", true);
					stop = true;
				}
			}
		}else{
			anim.SetBool("EnemyIsStill", false);
			stop = false;
		}
	}
	
	void AttackEnable(){
		target.GetComponent<PlayerScript>().life -= damage;
	}
	
	void Death(){
		if (life <= 0){														//Enemy death physics
			rb.velocity = new Vector2(0f, 0f);								//Stoping enemy
			GetComponent<CapsuleCollider2D>().enabled = false;				//Disabling colliders
			GetComponent<CircleCollider2D>().enabled = false;				//Disabling colliders
			anim.SetBool("EnemyIsDead", true);								//Playing death animation
			rb.gravityScale = 0;											//Removing gravity
			
			int i = 0;
			foreach (Transform child in transform) {						//Removing arrows
				i += 1;
				Destroy(child.gameObject);
			}
			Destroy(gameObject, 1);											//Removing enemy's sprite
		}
	}
	
	void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(stopCheck.position, length);
        Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
    }
}