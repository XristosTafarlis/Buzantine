using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour{
	
	[Header("Variables")]
	public int damage = 5;
	int life;
	
	GameObject[] enemys;
	bool hasWon;
	
	void Start(){
		InvokeRepeating("HasWon", 20f, 1f);
		life = PlayerAttributes.health;
	}

	void Update(){
		Death();
		Debug.Log(life);
	}
	
	void HasWon(){
		if(WaveSpawner.wavesFinished == true){
			
			WaveSpawner.wavesFinished = false;
			hasWon = true;
			Invoke("MainMenu", 1f);
		}
	}
	
	void MainMenu(){
		if(hasWon){
			Debug.Log("Going back as a winner");
			hasWon = false;
			LevelSystem.xpOnWin = 20;
		}
		else {
			Debug.Log("Going back as a loser");
		}
		
		SceneManager.LoadScene(0);
	}
	
	void Death(){
		if(life <= 0){
			enemys = GameObject.FindGameObjectsWithTag("Enemy");
			foreach(GameObject _enemy in enemys){
				_enemy.GetComponent<Animator>().SetBool("EnemyIsStill", true);
				_enemy.GetComponent<Animator>().SetBool("EnemyAttacks", false);
				_enemy.GetComponent<Enemy>().enabled = false;
			}
			hasWon = false;
			Invoke("MainMenu", 1.5f);
		}
	}
}
