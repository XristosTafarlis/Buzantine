//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour{
	[Header("Refferences")]
	[SerializeField] Transform target;
	
	[Header("Variables")]
	[Range(1 , 50)]
	[SerializeField] float smoothing;
	[SerializeField] Vector2 minPos;
	[SerializeField] Vector2 maxPos;
	
	private void FixedUpdate(){
		if(transform.position != target.position){
			Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
			
			targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.y);
			targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
			
			transform.position = Vector3.Lerp(transform.position, targetPos, smoothing / 100);
		}
	}
}