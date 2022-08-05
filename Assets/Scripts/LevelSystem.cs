using UnityEngine;
using UnityEngine.UI;

//Main map script

public class LevelSystem : MonoBehaviour{
	[Header("Variables")]
	public static int level;
	public float currentXp;
	public float requiredXp;

	private float lerpTimer;
	private float delayTimer;

	[Header("UI")]
	[SerializeField] Image frontXpBar;
	[SerializeField] Image backXpBar;

	public static float xpOnWin;

	void Start(){
		//PlayerPrefs.DeleteAll();							//Removes the level
		frontXpBar.fillAmount = currentXp / requiredXp;
		backXpBar.fillAmount = currentXp / requiredXp;

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

		requiredXp = CalculateRequiredXp();

		if (xpOnWin > 10){
			GainExperienceFlatRate(xpOnWin);
		}

		if(currentXp >= requiredXp){
			LevelUp();
		}
		xpOnWin = 0;
	}

	void Update(){
		UpdateXpUI();
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
		lerpTimer = 0f;
		delayTimer = 0f;
		xpOnWin = 0;
		PlayerPrefs.SetFloat("xp", currentXp);
	}

	void LevelUp(){
		level++;
		frontXpBar.fillAmount = 0f;
		backXpBar.fillAmount = 0f;
		currentXp = Mathf.RoundToInt(currentXp - requiredXp);
		requiredXp = CalculateRequiredXp();

		PlayerPrefs.SetInt("lvl", level);

		//GetComponent<PlayerAttributes>().IncreaseHealth(level);
		//GetComponent<PlayerAttributes>().IncreaseFireRate(level);
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