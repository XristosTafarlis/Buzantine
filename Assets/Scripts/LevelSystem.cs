using UnityEngine;
using UnityEngine.UI;

//Main map script

public class LevelSystem : MonoBehaviour{
	[Header("Variables")]
	public static int level;
	[HideInInspector] public float currentXp;
	[HideInInspector] public float requiredXp;

	float lerpTimer;
	float delayTimer;

	[Header("UI")]
	[SerializeField] Image frontXpBar;
	[SerializeField] Image backXpBar;

	public static float xpOnWin;

	void Start(){
		//PlayerPrefs.DeleteAll();							//Removes the level
		PlayerPrefChecker();
		CalculateRequiredXp();
		SetXpFillAmount();
		GainExperienceFlatRate(xpOnWin);
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.F)){
			GainExperienceFlatRate(5f);
		}
		UpdateXpUI();
	}

	void SetXpFillAmount(){
		frontXpBar.fillAmount = currentXp / requiredXp;
		backXpBar.fillAmount = currentXp / requiredXp;
	}

	void PlayerPrefChecker(){
		if(PlayerPrefs.HasKey("xp") == true){
			currentXp = PlayerPrefs.GetFloat("xp");
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
		float xpFraction = currentXp / requiredXp;
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

	public void GainExperienceFlatRate(float xpGained){
		currentXp += xpGained;
		xpOnWin = 0;
		lerpTimer = 0f;
		delayTimer = 0f;
		PlayerPrefs.SetFloat("xp", currentXp);
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
	}

	void CalculateRequiredXp(){
		if(level == 1)		requiredXp = 25f;
		else if(level == 2) requiredXp = 51f;
		else if(level == 3) requiredXp = 73f;
		else if(level == 4) requiredXp = 104f;
		else if(level == 5) requiredXp = 131f;
		else if(level == 6) requiredXp = 160f;
		else if(level == 7) requiredXp = 189f;
		else if(level == 8) requiredXp = 218f;
		else if(level == 9) requiredXp = 249f;
		else				requiredXp = 267f;
	}
}