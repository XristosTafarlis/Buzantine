using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMapCanvasScript : MonoBehaviour{
	
	[Header("Refferences")]
	[SerializeField] GameObject playerRefference;
	[SerializeField] Text xpText;
	[SerializeField] Text levelText;
	[SerializeField] Text lifeText;
	[SerializeField] Text fireRateText;
	[Space(20)]
	[SerializeField] Text joinFrontRateText;
	
	void Start(){
		
	}
	
	void Update(){
		LevelText();
		XPText();
		LifeText();
		FireRateText();
		JoinFrontRateText();
	}
	
	void LevelText(){
		if(LevelSystem.level < 10){
			levelText.text = "Level " + LevelSystem.level;
		}else{
			levelText.text = "Level 10 (Max)";
		}
	}
	
	void XPText(){
		if(LevelSystem.level < 10){
			xpText.text = playerRefference.GetComponent<LevelSystem>().currentXp + " of " + playerRefference.GetComponent<LevelSystem>().requiredXp;
		}else{
			xpText.text = "Max XP";
		}
	}
	
	void LifeText(){
		if(LevelSystem.level == 1){
			lifeText.text = "Life : 100";
		}else if(LevelSystem.level == 2){
			lifeText.text = "Life : 110";
		}else if(LevelSystem.level == 3){
			lifeText.text = "Life : 120";
		}else if(LevelSystem.level == 4){
			lifeText.text = "Life : 130";
		}else if(LevelSystem.level == 5){
			lifeText.text = "Life : 150";
		}else if(LevelSystem.level == 6){
			lifeText.text = "Life : 180";
		}else if(LevelSystem.level == 7){
			lifeText.text = "Life : 230";
		}else if(LevelSystem.level == 8){
			lifeText.text = "Life : 310";
		}else if(LevelSystem.level == 9){
			lifeText.text = "Life : 440";
		}else if(LevelSystem.level >= 10){
			lifeText.text = "Life : 650 (Max)";
		}
	}
	
	void FireRateText(){
		if(LevelSystem.level == 1){
			fireRateText.text = "1 arrow per second";
		}else if(LevelSystem.level == 2){
			fireRateText.text = "1.1 arrows per second";
		}else if(LevelSystem.level == 3){
			fireRateText.text = "1.2 arrows per second";
		}else if(LevelSystem.level == 4){
			fireRateText.text = "1.3 arrows per second";
		}else if(LevelSystem.level == 5){
			fireRateText.text = "1.5 arrow per second";
		}else if(LevelSystem.level == 6){
			fireRateText.text = "1.8 arrows per second";
		}else if(LevelSystem.level == 7){
			fireRateText.text = "2.3 arrows per second";
		}else if(LevelSystem.level == 8){
			fireRateText.text = "3.1 arrows per second";
		}else if(LevelSystem.level == 9){
			fireRateText.text = "4.4 arrows per second";
		}else if(LevelSystem.level >= 10){
			fireRateText.text = "6.5 arrows per second (Max)";
		}
	}
	
	void JoinFrontRateText(){
		if(PlayerMovement.location == null)								joinFrontRateText.text = " ";
			else if(PlayerMovement.location == "Macedonia")				joinFrontRateText.text = "Press Space to joint Macedonia";
			else if(PlayerMovement.location == "Thracia")				joinFrontRateText.text = "Press Space to joint Thracia";
			else if(PlayerMovement.location == "Dacia")					joinFrontRateText.text = "Press Space to joint Dacia";
			else if(PlayerMovement.location == "Quaestura Exercitus")	joinFrontRateText.text = "Press Space to joint Quaestura Exercitus";
			else if(PlayerMovement.location == "Illyricum")				joinFrontRateText.text = "Press Space to joint Illyricum";
			else if(PlayerMovement.location == "Italia Annonaria")		joinFrontRateText.text = "Press Space to joint Italia Annonaria";
			else if(PlayerMovement.location == "Italia Suburbicaria")	joinFrontRateText.text = "Press Space to joint Italia Suburbicaria";
			else if(PlayerMovement.location == "Pontica")				joinFrontRateText.text = "Press Space to joint Pontica";
			else if(PlayerMovement.location == "Asiana")				joinFrontRateText.text = "Press Space to joint Asiana";
			else if(PlayerMovement.location == "Oriens")				joinFrontRateText.text = "Press Space to joint Oriens";
			else if(PlayerMovement.location == "Aegyptus")				joinFrontRateText.text = "Press Space to joint Aegyptus";
			else if(PlayerMovement.location == "Africa")				joinFrontRateText.text = "Press Space to joint Africa";
			else if(PlayerMovement.location == "Spaniae")				joinFrontRateText.text = "Press Space to joint Spaniae";
	}
}
