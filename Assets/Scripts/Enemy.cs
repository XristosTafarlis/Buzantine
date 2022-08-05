using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour{

	Rigidbody2D rb;
	Animator anim;

	[Header("References")]
	[SerializeField] Transform groundCheck;
	[SerializeField] LayerMask groundLayer;
	[SerializeField] LayerMask enemyLayer;
	[SerializeField] Image healthBar;
	[SerializeField] GameObject bloodEffect;

	[Header("Aidio References")]
	[SerializeField] AudioSource deathAudioSource;
	[SerializeField] AudioClip[] painSounds;
	[Space(5)]
	[SerializeField] AudioSource swordHitAudioSource;
	[SerializeField] AudioClip[] swordHitSounds;

	[Header("Variables")]
	[SerializeField] float speed;								//Enemy speed
	[SerializeField] int damage;								//Enemy damage
	[SerializeField] int life;									//Enemy life
	int maxLife;

	[Header("Circle")]
	[SerializeField] Transform stopCheckUpper;					//Circle start
	[SerializeField] Transform stopCheckMiddle;					//Circle start
	[SerializeField] float length;								//Circle radious
	[HideInInspector] public bool isStoped;						//Bool if player is stoped

	Collider2D enemyColliderA;
	Collider2D enemyColliderB;
	GameObject target;											//Attack refference
	bool isGrounded;											//Checking if enemy is grounded
	bool isFighting;											//Checking if enemy is fighting

	void Start(){
		maxLife = life;
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		anim.Play("Enemy_Walking", -1, Random.Range(0.0f, 1.0f));
	}

	void Update(){
		GroundCheck();
		Walk();
		CheckForEnemy();
		Death();
		HealthRender();
	}

	void OnTriggerEnter2D(Collider2D other) {			//Arrow physics
		if(other.gameObject.tag.Equals("Arrow")){														//Getting hit by an arrow
			life -= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().damage;		//Getting the damage that the player does
			Instantiate(bloodEffect, new Vector3(transform.position.x, other.transform.position.y), other.transform.rotation);
			deathAudioSource.PlayOneShot(painSounds[Random.Range(0, painSounds.Length)]);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag.Equals("Player")){
			anim.SetBool("EnemyAttacks", true);		//Playing attack animation
			target = other.gameObject;				//Passing player object on a variable
			isFighting = true;
			isStoped = true;
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.tag.Equals("Enemy")){
			anim.SetBool("EnemyIsStill", false);			//Ending idling animation
		}
	}

	void HealthRender(){
		if(healthBar != null)
			healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (float)life / maxLife, 0.05f);
	}

	void GroundCheck(){
		if(groundCheck != null){
			isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
			if(isGrounded){
				rb.gravityScale = 1f;
			}else{
				rb.gravityScale = 8f;
			}
		}
	}

	void Walk(){
		if(isStoped == false){
			rb.velocity = new Vector2(-speed, 0);	//Making enemy move
		}else{
			rb.velocity = Vector2.zero;
			rb.gravityScale = 0f;
		}
	}

	void CheckForEnemy(){
		if(life > 0){
			enemyColliderA = Physics2D.OverlapCircle(stopCheckUpper.position, length, enemyLayer);		//Casting the 3 circles
			enemyColliderB = Physics2D.OverlapCircle(stopCheckMiddle.position, length, enemyLayer);

			//Upper circle
			if(enemyColliderA && enemyColliderA.tag.Equals("Enemy")){				//Checking if circle is overlaping an enemy in front
				if(enemyColliderA.GetComponent<Enemy>().isStoped == true){			//Checking if enemy in front is stoped
					anim.SetBool("EnemyIsStill", true);								//Playing idle animation
					isStoped = true;												//Stoping
				}
			}else if(!isFighting){													//If this enemy is not fighting
				anim.SetBool("EnemyIsStill", false);								//Play walking animation again and...
				isStoped = false;													//...Start moving
			}

			//Middle circle
			if(enemyColliderB && enemyColliderB.tag.Equals("Enemy")){				//Same as above
				if(enemyColliderB.GetComponent<Enemy>().isStoped == true){
					anim.SetBool("EnemyIsStill", true);
					isStoped = true;
				}
			}else if(!isFighting){
				anim.SetBool("EnemyIsStill", false);
				isStoped = false;
			}
		}
	}

	void AttackEnable(){	//Called in animator
		Instantiate(bloodEffect, new Vector3(target.transform.position.x + 0.4f, target.transform.position.y), Quaternion.Euler(0f, 0f, 180f));
		target.GetComponent<PlayerScript>().TakeDamage(damage);
		swordHitAudioSource.PlayOneShot(swordHitSounds[Random.Range(0, swordHitSounds.Length)]);
	}

	void Death(){
		if (life <= 0){														//Enemy death physics
			rb.velocity = new Vector2(0f, 0f);								//Stoping enemy
			GetComponent<CapsuleCollider2D>().enabled = false;				//Disabling colliders
			GetComponent<CircleCollider2D>().enabled = false;				//Disabling colliders
			anim.SetBool("EnemyIsDead", true);								//Playing death animation
			rb.gravityScale = 0;											//Removing gravity

			foreach (Transform child in transform) {						//Removing arrows
				if(child.name != "Canvas")
					Destroy(child.gameObject);
				else
					Destroy(child.gameObject, 0.09f);
			}
			Destroy(gameObject, 1f);											//Removing enemy's sprite
		}
	}

	void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere(stopCheckUpper.position, length);				//Debug gizmos
		Gizmos.DrawWireSphere(stopCheckMiddle.position, length);
		Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
	}
}