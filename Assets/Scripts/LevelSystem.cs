using UnityEngine;
using UnityEngine.UI;

//Main map script

public class LevelSystem : MonoBehaviour {
	[ Header ( "Variables" ) ]
	[ HideInInspector ] public int currentXp;
	[ HideInInspector ] public int requiredXp;
	public static int level;

	private float lerpTimer;
	private float delayTimer;

	[ Header ( "UI" ) ]
	[ SerializeField ] private Image frontXpBar;
	[ SerializeField ] private Image backXpBar;

	public static int xpOnWin;

	private void Start ( ) {
		PlayerPrefChecker ( );
		CalculateRequiredXp ( );
		SetXpFillAmount ( );
		GainExperienceFlatRate ( xpOnWin );
	}

	private void Update ( ) {
		if(Input.GetKeyDown(KeyCode.F)){
			GainExperienceFlatRate(50);
		}
		if(Input.GetKeyDown(KeyCode.R)){
			GainExperienceFlatRate(-50);
		}
		UpdateXpUI ( );
	}

	private void SetXpFillAmount ( ) {
		frontXpBar.fillAmount = currentXp / requiredXp;
		backXpBar.fillAmount = currentXp / requiredXp;
	}

	private void PlayerPrefChecker ( ) {
		if ( PlayerPrefs.HasKey ( "xp" ) == true ) {
			currentXp = PlayerPrefs.GetInt( "xp" );
		}
		else {
			currentXp = 0;
		}
		if ( PlayerPrefs.HasKey( "lvl" ) == true ) {
			level = PlayerPrefs.GetInt( "lvl" );
		}
		else {
			level = 1;
		}
	}

	public void UpdateXpUI ( ) {
		float xpFraction = ( float ) currentXp / ( float ) requiredXp;
		float FXP = frontXpBar.fillAmount;

		if ( level < 10 ) {
			if ( FXP < xpFraction ) {
				delayTimer = delayTimer + Time.deltaTime;
				backXpBar.fillAmount = xpFraction;
				if ( delayTimer > 0.5 )
				{
					lerpTimer = lerpTimer + Time.deltaTime;
					float percentComplete = lerpTimer / 50;
					frontXpBar.fillAmount = Mathf.Lerp ( FXP, backXpBar.fillAmount, percentComplete );
				}
			}
		}
		else {
			frontXpBar.fillAmount = 1;
		}
	}

	public void GainExperienceFlatRate ( int xpGained ) {
		currentXp = currentXp + xpGained;
		xpOnWin = 0;
		lerpTimer = 0f;
		delayTimer = 0f;
		PlayerPrefs.SetInt ( "xp", currentXp );
		if ( currentXp >= requiredXp ) {
			LevelUp ( );
		}
	}

	private void LevelUp ( ) {
		level++;
		frontXpBar.fillAmount = 0f;
		backXpBar.fillAmount = 0f;
		currentXp = Mathf.RoundToInt ( currentXp - requiredXp );
		CalculateRequiredXp ( );

		PlayerPrefs.SetInt ( "lvl", level );
		PlayerPrefs.SetInt ( "xp", currentXp );
	}

	private void CalculateRequiredXp ( ) {
		if ( level == 1 ) {
			requiredXp = 25;
		}
		else if ( level == 2 ) {
			requiredXp = 51;
		}
		else if ( level == 3 ) {
			requiredXp = 73;
		}
		else if ( level == 4 ) {
			requiredXp = 104;
		}
		else if ( level == 5 ) {
			requiredXp = 131;
		}
		else if ( level == 6 ) {
			requiredXp = 160;
		}
		else if ( level == 7 ) {
			requiredXp = 189;
		}
		else if ( level == 8 ) {
			requiredXp = 218;
		}
		else if ( level == 9 ) {
			requiredXp = 249;
		}
		else {
			requiredXp = 267;
		}
	}
}