using UnityEngine;
using UnityEngine.SceneManagement;

//Main scene script

public class PlayerMovement : MonoBehaviour {
	[ Header ( "Variables" ) ]
	[ SerializeField] private float moveSpeed = 5f;
	[ SerializeField] private float runSpeed = 8f;

	public static string location = null;
	
	private Rigidbody2D rigidBody;
	private AudioSource declineSound; 
	private Vector2 movement;
	private float finalSpeed;

	private void Start ( ) {
		LoadPosition ( );
		Initializations ( );
	}
	
	void Initializations ( ) {
		GetComponent<TrailRenderer>().enabled = true;
		rigidBody = GetComponent<Rigidbody2D>( );
		declineSound = GetComponent<AudioSource>( );
		finalSpeed = moveSpeed;
	}

	private void Update ( ) {
		MovementRead ( );
		LocationUpdate ( );
		Run ( );
		Save ( );
	}

	private void FixedUpdate ( ) {
		rigidBody.velocity = new Vector2 ( movement.x * finalSpeed, movement.y * finalSpeed );
	}

	private void OnTriggerEnter2D ( Collider2D collider ) {
		if ( collider.name == "Macedonia" ) {
			location = "Macedonia";
		}
		else if ( collider.name == "Thracia" ) {
			location = "Thracia";
		}
		else if ( collider.name == "Dacia" ) {
			location = "Dacia";
		}
		else if ( collider.name == "Quaestura Exercitus" ) {
			location = "Quaestura Exercitus";
		}
		else if ( collider.name == "Illyricum" ) {
			location = "Illyricum";
		}
		else if ( collider.name == "Italia Annonaria" ) {
			location = "Italia Annonaria";
		}
		else if ( collider.name == "Italia Suburbicaria" ) {
			location = "Italia Suburbicaria";
		}
		else if ( collider.name == "Pontica" ) {
			location = "Pontica";
		}
		else if ( collider.name == "Asiana" ) {
			location = "Asiana";
		}
		else if ( collider.name == "Oriens" ) {
			location = "Oriens";
		}
		else if ( collider.name == "Aegyptus" ) {
			location = "Aegyptus";
		}
		else if ( collider.name == "Africa" ) {
			location = "Africa";
		}
		else if ( collider.name == "Spaniae" ) {
			location = "Spaniae";
		}
		else if ( collider.name == "Dara" ) {
			location = "Dara";
		}
		else if ( collider.name == "Taginae" ) {
			location = "Taginae";
		}
	}

	private void OnTriggerExit2D ( Collider2D collider ) {
		location = null;
	}

	private void MovementRead ( ) {
		movement.x = Input.GetAxis( "Horizontal" );
		movement.y = Input.GetAxis( "Vertical" );
	}

	private void Run ( ) {
		if ( Input.GetKeyUp ( KeyCode.LeftShift ) ) {
			finalSpeed = moveSpeed;
		}
		if ( Input.GetKeyDown ( KeyCode.LeftShift ) ) {
			finalSpeed = runSpeed;
		}
	}

	private void LoadPosition ( ) {
		if ( PlayerPrefs.HasKey( "X" ) == true || PlayerPrefs.HasKey( "Y" ) == true ) {
			transform.position = new Vector3 ( PlayerPrefs.GetFloat ( "X" ), PlayerPrefs.GetFloat ( "Y" ), 0 );
		}
		else {
			transform.position = new Vector3 ( -62f, -10f, 0 );
		}
	}

	private void Save ( ) {
		PlayerPrefs.SetFloat( "X", transform.position.x );
		PlayerPrefs.SetFloat( "Y", transform.position.y );
	}

	private void LocationUpdate ( ) {
		if ( Input.GetKey ( KeyCode.Space ) ) {
			if ( location == "Spaniae" ) {
				if ( MainMapCanvasScript.hasWonSpaniae ) {
					if ( declineSound.isPlaying == false ) {
						declineSound.Play ( );
					}
				}
				else {
					SceneManager.LoadScene ( 1 );
				}
			}
			if ( location == "Italia Annonaria" ) {
				if ( MainMapCanvasScript.hasWonItaliaAnnonaria ) {
					if ( declineSound.isPlaying == false ) {
						declineSound.Play ( );
					}
				}
				else {
					SceneManager.LoadScene ( 2 );
				}
			}
			if ( location == "Italia Suburbicaria" ) {
				if ( MainMapCanvasScript.hasWonItaliaSuburbicaria ) {
					if ( declineSound.isPlaying == false ) {
						declineSound.Play ( );
					}
				}
				else {
					SceneManager.LoadScene ( 3 );
				}
			}
			if ( location == "Illyricum" ) {
				 if ( MainMapCanvasScript.hasWonIllyricum) {
					if ( !declineSound.isPlaying) {
						declineSound.Play ( );
					}
				}
				else {
					SceneManager.LoadScene ( 4 );
				}
			}
			if ( location == "Dacia" ) {
				if ( MainMapCanvasScript.hasWonDacia ) {
					if ( declineSound.isPlaying == false ) {
						declineSound.Play ( );
					}
				}else {
					SceneManager.LoadScene ( 5 );
				}
			}
			if ( location == "Macedonia" ) {
				if ( MainMapCanvasScript.hasWonMacedonia ) {
					if ( declineSound.isPlaying == false ) {
						declineSound.Play ( );
					}
				}
				else {
					SceneManager.LoadScene ( 6 );
				}
			}
			if ( location == "Quaestura Exercitus" ) {
				if ( MainMapCanvasScript.hasWonQuaesturaExercitus ) {
					if ( declineSound.isPlaying == false ) {
						declineSound.Play ( );
					}
				}
				else {
					SceneManager.LoadScene ( 7 );
				}
			}
			if ( location == "Thracia" ) {
				if ( MainMapCanvasScript.hasWonThracia ) {
					if ( declineSound.isPlaying == false ) {
						declineSound.Play ( );
					}
				}
				else {
					SceneManager.LoadScene ( 8 );
				}
			}
			if ( location == "Pontica" ) {
				if ( MainMapCanvasScript.hasWonPontica ) {
					if ( declineSound.isPlaying == false ) {
						declineSound.Play ( );
					}
				}
				else {
					SceneManager.LoadScene ( 9 );
				}
			}
			if ( location == "Asiana" ) {
				if ( MainMapCanvasScript.hasWonAsiana ) {
					if ( declineSound.isPlaying == false ) {
						declineSound.Play ( );
					}
				}
				else {
					SceneManager.LoadScene ( 10 );
				}
			}
			if ( location == "Oriens" ) {
				if ( MainMapCanvasScript.hasWonOriens ) {
					if ( declineSound.isPlaying == false ) {
						declineSound.Play ( );
					}
				}
				else {
					SceneManager.LoadScene ( 11 );
				}
			}
			if ( location == "Aegyptus" ) {
				if ( MainMapCanvasScript.hasWonAegyptus ) {
					if ( declineSound.isPlaying == false ) {
						declineSound.Play ( );
					}
				}
				else {
					SceneManager.LoadScene ( 12 );
				}
			}
			if ( location == "Africa" ) {
				if ( MainMapCanvasScript.hasWonAfrica ) {
					if ( declineSound.isPlaying == false ) {
						declineSound.Play ( );
					}
				}
				else {
					SceneManager.LoadScene ( 13 );
				}
			}
			if ( location == "Dara" ) {
				if ( MainMapCanvasScript.hasWonSassanids ) {
					if ( declineSound.isPlaying == false ) {
						declineSound.Play ( );
					}
				}
				else {
					SceneManager.LoadScene ( 14 );
				}
			}
			if ( location == "Taginae" ) {
				if ( MainMapCanvasScript.hasWonOstrogoths ) {
					if ( declineSound.isPlaying == false ) {
						declineSound.Play ( );
					}
				}
				else {
					SceneManager.LoadScene ( 15 );
				}
			}
		}
	}
}