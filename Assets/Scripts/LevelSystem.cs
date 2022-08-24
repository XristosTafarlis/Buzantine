using UnityEngine;
using UnityEngine.UI;

//Main map script

public class LevelSystem : MonoBehaviour{
	[Header("Variables")]
	public static int level;
	[HideInInspector] public int currentXp;
	[HideInInspector] public int requiredXp;

	float lerpTimer;
	float delayTimer;

	[Header("UI")]
	[SerializeField] Image frontXpBar;
	[SerializeField] Image backXpBar;

	public static int xpOnWin;

	void Start(){
		//PlayerPrefs.DeleteAll();							//Removes the level
		PlayerPrefChecker();
		CalculateRequiredXp();
		SetXpFillAmount();
		GainExperienceFlatRate(xpOnWin);
	}

	void Update(){
		//if(Input.GetKeyDown(KeyCode.F)){
		//	GainExperienceFlatRate(50);
		//}
		UpdateXpUI();
	}

	void SetXpFillAmount(){
		frontXpBar.fillAmount = currentXp / requiredXp;
		backXpBar.fillAmount = currentXp / requiredXp;
	}

	void PlayerPrefChecker(){
		if(PlayerPrefs.HasKey("xp") == true){
			currentXp = PlayerPrefs.GetInt("xp");
		}else{
			currentXp = 0;
		}
		if(PlayerPrefs.HasKey("lvl") == true){
			level = PlayerPrefs.GetInt("lvl");
		}
		else{
			level = 1;
		}
	}

	public void UpdateXpUI(){
		float xpFraction = (float)currentXp / (float)requiredXp;
		float FXP = frontXpBar.fillAmount;

		if(level < 10){
			if(FXP < xpFraction){
				delayTimer += Time.deltaTime;
				backXpBar.fillAmount = xpFraction;
				if(delayTimer > 0.5){
					lerpTimer += Time.deltaTime;
					float percentComplete = lerpTimer / 50;
					frontXpBar.fillAmount = Mathf.Lerp(FXP, backXpBar.fillAmount, percentComplete);
				}
			}
		}else{
			frontXpBar.fillAmount = 1;
		}
	}

	public void GainExperienceFlatRate(int xpGained){
		currentXp += xpGained;
		xpOnWin = 0;
		lerpTimer = 0f;
		delayTimer = 0f;
		PlayerPrefs.SetInt("xp", currentXp);
		if(currentXp >= requiredXp){
			LevelUp();
		}
	}

	void LevelUp(){
		level++;
		frontXpBar.fillAmount = 0f;
		backXpBar.fillAmount = 0f;
		currentXp = Mathf.RoundToInt(currentXp - requiredXp);
		CalculateRequiredXp();

		PlayerPrefs.SetInt("lvl", level);
		PlayerPrefs.SetInt("xp", currentXp);
	}

	void CalculateRequiredXp(){
		if(level == 1)		requiredXp = 25;
		else if(level == 2) requiredXp = 51;
		else if(level == 3) requiredXp = 73;
		else if(level == 4) requiredXp = 104;
		else if(level == 5) requiredXp = 131;
		else if(level == 6) requiredXp = 160;
		else if(level == 7) requiredXp = 189;
		else if(level == 8) requiredXp = 218;
		else if(level == 9) requiredXp = 249;
		else				requiredXp = 267;
	}
}