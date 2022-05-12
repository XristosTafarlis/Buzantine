using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour{
	public static int health;
	public static float fireRate;
	
	void Start(){
		IncreaseFireRate(1);
		IncreaseHealth(1);
		health = 100;
	}
	
	void Update(){
		Debug.Log(fireRate);
	}
	
	public void IncreaseFireRate(int level){
		if(level == 1) fireRate = 1f;
		if(level == 2) fireRate = 1.1f;
		if(level == 3) fireRate = 1.2f;
		if(level == 4) fireRate = 1.3f;
		if(level == 5) fireRate = 1.5f;
		if(level == 6) fireRate = 1.8f;
		if(level == 7) fireRate = 2.3f;
		if(level == 8) fireRate = 3.1f;
		if(level == 9) fireRate = 4.4f;
		if(level == 10) fireRate = 6.5f;
	}
	
	public void IncreaseHealth(int level){
		health += (int) ((health * 0.01f) * ((100 - level) * 0.1f));
	}
}