using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// In-game script

public class PlayerScript : MonoBehaviour {
	[ Header ( "References" ) ]
	[ SerializeField ] private Image healthBar;
	[ SerializeField ] private GameObject rotationPoint;
	[ SerializeField ] private AudioSource audioSource;
	[ SerializeField ] private AudioClip [ ] playerPainSounds;
	[ Space ( 10 ) ]
	
	public bool wonTheGame;	//Used for text when level finishes
	public bool endTheGame;
	
	[Header("Variables")]
	public int damage = 5;
	public int life;
	private int maxLife;
	private GameObject [ ] enemys;
	
	private void Start ( ) {
		SetPlayerLife ( );
		maxLife = life;
	}
	
	private void Update ( ) {
		GameFinished ( );
		HealthRender ( );
		Death ( );
	}
	
	private void HealthRender ( ) {
		if ( healthBar != null ) {
			healthBar.fillAmount = Mathf.Lerp ( healthBar.fillAmount, ( float ) life / maxLife, 0.05f );
		}
	}
	
	private void SetPlayerLife ( ) {
		if ( LevelSystem.level == 1 ) {
			life = 100;
		}
		else if ( LevelSystem.level == 2 ) {
			life = 110;
		}
		else if ( LevelSystem.level == 3 ) {
			life = 120;
		}
		else if ( LevelSystem.level == 4 ) {
			life = 130;
		}
		else if ( LevelSystem.level == 5 ) {
			life = 150;
		}
		else if ( LevelSystem.level == 6 ) {
			life = 170;
		}
		else if ( LevelSystem.level == 7 ) {
			life = 200;
		}
		else if ( LevelSystem.level == 8 ) {
			life = 230;
		}
		else if ( LevelSystem.level == 9 ) {
			life = 270;
		}
		else if ( LevelSystem.level >= 10 ) {
			life = 310;
		}
	}

	public void TakeDamage ( int dmg ) {
		audioSource.PlayOneShot ( playerPainSounds [ Random.Range ( 0, playerPainSounds.Length ) ] );
		life = life - dmg;
	}

	private void GameFinished( ) {
		if ( WaveSpawner.wavesFinished == true) {
			WaveSpawner.wavesFinished = false;
			endTheGame = true;
			wonTheGame = true;
			XpWon ( );
			Invoke ( "MainMenu", 2f );
		}
	}

	private void XpWon ( ) {
		if ( SceneManager.GetActiveScene( ).name == "Spaniae" ) {
			LevelSystem.xpOnWin = 30;
			MainMapCanvasScript.hasWonSpaniae = true;
			PlayerPrefs.SetInt ( "hasWonSpaniae", ( MainMapCanvasScript.hasWonSpaniae ? 1 : 0 ) );
		}
		else if ( SceneManager.GetActiveScene( ).name == "Italia Annonaria" ) {
			LevelSystem.xpOnWin = 35;
			MainMapCanvasScript.hasWonItaliaAnnonaria = true;
			PlayerPrefs.SetInt ( "hasWonItaliaAnnonaria", ( MainMapCanvasScript.hasWonItaliaAnnonaria ? 1 : 0 ) );
		}
		else if ( SceneManager.GetActiveScene( ).name == "Italia Suburbicaria" ) {
			LevelSystem.xpOnWin = 42;
			MainMapCanvasScript.hasWonItaliaSuburbicaria = true;
			PlayerPrefs.SetInt ( "hasWonItaliaSuburbicaria", ( MainMapCanvasScript.hasWonItaliaSuburbicaria ? 1 : 0 ) );
		}
		else if ( SceneManager.GetActiveScene( ).name == "Illyricum" ) {
			LevelSystem.xpOnWin = 50;
			MainMapCanvasScript.hasWonIllyricum = true;
			PlayerPrefs.SetInt ( "hasWonIllyricum", ( MainMapCanvasScript.hasWonIllyricum ? 1 : 0 ) );
		}
		else if ( SceneManager.GetActiveScene( ).name == "Dacia" ) {
			LevelSystem.xpOnWin = 60;
			MainMapCanvasScript.hasWonDacia = true;
			PlayerPrefs.SetInt ( "hasWonDacia", ( MainMapCanvasScript.hasWonDacia ? 1 : 0 ) );
		}
		else if ( SceneManager.GetActiveScene( ).name == "Macedonia" ) {
			LevelSystem.xpOnWin = 75;
			MainMapCanvasScript.hasWonMacedonia = true;
			PlayerPrefs.SetInt ( "hasWonMacedonia", ( MainMapCanvasScript.hasWonMacedonia ? 1 : 0 ) );
		}
		else if ( SceneManager.GetActiveScene( ).name == "Thracia" ) {
			LevelSystem.xpOnWin = 92;
			MainMapCanvasScript.hasWonThracia = true;
			PlayerPrefs.SetInt ( "hasWonThracia", ( MainMapCanvasScript.hasWonThracia ? 1 : 0 ) );
		}
		else if ( SceneManager.GetActiveScene( ).name == "Quaestura Exercitus" ) {
			LevelSystem.xpOnWin = 90;
			MainMapCanvasScript.hasWonQuaesturaExercitus = true;
			PlayerPrefs.SetInt ( "hasWonQuaesturaExercitus", ( MainMapCanvasScript.hasWonQuaesturaExercitus ? 1 : 0 ) );
		}
		else if ( SceneManager.GetActiveScene( ).name == "Pontica" ) {
			LevelSystem.xpOnWin = 93;
			MainMapCanvasScript.hasWonPontica = true;
			PlayerPrefs.SetInt ( "hasWonPontica", ( MainMapCanvasScript.hasWonPontica ? 1 : 0 ) );
		}
		else if ( SceneManager.GetActiveScene( ).name == "Asiana" ) {
			LevelSystem.xpOnWin = 95;
			MainMapCanvasScript.hasWonAsiana = true;
			PlayerPrefs.SetInt ( "hasWonAsiana", ( MainMapCanvasScript.hasWonAsiana ? 1 : 0 ) );
		}
		else if ( SceneManager.GetActiveScene( ).name == "Oriens" ) {
			LevelSystem.xpOnWin = 100;
			MainMapCanvasScript.hasWonOriens = true;
			PlayerPrefs.SetInt ( "hasWonOriens", ( MainMapCanvasScript.hasWonOriens ? 1 : 0 ) );
		}
		else if ( SceneManager.GetActiveScene( ).name == "Aegyptus" ) {
			LevelSystem.xpOnWin = 110;
			MainMapCanvasScript.hasWonAegyptus = true;
			PlayerPrefs.SetInt ( "hasWonAegyptus", ( MainMapCanvasScript.hasWonAegyptus ? 1 : 0 ) );
		}
		else if ( SceneManager.GetActiveScene( ).name == "Africa" ) {
			LevelSystem.xpOnWin = 130;
			MainMapCanvasScript.hasWonAfrica = true;
			PlayerPrefs.SetInt ( "hasWonAfrica", ( MainMapCanvasScript.hasWonAfrica ? 1 : 0 ) );
		}
		else if ( SceneManager.GetActiveScene( ).name == "Taginae" ) {
			MainMapCanvasScript.hasWonOstrogoths = true;
			PlayerPrefs.SetInt ( "hasWonOstrogoths", ( MainMapCanvasScript.hasWonOstrogoths ? 1 : 0 ) );
			LevelSystem.xpOnWin = 80;
		}
		else if ( SceneManager.GetActiveScene( ).name == "Dara" ) {
			MainMapCanvasScript.hasWonSassanids = true;
			PlayerPrefs.SetInt ( "hasWonSassanids", ( MainMapCanvasScript.hasWonSassanids ? 1 : 0 ) );
			LevelSystem.xpOnWin = 118;
		}
	}

	private void MainMenu ( ) {
		SceneManager.LoadScene ( 0 );
	}

	private void Death ( ) {
		if ( life <= 0 ) {
			endTheGame = true;
			wonTheGame = false;

			rotationPoint.GetComponent<Bow>( ).enabled = false;

			enemys = GameObject.FindGameObjectsWithTag ( "Enemy" );
			foreach ( GameObject enemy in enemys ) {	//Freeze enemies
				enemy.GetComponent<Animator>( ).SetBool( "EnemyIsStill", true );
				enemy.GetComponent<Animator>( ).SetBool( "EnemyAttacks", false );
				enemy.GetComponent<Enemy>( ).enabled = false;
			}
			Invoke ( "MainMenu", 2f );
		}
	}
}