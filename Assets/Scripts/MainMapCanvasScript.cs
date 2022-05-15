using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMapCanvasScript : MonoBehaviour{
	
	[Header("Refferences")]
	[SerializeField] GameObject playerRefference;
	[SerializeField] Text xpText;
	[SerializeField] Text levelText;
	
	void Start(){
		
	}
	
	void Update(){
		if(LevelSystem.level < 10){
			levelText.text = "Level " + LevelSystem.level;
		}else{
			levelText.text = "Level Max";
		}
		if(LevelSystem.level < 10){
			xpText.text = playerRefference.GetComponent<LevelSystem>().currentXp + " of " + playerRefference.GetComponent<LevelSystem>().requiredXp;
		}else{
			xpText.text = "Max";
		}
	}
}
