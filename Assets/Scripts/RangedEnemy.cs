using UnityEngine;
using UnityEngine.UI;

public class RangedEnemy : MonoBehaviour {
	
	Rigidbody2D rb;
	//Animator anim;
	
	[Header("References")]
	[SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private LayerMask playerLayer;
	[SerializeField] private LayerMask enemyLayer;
	//[SerializeField] private Image healthBar;
	[SerializeField] private GameObject bloodEffect;
	
	//[Header("Audio References")]
	//[SerializeField] private AudioSource deathAudioSource;
	//[SerializeField] private AudioClip[] painSounds;
	//[Space(5)]
	//[SerializeField] private AudioSource swordHitAudioSource;
	//[SerializeField] private AudioClip[] swordHitSounds;
	
	[Header("Variables")]
	[SerializeField] private float speed;										//Enemy speed
	[SerializeField] private int damage;										//Enemy damage
	[SerializeField] private int life;											//Enemy life
	[SerializeField] private float fireRate = 1f;								//Enemy life
	private float range;														//Enemy range
	private bool canFire = false;												//Enemy can shoot
	private float nextFire = 0f;												//Enemy next shot
	private int maxLife;
	
	[Header("Circle")]
	[SerializeField] private Transform stopCheckUpper;							//Circle start
	[SerializeField] private Transform stopCheckMiddle;							//Circle start
	[SerializeField] private float length;										//Circle radius
	[HideInInspector] public bool isStoped;										//Bool if player is stopped
	
	private Collider2D enemyColliderA;
	private Collider2D enemyColliderB;
	private GameObject target;													//Attack reference
	private bool isGrounded;													//Checking if enemy is grounded
	private bool isFighting;													//Checking if enemy is fighting
	
	private void Start() {
		maxLife = life;
		//anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		//anim.Play("Enemy_Walking", -1, Random.Range(0.0f, 1.0f));
		range = Random.Range(9f, 13f);
	}
	
	private void Update() {
		PlayerCheck();
		GroundCheck();
		Walk();
		CheckForEnemy();
		Death();
		HealthRender();
	}
	
	private void OnTriggerEnter2D(Collider2D other) {															//Arrow physics
		if (other.gameObject.tag.Equals("Arrow")) {																//Getting hit by an arrow
			life = life - GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().damage;		//Getting the damage that the player does
			Instantiate(bloodEffect, new Vector3(transform.position.x, other.transform.position.y), other.transform.rotation);
			//deathAudioSource.PlayOneShot(painSounds[Random.Range(0, painSounds.Length)]);
		}
	}
	
	// Won't work for ranged enemies ->
	/*private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag.Equals("Player")) {
			//anim.SetBool("EnemyAttacks", true);								//Playing attack animation
			target = other.gameObject;										//Passing player object on a variable
			isFighting = true;
			isStoped = true;
		}
	}
	
	private void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.tag.Equals("Enemy")) {
			//anim.SetBool("EnemyIsStill", false);							//Ending idling animation
		}
	}*/
	
	private void HealthRender() {
		//if (healthBar != null) {
		//	healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (float)life / maxLife, 0.05f);
		//}
	}
	
	void PlayerCheck(){
		bool inRange = Physics2D.OverlapCircle(transform.position, range, playerLayer);
		if (inRange == true){
			speed = 0f;
			
			//Enemy fires acording to fire rate when in range of the player
			if (canFire == false && Time.time >= nextFire) {
				canFire = true;
			}
			if (canFire == true) {
				canFire = false;
				nextFire = Time.time + 1f / fireRate;
				Debug.Log("Add the shooting mechanic");
			}
		}
	}
	
	//Increase gravity on heavy slopes 
	private void GroundCheck() {
		if (groundCheck != null) {
			isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
			if (isGrounded) {
				rb.gravityScale = 1f;
			} else {
				rb.gravityScale = 8f;
			}
		}
	}
	
	private void Walk() {
		if (isStoped == false) {
			rb.velocity = new Vector2(-speed, 0);							//Making enemy move
		} else {
			rb.velocity = Vector2.zero;
			rb.gravityScale = 0f;
		}
	}
	
	private void CheckForEnemy() {
		if (life > 0) {
			enemyColliderA = Physics2D.OverlapCircle(stopCheckUpper.position, length, enemyLayer);		//Casting the 3 circles
			enemyColliderB = Physics2D.OverlapCircle(stopCheckMiddle.position, length, enemyLayer);

			//Upper circle
			if (enemyColliderA && enemyColliderA.tag.Equals("Enemy")) {				//Checking if circle is overlaping an enemy in front
				if (enemyColliderA.GetComponent<Enemy>().isStoped == true) {		//Checking if enemy in front is stoped
					//anim.SetBool("EnemyIsStill", true);								//Playing idle animation
					isStoped = true;												//Stoping
				}
			} else if (isFighting == false) {										//If this enemy is not fighting
				//anim.SetBool("EnemyIsStill", false);								//Play walking animation again and...
				isStoped = false;													//...Start moving
			}
			
			//Middle circle
			if (enemyColliderB && enemyColliderB.tag.Equals("Enemy")) {				//Same as above
				if (enemyColliderB.GetComponent<Enemy>().isStoped == true) {
					//anim.SetBool("EnemyIsStill", true);
					isStoped = true;
				}
			} else if (isFighting == false) {
				//anim.SetBool("EnemyIsStill", false);
				isStoped = false;
			}
		}
	}
	
	private void AttackEnable() {	//Called in animator
		Instantiate(bloodEffect, new Vector3(target.transform.position.x + 0.4f, target.transform.position.y), Quaternion.Euler(0f, 0f, 180f));
		target.GetComponent<PlayerScript>().TakeDamage(damage);
		//swordHitAudioSource.PlayOneShot(swordHitSounds[Random.Range(0, swordHitSounds.Length)]);
	}
	
	private void Death() {
		if (life <= 0) {															//Enemy death physics
			rb.velocity = new Vector2(0f, 0f);										//Stoping enemy
			GetComponent<CapsuleCollider2D>().enabled = false;						//Disabling colliders
			//GetComponent<CircleCollider2D>().enabled = false;						//Disabling colliders
			//anim.SetBool("EnemyIsDead", true);										//Playing death animation
			rb.gravityScale = 0;													//Removing gravity

			foreach (Transform child in transform) {								//Removing arrows
				if (child.name != "Canvas") {
					Destroy(child.gameObject);
				} else {
					Destroy(child.gameObject, 0.09f);
				}
			}
			Destroy(gameObject, 1f);												//Removing enemy's sprite
		}
	}
	
	private void OnDrawGizmosSelected() {
		Gizmos.DrawWireSphere(stopCheckUpper.position, length);						//Debug gizmos
		Gizmos.DrawWireSphere(stopCheckMiddle.position, length);
		Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
		Gizmos.DrawWireSphere(transform.position, range);
	}
}