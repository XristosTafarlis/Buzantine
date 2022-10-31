using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGamePauseMenu : MonoBehaviour{
	[Header("Main Categories")]
	[SerializeField] GameObject mainText;
	[SerializeField] GameObject pauseText;
	
	[Header("Buttons")]
	[SerializeField] GameObject keybinds;
	[SerializeField] GameObject sounds;
	[SerializeField] GameObject resetConfrimation;
	[SerializeField] GameObject exitConfrimation;
	
	[Header("Misc")]
	[SerializeField] GameObject player;
	[SerializeField] Text [] locationText;
	[SerializeField] Slider musicVolume;
	
	bool isPaused;
	bool inKeybinds;
	bool inSounds;
	bool inResetConfirmation;
	bool inExitConfirmation;
	
	void Start(){
		if(!PlayerPrefs.HasKey("musicVolume")){
			PlayerPrefs.SetFloat("musicVolume", 1f);
			Load();
		}else{
			Load();
		}
	}
	
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
			if(!isPaused){	//If is playing
				mainText.SetActive(false);
				pauseText.SetActive(true);
				Time.timeScale = 0;
				isPaused = true;
			}else{	//If in pause menu
				if(inKeybinds){	//If in Keybinds section
					HideKeybinds();
				}else if(inResetConfirmation){	//If in Reset Confirmation
					HideResetConfirmation();
				}else if(inExitConfirmation){	//If in Exit Confirmation
					HideExitConfirmation();
				}else if(inSounds){	//If in Sound Settings
					HideSounds();
				}else{	//Else, close pause menu
					mainText.SetActive(true);
					pauseText.SetActive(false);
					Time.timeScale = 1;
					isPaused = false;
				}
			}
		}
	}
	
	public void Unpause(){
		mainText.SetActive(true);
		pauseText.SetActive(false);
		Time.timeScale = 1;
		isPaused = false;
	}
	
	public void ShowKeybinds(){
		inKeybinds = true;
		keybinds.SetActive(true);
	}
	
	public void HideKeybinds(){
		inKeybinds = false;
		keybinds.SetActive(false);
	}
	
	public void ShowSounds(){
		inSounds = true;
		sounds.SetActive(true);
	}
	
	public void HideSounds(){
		inSounds = false;
		sounds.SetActive(false);
	}
	
	public void ChangeMusicVolume(){
		AudioListener.volume = musicVolume.value;
		Save();
	}
	
	void Load() => musicVolume.value = PlayerPrefs.GetFloat("musicVolume");
	
	void Save() => PlayerPrefs.SetFloat("musicVolume", musicVolume.value);
	
	public void ShowResetConfirmation(){
		inResetConfirmation = true;
		resetConfrimation.SetActive(true);
	}
	
	public void HideResetConfirmation(){
		inResetConfirmation = false;
		resetConfrimation.SetActive(false);
	}
	
	public void ResetAndRestart(){
		Time.timeScale = 1;
		float tempVolume = PlayerPrefs.HasKey("musicVolume") ? PlayerPrefs.GetFloat("musicVolume") : 1f;	//Keep volume level
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetFloat("musicVolume", tempVolume);
		player.transform.position = new Vector3(-62f, -10f, 0);
		mainText.SetActive(true);
		pauseText.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);	// Resets game
	}
	
	public void ShowExitConfirmation(){
		inExitConfirmation = true;
		exitConfrimation.SetActive(true);
	}
	
	public void HideExitConfirmation(){
		inExitConfirmation = false;
		exitConfrimation.SetActive(false);
	}
	
	public void Exit() => Application.Quit();
}