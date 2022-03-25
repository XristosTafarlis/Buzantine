//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour{       //bow mouse follow and shot when click

    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;

	public float fireRate;
	private float nextFire = 0f;
	
    void Update(){
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.right = direction;

        if (Input.GetMouseButtonDown(0) && Time.time >= nextFire){
			nextFire = Time.time + 1f/fireRate; 
            Shoot();
        }
    }

    void Shoot() {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }
}