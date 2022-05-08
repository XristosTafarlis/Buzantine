//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour{
	
	//[Header("Refferences")]
	Rigidbody2D rb;
	
	[Header("Variables")]
	[SerializeField] float moveSpeed = 5f;
	[SerializeField] float runSpeed = 8f;
	
	float finalSpeed;
	string location = null;

	Vector2 movement;
	
	void Start() {
		rb = gameObject.GetComponent<Rigidbody2D>();
		finalSpeed = moveSpeed;
	}
	
	void Update(){
		MovementRead();
		LocationUpdate();	
		Run();
	}

	void FixedUpdate(){
		rb.MovePosition(rb.position + movement * finalSpeed * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.name == "Macedonia")
			location = "Macedonia";
		else if(other.name == "Thracia")
			location ="Thracia";
		else if(other.name == "Dacia")
			location = "Dacia";
		else if(other.name == "Quaestura Exercitus")
			location = "Quaestura Exercitus";
		else if(other.name == "Illyricum")
			location = "Illyricum";
		else if(other.name == "Italia Annonaria")
			location = "Italia Annonaria";
		else if(other.name == "Italia Suburbicaria")
			location = "Italia Suburbicaria";
		else if(other.name == "Pontica")
			location = "Pontica";
		else if(other.name == "Asiana")
			location = "Asiana";
		else if(other.name == "Oriens")
			location = "Oriens";
		else if(other.name == "Aegyptus")
			location = "Aegyptus";
		else if(other.name == "Africa")
			location = "Africa";
		else if(other.name == "Spaniae")
			location = "Spaniae";
	}
	
	void OnTriggerExit2D(Collider2D other) {
		location = null;
	}
	
	void MovementRead(){
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
	}
	
	void Run(){
		if(Input.GetKeyUp(KeyCode.LeftShift)){
			finalSpeed = moveSpeed;
		}if(Input.GetKeyDown(KeyCode.LeftShift)){
			finalSpeed = runSpeed;
		}
	}
	
	void LocationUpdate(){
		if (Input.GetKey(KeyCode.Space)){
			if (location == "Macedonia"){
				Debug.Log("Macedonia");
				SceneManager.LoadScene(1);
			}
			if (location == "Spaniae"){
				Debug.Log("Spaniae");
				SceneManager.LoadScene(2);
			}
		}
	}
}