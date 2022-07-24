using UnityEngine;

public class BannerScript : MonoBehaviour{
	bool flag = false;
	void Update(){
		
		Debug.Log(transform.rotation.x);
		if(transform.rotation.x < 0.05 && flag == false){
			transform.Rotate (5f * Time.deltaTime, 5f * Time.deltaTime, 5f * Time.deltaTime);
		}else{
			flag = true;
			transform.Rotate (-5f * Time.deltaTime, -5f * Time.deltaTime, -5f * Time.deltaTime);
		}
		if (transform.rotation.x < -0.05){
			flag = false;
		}
	}
}
