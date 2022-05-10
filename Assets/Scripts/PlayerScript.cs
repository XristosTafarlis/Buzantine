using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour{
	
	[Header("Variables")]
	public int life = 100;
	public int damage = 5;
	
	GameObject[] enemys;
	bool hasWon;
	
	void Start(){
		
	}

	void Update(){
		Death();
		Invoke("HasWon", 1f);
	}
	
	void HasWon(){
		if(WaveSpawner.wavesFinished == true){
			hasWon = true;
			Invoke("MainMenu", 1f);
		}
	}
	
	void MainMenu(){
		if(hasWon) Debug.Log("Going back as a winner");
		else Debug.Log("Going back as a loser");
		
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
