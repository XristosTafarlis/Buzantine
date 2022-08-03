using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// In-game script

public class PlayerScript : MonoBehaviour{
	[Header("References")]
	[SerializeField] Image healthBar;
	[SerializeField] GameObject bow;

	[Header("Variables")]
	public int damage = 5;
	public int life;
	int maxLife;
	GameObject[] enemys;

	void Start(){
		SetPlayerLife();
		maxLife = life;
	}

	void Update(){
		Death();
		GameFinished();
		HealthRender();
	}

	void HealthRender(){
		if(healthBar != null)
			healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (float)life / maxLife, 0.05f);
	}

	void SetPlayerLife(){
		if(LevelSystem.level == 1){
			life = 100;
		}else if(LevelSystem.level == 2){
			life = 110;
		}else if(LevelSystem.level == 3){
			life = 120;
		}else if(LevelSystem.level == 4){
			life = 130;
		}else if(LevelSystem.level == 5){
			life = 150;
		}else if(LevelSystem.level == 6){
			life = 180;
		}else if(LevelSystem.level == 7){
			life = 230;
		}else if(LevelSystem.level == 8){
			life = 310;
		}else if(LevelSystem.level == 9){
			life = 440;
		}else if(LevelSystem.level >= 10){
			life = 650;
		}
	}

	public void TakeDamage(int dmg){
		life -= dmg;
	}

	void GameFinished(){
		if(WaveSpawner.wavesFinished == true){
			WaveSpawner.wavesFinished = false;
			XpWon();
			Invoke("MainMenu", 1f);
		}
	}

	void XpWon(){
		if(SceneManager.GetActiveScene().name == "Spaniae"){
			LevelSystem.xpOnWin = 20;
		}else if(SceneManager.GetActiveScene().name == "Italia Annonaria"){
			LevelSystem.xpOnWin = 25;
		}else if(SceneManager.GetActiveScene().name == "Italia Suburbicaria"){
			LevelSystem.xpOnWin = 30;
		}else if(SceneManager.GetActiveScene().name == "Illyricum"){
			LevelSystem.xpOnWin = 35;
		}else if(SceneManager.GetActiveScene().name == "Dacia"){
			LevelSystem.xpOnWin = 40;
		}else if(SceneManager.GetActiveScene().name == "Macedonia"){
			LevelSystem.xpOnWin = 45;
		}else if(SceneManager.GetActiveScene().name == "Thracia"){
			LevelSystem.xpOnWin = 50;
		}else if(SceneManager.GetActiveScene().name == "Quaestura Exercitus"){
			LevelSystem.xpOnWin = 55;
		}else if(SceneManager.GetActiveScene().name == "Pontica"){
			LevelSystem.xpOnWin = 60;
		}else if(SceneManager.GetActiveScene().name == "Asiana"){
			LevelSystem.xpOnWin = 65;
		}else if(SceneManager.GetActiveScene().name == "Oriens"){
			LevelSystem.xpOnWin = 70;
		}else if(SceneManager.GetActiveScene().name == "Aegyptus"){
			LevelSystem.xpOnWin = 75;
		}else if(SceneManager.GetActiveScene().name == "Africa"){
			LevelSystem.xpOnWin = 80;
		}else if(SceneManager.GetActiveScene().name == "Dara"){
			MainMapCanvasScript.hasWonSassanids = true;
			LevelSystem.xpOnWin = 110;
		}else if(SceneManager.GetActiveScene().name == "Taginae"){
			MainMapCanvasScript.hasWonOstrogoths = true;
			LevelSystem.xpOnWin = 100;
		}
	}

	void MainMenu(){
		SceneManager.LoadScene(0);
	}

	void Death(){
		if(life <= 0){
			bow.GetComponent<Bow>().enabled = false;
			enemys = GameObject.FindGameObjectsWithTag("Enemy");
			//Freeze enemies
			foreach(GameObject _enemy in enemys){
				_enemy.GetComponent<Animator>().SetBool("EnemyIsStill", true);
				_enemy.GetComponent<Animator>().SetBool("EnemyAttacks", false);
				_enemy.GetComponent<Enemy>().enabled = false;
			}
			Invoke("MainMenu", 2f);
		}
	}
}