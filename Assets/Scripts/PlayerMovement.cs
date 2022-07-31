using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour{
	
	//[Header("References")]
	
	[Header("Variables")]
	[SerializeField] float moveSpeed = 5f;
	[SerializeField] float runSpeed = 8f;
	
	float finalSpeed;
	
	Rigidbody2D rb;
	public static string location = null;

	Vector2 movement;
	
	void Start() {
		Load();
		rb = gameObject.GetComponent<Rigidbody2D>();
		finalSpeed = moveSpeed;
	}
	
	void Update(){
		MovementRead();
		LocationUpdate();	
		Run();
		Save();
	}

	void FixedUpdate(){
		rb.velocity = new Vector2(movement.x * finalSpeed, movement.y * finalSpeed);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.name == "Macedonia")					location = "Macedonia";
		else if(collider.name == "Thracia")					location = "Thracia";
		else if(collider.name == "Dacia")					location = "Dacia";
		else if(collider.name == "Quaestura Exercitus")		location = "Quaestura Exercitus";
		else if(collider.name == "Illyricum")				location = "Illyricum";
		else if(collider.name == "Italia Annonaria")		location = "Italia Annonaria";
		else if(collider.name == "Italia Suburbicaria")		location = "Italia Suburbicaria";
		else if(collider.name == "Pontica")					location = "Pontica";
		else if(collider.name == "Asiana")					location = "Asiana";
		else if(collider.name == "Oriens")					location = "Oriens";
		else if(collider.name == "Aegyptus")				location = "Aegyptus";
		else if(collider.name == "Africa")					location = "Africa";
		else if(collider.name == "Spaniae")					location = "Spaniae";
		else if(collider.name == "Dara")					location = "Dara";
		else if(collider.name == "Taginae")					location = "Taginae";
	}
	
	void OnTriggerExit2D(Collider2D collider) {
		location = null;
	}
	
	void MovementRead(){
		movement.x = Input.GetAxis("Horizontal");
		movement.y = Input.GetAxis("Vertical");
	}
	
	void Run(){
		if(Input.GetKeyUp(KeyCode.LeftShift)){
			finalSpeed = moveSpeed;
		}if(Input.GetKeyDown(KeyCode.LeftShift)){
			finalSpeed = runSpeed;
		}
	}
	
	void Load(){
		transform.position = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), 0);
	}
	
	void Save(){
		PlayerPrefs.SetFloat("X", transform.position.x);
		PlayerPrefs.SetFloat("Y", transform.position.y);
	}
	
	void LocationUpdate(){
		if (Input.GetKey(KeyCode.Space)){
			if (location == "Spaniae"){
				SceneManager.LoadScene(1);
			}
			if (location == "Italia Annonaria"){
				SceneManager.LoadScene(2);
			}
			if (location == "Italia Suburbicaria"){
				SceneManager.LoadScene(3);
			}
			if (location == "Illyricum"){
				SceneManager.LoadScene(4);
			}
			if (location == "Dacia"){
				SceneManager.LoadScene(5);
			}
			if (location == "Macedonia"){
				SceneManager.LoadScene(6);
			}
			if (location == "Quaestura Exercitus"){
				SceneManager.LoadScene(7);
			}
			if (location == "Thracia"){
				SceneManager.LoadScene(8);
			}
			if (location == "Pontica"){
				SceneManager.LoadScene(9);
			}
			if (location == "Asiana"){
				SceneManager.LoadScene(10);
			}
			if (location == "Oriens"){
				SceneManager.LoadScene(11);
			}
			if (location == "Aegyptus"){
				SceneManager.LoadScene(12);
			}
			if (location == "Africa"){
				SceneManager.LoadScene(13);
			}
			if (location == "Dara"){
				SceneManager.LoadScene(14);
			}
			if (location == "Taginae"){
				SceneManager.LoadScene(15);
			}
		}
	}
}