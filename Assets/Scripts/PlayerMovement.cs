//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private string Location = null;

    Vector2 movement;
    
    void Update(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space)){
            if (Location == "Macedonia")
                SceneManager.LoadScene(1);
        }

    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Macedonia")
            Location = "Macedonia";
        else if(other.name == "Thracia")
            Location ="Thracia";
        else if(other.name == "Dacia")
            Location = "Dacia";
        else if(other.name == "Quaestura Exercitus")
            Location = "Quaestura Exercitus";
        else if(other.name == "Illyricum")
            Location = "Illyricum";
        else if(other.name == "Italia Annonaria")
            Location = "Italia Annonaria";
        else if(other.name == "Italia Suburbicaria")
            Location = "Italia Suburbicaria";
        else if(other.name == "Pontica")
            Location = "Pontica";
        else if(other.name == "Asiana")
            Location = "Asiana";
        else if(other.name == "Oriens")
            Location = "Oriens";
        else if(other.name == "Aegyptus")
            Location = "Aegyptus";
        else if(other.name == "Africa")
            Location = "Africa";
        else if(other.name == "Spaniae")
            Location = "Spaniae";
    }
}