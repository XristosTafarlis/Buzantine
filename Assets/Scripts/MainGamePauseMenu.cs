using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGamePauseMenu : MonoBehaviour{
	[SerializeField] GameObject mainText;
	[SerializeField] GameObject pauseText;
	[SerializeField] GameObject player;
	
	[SerializeField] Text [] locationText;
	bool isPaused;

	void Update(){
		PauseUnpase();
		CheckColor();
	}
	
	void CheckColor(){
		if(MainMapCanvasScript.hasWonSpaniae == true){
			locationText[0].color = Color.green;
		}
		if(MainMapCanvasScript.hasWonItaliaAnnonaria == true){
			locationText[1].color = Color.green;
		}
		if(MainMapCanvasScript.hasWonItaliaSuburbicaria == true){
			locationText[2].color = Color.green;
		}
		if(MainMapCanvasScript.hasWonIllyricum == true){
			locationText[3].color = Color.green;
		}
		if(MainMapCanvasScript.hasWonDacia == true){
			locationText[4].color = Color.green;
		}
		if(MainMapCanvasScript.hasWonMacedonia == true){
			locationText[5].color = Color.green;
		}
		if(MainMapCanvasScript.hasWonQuaesturaExercitus == true){
			locationText[6].color = Color.green;
		}
		if(MainMapCanvasScript.hasWonThracia == true){
			locationText[7].color = Color.green;
		}
		if(MainMapCanvasScript.hasWonPontica == true){
			locationText[8].color = Color.green;
		}
		if(MainMapCanvasScript.hasWonAsiana == true){
			locationText[9].color = Color.green;
		}
		if(MainMapCanvasScript.hasWonOriens == true){
			locationText[10].color = Color.green;
		}
		if(MainMapCanvasScript.hasWonAegyptus == true){
			locationText[11].color = Color.green;
		}
		if(MainMapCanvasScript.hasWonAfrica == true){
			locationText[12].color = Color.green;
		}
		if(MainMapCanvasScript.hasWonSassanids == true){
			locationText[13].color = Color.yellow;
		}
		if(MainMapCanvasScript.hasWonOstrogoths == true){
			locationText[14].color = Color.yellow;
		}
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