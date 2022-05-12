using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour{
	
	[Header("References")]
	public GameObject thisGameObject;
	
	[Header("Variables")]
	public int level;
	public float currentXp;
	public float requiredXp;
	
	private float lerpTimer;
	private float delayTimer;
	
	[Header("UI")]
	public Image frontXpBar;
	public Image backXpBar;
	
	public static float xpOnWin;
	
	void Start(){
		frontXpBar.fillAmount = currentXp / requiredXp;
		backXpBar.fillAmount = currentXp / requiredXp;
		
		currentXp = PlayerPrefs.GetFloat("xp");
		level = PlayerPrefs.GetInt("lvl");
		
		requiredXp = CalculateRequiredXp();
	}
	
	void Update(){
		UpdateXpUI();
		if(Input.GetKeyDown(KeyCode.K)){
			GainExperienceFlatRate(20);
		}
		if(currentXp >= requiredXp){
			LevelUp();
		}
		
		if (xpOnWin > 10){
			GainExperienceFlatRate(xpOnWin);
		}
		
		PlayerPrefs.SetFloat("xp", currentXp);
		PlayerPrefs.SetInt("lvl", level);
	}
	
	public void UpdateXpUI(){
		float xpFraction = currentXp / requiredXp;
		float FXP = frontXpBar.fillAmount;
		
		if(FXP < xpFraction){
			delayTimer += Time.deltaTime;
			backXpBar.fillAmount = xpFraction;
			if(delayTimer > 1){
				lerpTimer += Time.deltaTime;
				float percentComplete = lerpTimer / 100;
				frontXpBar.fillAmount = Mathf.Lerp(FXP, backXpBar.fillAmount, percentComplete);
			}
		}
	}
	
	public void GainExperienceFlatRate(float xpGained){
		currentXp += xpGained;
		lerpTimer = 0f;
		delayTimer = 0f;
		xpOnWin = 0;
	}
	
	void LevelUp(){
		level++;
		frontXpBar.fillAmount = 0f;
		backXpBar.fillAmount = 0f;
		currentXp = Mathf.RoundToInt(currentXp - requiredXp);
		requiredXp = CalculateRequiredXp();
		
		GetComponent<PlayerAttributes>().IncreaseHealth(level);
		GetComponent<PlayerAttributes>().IncreaseFireRate(level);
		//Chage health and fire rate
	}
	
	int CalculateRequiredXp(){
		int solveForRequiredXp = 0;
		for (int levelCycle = 1; levelCycle <= level; levelCycle++){
			solveForRequiredXp += (int)( 100 + Mathf.Pow(level, 1.1f));
		}
		return solveForRequiredXp / 4;
	}
}