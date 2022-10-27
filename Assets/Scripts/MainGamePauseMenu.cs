using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGamePauseMenu : MonoBehaviour{
	[SerializeField] GameObject mainText;
	[SerializeField] GameObject pauseText;
	[SerializeField] GameObject player;
	bool isPaused;
	
	void Update(){
		PauseUnpase();
	}
	
	void PauseUnpase(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(!isPaused){
				mainText.SetActive(false);
				pauseText.SetActive(true);
				Time.timeScale = 0;
				isPaused = true;
			}else{
				mainText.SetActive(true);
				pauseText.SetActive(false);
				Time.timeScale = 1;
				isPaused = false;
			}
		}
	}
	
	public void Unpause(){
		mainText.SetActive(true);
		pauseText.SetActive(false);
		Time.timeScale = 1;
		isPaused = false;
	}
	
	public void ResetAndRestart(){
		Time.timeScale = 1;
		PlayerPrefs.DeleteAll();
		player.transform.position = new Vector3(-62f, -10f, 0);
		mainText.SetActive(true);
		pauseText.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);	// Resets game
	}
	
	public void Exit(){
		Application.Quit();
	}
}