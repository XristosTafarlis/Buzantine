using UnityEngine;
using UnityEngine.UI;

public class PopUpTextScript : MonoBehaviour{
	[SerializeField] GameObject player;
	[SerializeField] Text text;

	void Start(){
	}

	void Update(){
		if(player.GetComponent<PlayerScript>().endTheGame == true){
			if(player.GetComponent<PlayerScript>().wonTheGame == true){
				text.text = "Victory!";
				text.color = new Color(0.36f, 0.88f, 0.42f, 1f);
			}else{
				text.color = new Color(0.88f, 0.36f, 0.42f, 1f);
			}
		}
	}
}
