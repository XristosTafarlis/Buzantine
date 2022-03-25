//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{

	public float speed;      	//Enemy speed
	public int life;            //Enemy life
	public int damage;          //Enemy damage per hitt

	public Transform stopCheck;	//Raycast start
	public float length;		//Raycast lenth
	private bool stop;			//Bool if player is stoped
	private RaycastHit2D hit;

	private GameObject target;

	void Start(){
		this.GetComponent<Animator>().Play("Enemy_Walking", -1, Random.Range(0.0f, 1.0f));
	}


	void Update(){
		if(life > 0){
			hit = Physics2D.Raycast(stopCheck.position, transform.TransformDirection(Vector2.left), length); //Check if there is an enemy close in front
		}
		
		if (hit){
			if (hit.collider.gameObject.tag.Equals("Enemy")){
				this.GetComponent<Animator>().SetBool("EnemyIsStill", true);
				stop = true;
			}
		}else{
			this.GetComponent<Animator>().SetBool("EnemyIsStill", false);
			stop = false;
		}
		
		
		if(stop == false){
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);    //Making enemy move
		}
		
		if (life <= 0){														//Enemy death physics
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);//Stoping enemy
			this.GetComponent<CapsuleCollider2D>().enabled = false;			//Disabling colliders
			this.GetComponent<CircleCollider2D>().enabled = false;			//Disabling colliders
			this.GetComponent<Animator>().SetBool("EnemyIsDead", true);		//Playing death animation
			this.GetComponent<Rigidbody2D>().gravityScale = 0;				//Removing gravity
			
			int i = 0;
			foreach (Transform child in transform) {						//Removing arrows
				i += 1;
				Destroy(child.gameObject);
			}
			Destroy(gameObject, 1);											//Removing enemy's sprite
		}
	}
	
	//Arrow physics
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag.Equals("Arrow")){                                                       //Getting hit by an arrow
			life -= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().damage;     //Getting the damage that the player does
		}
	}

	void OnCollisionEnter2D(Collision2D other) {

		if(other.gameObject.tag.Equals("Player")){
			this.GetComponent<Animator>().SetBool("EnemyAttacks", true);        //Playing attack animation
			target = other.gameObject;                                          //Passing player object on a variable
		}
		
		//if(other.gameObject.tag.Equals("Enemy")){
		//	this.GetComponent<Animator>().SetBool("EnemyIsStill", true);        //Playing idle animation
		//}
	}

	 void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.tag.Equals("Enemy")){
			//this.GetComponent<Enemy>().stop = false;
			this.GetComponent<Animator>().SetBool("EnemyIsStill", false);           //Ending idling animation
		}
	}

	void AttackEnable(){
		target.GetComponent<PlayerScript>().life -= damage;
		//Debug.Log(target.GetComponent<PlayerScript>().life);
	}
	
	void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(stopCheck.position, length);
    }
}