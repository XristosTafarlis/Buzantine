using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour{

	public enum SpawnState {SPAWNING, WAITING, COUNTING};

	[System.Serializable]
	[SerializeField] class Wave{
		public string name;
		public Transform enemy;
		public int count;
		public float rate;
	}

	[SerializeField] Wave[] waves;
	[SerializeField] Transform spawnPoint;
	[SerializeField] float timeBetweenWaves = 2f;
	public static bool wavesFinished = false;
	
	int nextWave = 0;
	float waveCountdown;
	float searchCountdown = 1f;
	SpawnState state = SpawnState.COUNTING;

	void Start() {
		waveCountdown = timeBetweenWaves;
	}

	void Update(){
		if(state == SpawnState.WAITING){
			//Check if enemies are still alive
			if(!EnemyIsAlive()){
				//Begin new round
				WaveCompleted();
				return;
			}else{
				return;
			}
		}

		if(waveCountdown <= 0){
			if(state != SpawnState.SPAWNING){
				StartCoroutine(SpawnWave(waves[nextWave]));
			}
		}else{
			waveCountdown -= Time.deltaTime;
		}
	}

	void WaveCompleted(){
		state = SpawnState.COUNTING;
		waveCountdown = timeBetweenWaves;

		if (nextWave + 1 > waves.Length - 1){
			nextWave = 0;
			wavesFinished = true;
			state = SpawnState.COUNTING;
		}else{
			nextWave++;
		}
		
	}

	bool EnemyIsAlive(){
		searchCountdown -= Time.deltaTime;
		if(searchCountdown <= 0){
			searchCountdown = 1f;
			if (GameObject.FindGameObjectWithTag("Enemy") == null){
				return false;
			}
		}
		return true;
	}

	IEnumerator SpawnWave(Wave _wave){
		state = SpawnState.SPAWNING;
		//Spawning
		for (int i = 0; i < _wave.count; i++){
			SpawnEnemy(_wave.enemy);
			yield return new WaitForSeconds(1f/_wave.rate);
		}

		//Waiting
		state = SpawnState.WAITING;
		yield break;
	}

	void SpawnEnemy(Transform _enemy){
		Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
	}
}