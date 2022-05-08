//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour{
	[Header("Refferences")]
	[SerializeField] Transform target;
	[SerializeField] Rigidbody2D rb;
	
	[Header("Variables")]
	[Range(1 , 50)]
	[SerializeField] float smoothing;
	[Tooltip("Bottom left")]
	[SerializeField] Vector2 minPos;
	[Space(15)]
	[Tooltip("Top right")]
	[SerializeField] Vector2 maxPos;

	private void FixedUpdate(){
		if(transform.position != target.position){
			Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
			
			targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
			targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
			
			
			transform.position = Vector3.Lerp(transform.position, targetPos, smoothing / 100);
		}
	}
}