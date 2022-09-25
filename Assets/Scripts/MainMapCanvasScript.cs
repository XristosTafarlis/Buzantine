using UnityEngine;
using UnityEngine.UI;

public class MainMapCanvasScript : MonoBehaviour {
	
	[ Header ( "Refferences" ) ]
	[ SerializeField ] private LevelSystem GameManagerObj;
	[ Space ( 10 ) ]
	
	[ SerializeField ] private Text xpText;
	[ SerializeField ] private Text levelText;
	[ SerializeField ] private Text lifeText;
	[ SerializeField ] private Text fireRateText;
	[ Space ( 10 ) ]
	
	[ SerializeField ] private Text joinFrontRateText;
	
	[ Header ( "Images" ) ]
	[ SerializeField ] private GameObject sassanids;
	[ SerializeField ] private GameObject ostrogoths;
	[ SerializeField ] private GameObject sassanidsPositions;
	[ SerializeField ] private GameObject ostrogothsPositions;
	
	[ Header ( "Sounds" ) ]
	[ SerializeField ] private AudioClip image;
	
	public static bool hasWonSassanids;
	public static bool hasWonOstrogoths;
	
	public static bool hasWonSpaniae;
	public static bool hasWonItaliaAnnonaria;
	public static bool hasWonItaliaSuburbicaria;
	public static bool hasWonIllyricum;
	public static bool hasWonDacia;
	public static bool hasWonMacedonia;
	public static bool hasWonQuaesturaExercitus;
	public static bool hasWonThracia;
	public static bool hasWonAsiana;
	public static bool hasWonPontica;
	public static bool hasWonOriens;
	public static bool hasWonAegyptus;
	public static bool hasWonAfrica;
	
	private void Start ( ) {
		SetPlayerPrefs ( );
	}
	
	private void Update ( ) {
		LevelText ( );
		XPText ( );
		LifeText ( );
		FireRateText ( );
		JoinFrontRateText ( );
		ShowBattles ( );
	}
	
	private void SetPlayerPrefs ( ) {
		hasWonSpaniae = ( PlayerPrefs.GetInt ( "hasWonSpaniae" ) != 0 );
		hasWonItaliaAnnonaria = ( PlayerPrefs.GetInt ( "hasWonItaliaAnnonaria" ) != 0 );
		hasWonItaliaSuburbicaria = ( PlayerPrefs.GetInt ( "hasWonItaliaSuburbicaria" ) != 0 );
		hasWonIllyricum = ( PlayerPrefs.GetInt ( "hasWonIllyricum" ) != 0 );
		hasWonDacia = ( PlayerPrefs.GetInt ( "hasWonDacia" ) != 0 );
		hasWonMacedonia = ( PlayerPrefs.GetInt ( "hasWonMacedonia" ) != 0 );
		hasWonThracia = ( PlayerPrefs.GetInt ( "hasWonThracia" ) != 0 );
		hasWonQuaesturaExercitus = ( PlayerPrefs.GetInt ( "hasWonQuaesturaExercitus" ) != 0 );
		hasWonPontica = ( PlayerPrefs.GetInt ( "hasWonPontica" ) != 0 );
		hasWonAsiana = ( PlayerPrefs.GetInt ( "hasWonAsiana" ) != 0 );
		hasWonAegyptus = ( PlayerPrefs.GetInt ( "hasWonAegyptus" ) != 0 );
		hasWonAfrica = ( PlayerPrefs.GetInt ( "hasWonAfrica" ) != 0 );
		hasWonOstrogoths = ( PlayerPrefs.GetInt ( "hasWonOstrogoths" ) != 0 );
		hasWonSassanids = ( PlayerPrefs.GetInt ( "hasWonSassanids" ) != 0 );
	}
	
	private void LevelText ( ) {
		if ( LevelSystem.level < 10 ) {
			levelText.text = "Level " + LevelSystem.level;
		}
		else {
			levelText.text = "Level 10 (Max)";
		}
	}
	
	private void XPText ( ) {
		if ( LevelSystem.level < 10 ) {
			xpText.text = GameManagerObj.currentXp + " of " + GameManagerObj.requiredXp;
		}
		else {
			xpText.text = "Max XP";
		}
	}
	
	private void ShowBattles ( ) {
		if ( hasWonOstrogoths ) {
			ostrogoths.SetActive ( true );
		}
		if ( hasWonSassanids ) {
			sassanids.SetActive ( true );
		}
	}
	
	public void ShowSassanidsPositions ( ) {
		sassanidsPositions.SetActive( true );
		if( !GetComponent<AudioSource>( ).isPlaying ) {
			GetComponent<AudioSource>( ).PlayOneShot( image );
		}
	}
	
	public void HideSassanidsPositions( ){
		sassanidsPositions.SetActive( false );
	}
	
	public void ShowOstrogothsPositions( ){
		ostrogothsPositions.SetActive( true );
		if( !GetComponent<AudioSource>( ).isPlaying ) {
			GetComponent<AudioSource>( ).PlayOneShot( image );
		}
	}
	
	public void hideOstrogothsPositions(){
		ostrogothsPositions.SetActive( false );
	}
	
	private void LifeText ( ) {
		if ( LevelSystem.level == 1 ) {
			lifeText.text = "Life : 100";
		}
		else if ( LevelSystem.level == 2 ) {
			lifeText.text = "Life : 110";
		}
		else if ( LevelSystem.level == 3 ) {
			lifeText.text = "Life : 120";
		}
		else if ( LevelSystem.level == 4 ) {
			lifeText.text = "Life : 130";
		}
		else if ( LevelSystem.level == 5 ) {
			lifeText.text = "Life : 150";
		}
		else if ( LevelSystem.level == 6 ) {
			lifeText.text = "Life : 180";
		}
		else if ( LevelSystem.level == 7 ) {
			lifeText.text = "Life : 230";
		}
		else if ( LevelSystem.level == 8 ) {
			lifeText.text = "Life : 310";
		}
		else if ( LevelSystem.level == 9 ) {
			lifeText.text = "Life : 440";
		}
		else if ( LevelSystem.level >= 10 ) {
			lifeText.text = "Life : 650 (Max)";
		}
	}
	
	private void FireRateText ( ) {
		if ( LevelSystem.level == 1 ) {
			fireRateText.text = "1 arrow per second";
		}
		else if ( LevelSystem.level == 2 ) {
			fireRateText.text = "1.05 arrows per second";
		}
		else if ( LevelSystem.level == 3 ) {
			fireRateText.text = "1.1 arrows per second";
		}
		else if ( LevelSystem.level == 4 ) {
			fireRateText.text = "1.2 arrows per second";
		}
		else if ( LevelSystem.level == 5 ) {
			fireRateText.text = "1.25 arrows per second";
		}
		else if ( LevelSystem.level == 6 ) {
			fireRateText.text = "1.35 arrows per second";
		}
		else if ( LevelSystem.level == 7 ) {
			fireRateText.text = "1.5 arrows per second";
		}
		else if ( LevelSystem.level == 8 ) {
			fireRateText.text = "1.8 arrows per second";
		}
		else if ( LevelSystem.level == 9 ) {
			fireRateText.text = "2 arrows per second";
		}
		else if ( LevelSystem.level >= 10 ) {
			fireRateText.text = "3.5 arrows per second (Max)";
		}
	}
	
	private void JoinFrontRateText ( ) {
		if ( PlayerMovement.location == null ) {
			joinFrontRateText.text = " ";
			joinFrontRateText.color = Color.white;
		}
		else if ( PlayerMovement.location == "Macedonia" ) {
			if ( hasWonMacedonia == true) {
				joinFrontRateText.text = "Already won Macedonia";
				joinFrontRateText.color = Color.green;
			}
			else {
				joinFrontRateText.text = "Press Space to join Macedonia";
				joinFrontRateText.color = Color.white;
			}
		}
		else if ( PlayerMovement.location == "Thracia" ) {
			if ( hasWonThracia == true ) {
				joinFrontRateText.text = "Already won Thracia";
				joinFrontRateText.color = Color.green;
			}
			else {
				joinFrontRateText.text = "Press Space to join Thracia";
				joinFrontRateText.color = Color.white;
			}
		}
		else if ( PlayerMovement.location == "Dacia" ) {
			if ( hasWonDacia == true ) {
				joinFrontRateText.text = "Already won Dacia";
				joinFrontRateText.color = Color.green;
			}
			else {
				joinFrontRateText.text = "Press Space to join Dacia";
				joinFrontRateText.color = Color.white;
			}
		}
		else if ( PlayerMovement.location == "Quaestura Exercitus" ) {
			if ( hasWonQuaesturaExercitus == true ) {
				joinFrontRateText.text = "Already won Quaestura Exercitus";
				joinFrontRateText.color = Color.green;
			}
			else {
				joinFrontRateText.text = "Press Space to join Quaestura Exercitus";
				joinFrontRateText.color = Color.white;
			}
		}
		else if ( PlayerMovement.location == "Illyricum" ) {
			if ( hasWonIllyricum == true ) {
				joinFrontRateText.text = "Already won Illyricum";
				joinFrontRateText.color = Color.green;
			}
			else {
				joinFrontRateText.text = "Press Space to join Illyricum";
				joinFrontRateText.color = Color.white;
			}
		}
		else if ( PlayerMovement.location == "Italia Annonaria" ) {
			if ( hasWonItaliaAnnonaria == true ) {
				joinFrontRateText.text = "Already won Italia Annonaria";
				joinFrontRateText.color = Color.green;
			}
			else {
				joinFrontRateText.text = "Press Space to join Italia Annonaria";
				joinFrontRateText.color = Color.white;
			}
		}
		else if ( PlayerMovement.location == "Italia Suburbicaria" ) {
			if ( hasWonItaliaSuburbicaria == true ) {
				joinFrontRateText.text = "Already won Italia Suburbicaria";
				joinFrontRateText.color = Color.green;
			}
			else {
				joinFrontRateText.text = "Press Space to join Italia Suburbicaria";
				joinFrontRateText.color = Color.white;
			}
		}
		else if ( PlayerMovement.location == "Pontica" ) {
			if ( hasWonPontica == true ) {
				joinFrontRateText.text = "Already won Pontica";
				joinFrontRateText.color = Color.green;
			}
			else {
				joinFrontRateText.text = "Press Space to join Pontica";
				joinFrontRateText.color = Color.white;
			}
		}
		else if ( PlayerMovement.location == "Asiana" ) {
			if ( hasWonAsiana == true ) {
				joinFrontRateText.text = "Already won Asiana";
				joinFrontRateText.color = Color.green;
			}
			else {
				joinFrontRateText.text = "Press Space to join Asiana";
				joinFrontRateText.color = Color.white;
			}
		}
		else if ( PlayerMovement.location == "Oriens" ) {
			if( hasWonOriens == true ) {
				joinFrontRateText.text = "Already won Oriens";
				joinFrontRateText.color = Color.green;
			}
			else {
				joinFrontRateText.text = "Press Space to join Oriens";
				joinFrontRateText.color = Color.white;
			}
		}
		else if ( PlayerMovement.location == "Aegyptus" ) {
			if ( hasWonAegyptus == true ) {
				joinFrontRateText.text = "Already won Aegyptus";
				joinFrontRateText.color = Color.green;
			}
			else {
				joinFrontRateText.text = "Press Space to join Aegyptus";
				joinFrontRateText.color = Color.white;
			}
		}
		else if ( PlayerMovement.location == "Africa" ) {
			if ( hasWonAfrica == true ) {
				joinFrontRateText.text = "Already won Africa";
				joinFrontRateText.color = Color.green;
			}
			else {
				joinFrontRateText.text = "Press Space to join Africa";
				joinFrontRateText.color = Color.white;
			}
		}
		else if ( PlayerMovement.location == "Spaniae" ) {
			if ( hasWonSpaniae == true ) {
				joinFrontRateText.text = "Already won Spaniae";
				joinFrontRateText.color = Color.green;
			}
			else {
				joinFrontRateText.text = "Press Space to join Spaniae";
				joinFrontRateText.color = Color.white;
			}
		}
		else if ( PlayerMovement.location == "Dara" ) {
			if ( hasWonSassanids == true ) {
				joinFrontRateText.text = "Already won Battle of Dara";
				joinFrontRateText.color = Color.green;
			}
			else {
				joinFrontRateText.text = "Press Space to join the Battle of Dara";
				joinFrontRateText.color = Color.red;
			}
		}
		else if ( PlayerMovement.location == "Taginae" ) {
			if ( hasWonOstrogoths == true ) {
				joinFrontRateText.text = "Already won Battle of Taginae";
				joinFrontRateText.color = Color.green;
			}
			else {
				joinFrontRateText.text = "Press Space to join the Battle of Taginae";
				joinFrontRateText.color = Color.red;
			}
		}
	}
}