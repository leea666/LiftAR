//172.10.10.158
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Raycast : NetworkBehaviour {

	//child raycast gameobjects
	//moon object and moon answers
	public GameObject moon ;
	private GameObject tempMoon ;
	public GameObject rocket ;
	private GameObject tempRocket ;
	public GameObject moonQuarterQuestion ;
	private GameObject tempMoonQuarterQuestion ;
	public GameObject moonAnswer1 ;
	private GameObject tempMoonAnswer1 ;
	public GameObject moonAnswer2 ;
	private GameObject tempMoonAnswer2 ;
	public GameObject moonAnswer3 ;
	private GameObject tempMoonAnswer3 ;
	Animator quarterAnimation ;
	Animator eighthAnimation ;

	//rocket object and rocket answers
	public GameObject rocketQuestion ;
	private GameObject tempRocketQuestion;
	Animator rocketAnimation ;
	public GameObject rocketAnswer1 ;
	private GameObject tempRocketAnswer1 ;
	public GameObject rocketAnswer2 ;
	private GameObject tempRocketAnswer2 ;
	public GameObject rocketAnswer3 ;
	private GameObject tempRocketAnswer3 ;

	//helmet objects and helmet answer
	public GameObject helmet ;
	private GameObject tempHelmet ;
	public GameObject helmetQuestion;
	private GameObject tempHelmetQuestion ;
	public GameObject helmetAnswer1;
	private GameObject tempHelmetAnswer1;
	public GameObject helmetAnswer2;
	private GameObject tempHelmetAnswer2;
	public GameObject helmetAnswer3;
	private GameObject tempHelmetAnswer3;

	//progress bar for child
	public GameObject cnoFill ;
	public GameObject cone ;
	public GameObject ctwo ;
	public GameObject cthree ;

	private GameObject tempcnoFill ;
	private GameObject tempcone ;
	private GameObject tempctwo ;
	private GameObject tempcthree ;


	//parent gameobjects
	//moon hints
	Vector3 moonPos ;
	public GameObject moonHint1 ;
	private GameObject tempMoonHint1 ;
	public GameObject moonHint2 ;
	private GameObject tempMoonHint2 ;
	public GameObject moonCorrect ;
	private GameObject tempMoonCorrect ;
	public bool selectMoonAnswer = true ;

	//rocket hints
	Vector3 rocketPos ;
	public GameObject rocketHint1 ;
	private GameObject tempRocketHint1 ;
	public GameObject rocketHint2 ;
	private GameObject tempRocketHint2 ;
	public GameObject rocketCorrect ;
	private GameObject tempRocketCorrect ;
	public bool selectRocketAnswer = true;

	//helmet hints
	Vector3 helmetPos ;
	public GameObject helmetHint1 ;
	private GameObject tempHelmetHint1 ;
	public GameObject helmetHint2 ;
	private GameObject tempHelmetHint2 ;
	public GameObject helmetCorrect ;
	private GameObject tempHelmetCorrect ;
	public bool selectHelmetAnswer = true;

//	private bool makeParentObjectsOnce = true ;
	private bool showMoonHintOnce = true ;
	private bool showRocketHintOnce = true ;
	private bool showHelmetHintOnce = true ;

	//progress bar for parent
	public GameObject pnoFill ;
	public GameObject pone ;
	public GameObject ptwo ;
	public GameObject pthree ;

	private GameObject temppnoFill ;
	private GameObject temppone ;
	private GameObject tempptwo ;
	private GameObject temppthree ;

	//load in the final end scene
	public GameObject endScene;
	private GameObject tempEndScene ;

	// booleans to turn on and off objects
	public bool doOnce = true ;
	public bool moonQuestionOnce = true;
	public bool rocketQuestionOnce = true ;
	public bool helmetQuestionOnce = true ;
	private bool moonCorrectOnce = true;
	private bool rocketCorrectOnce = true;
	private bool helmetCorrectOnce = true ;
	private bool moonHint2Once = true;
	private bool rocketHint2Once = true;
	private bool helmetHint2Once = true ;

	private bool lostTracking ;
	//check to see if server
	public bool checkServer = false ;
	//check to see if client
	public bool checkClient = false ;
	private bool createBorder = true ;
	private bool updateProgressBar = true ;
	private bool updateProgressBar2 = false ;
	private bool playOnce = true ;
	string prevRayName;
	public Material[] material ;
	Renderer rend ;

	//right, wrong, and background sound for game
	public AudioClip correctAnswer;
	public AudioClip wrongAnswer;
	public AudioClip ambientSound ;
	private AudioSource source;
	float volume = 1.0f ;
	public Vector3 imagePos;

	//communicating between child and parent
	public int moonAnswer = 0 ;
	public int oldMoon = 0 ;
	public int rocketAnswer = 0 ;
	private int oldRocket = 0 ;
	public int helmetAnswer = 0 ;
	private int oldHelmet = 0 ;

	//raycast distance and collision detection on layers
	public float maxRayDistance = 30.0f;
	public LayerMask collisionLayerMask;
	public float findingSquareDist = 0.5f;

	private string objectDetected;
	private string answerDetected;

	//particle system for each object if answered correctly
	public GameObject moonParticles ;
	private GameObject tempMoonParticles ;
	public bool displayMoonParticles = true ;
	public GameObject rocketParticles ;
	private GameObject tempRocketParticles ;
	public bool displayRocketParticles = true ;
	public GameObject helmetParticles ;
	private GameObject tempHelmetParticles ;
	public bool displayHelmetParticles = true ;

	public GameObject astronaut ;
	private GameObject tempAstronaut ;
	private bool setEndSceneOnce = true ;

	void Start () {
		source = GetComponent<AudioSource>();
		source.Play();
	}

	void Update () {
		
//		if (GameObject.Find ("helmet(Clone)") && helmetQuestionOnce == true) {
//			helmetPos = GameObject.Find ("helmet(Clone)").transform.position;
//			tempHelmetQuestion = Instantiate (helmetQuestion, new Vector3 (helmetPos.x+0.75f, helmetPos.y+0.4f, helmetPos.z+0.5f), new Quaternion (0, 0, 0, 0));
//			tempHelmetQuestion.transform.localScale = new Vector3 (0.03f, 0.03f, 0.4f);
//			tempHelmetQuestion.transform.Rotate (0.0f, 270.0f, 0.0f);
//
//			tempHelmetAnswer1 = Instantiate (helmetAnswer1, new Vector3 (helmetPos.x -0.29f+0.25f, helmetPos.y-0.36f, helmetPos.z-0.25f), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
//			//				tempMoonAnswer1.transform.localScale = new Vector3 (30.0f, 30.0f, 30.0f);
//			tempHelmetAnswer1.transform.localScale = new Vector3 (40.0f, 40.0f, 40.0f);
//			tempHelmetAnswer1.transform.Rotate (0.0f, 180.0f, 0.0f);
//			tempHelmetAnswer2 = Instantiate (helmetAnswer2, new Vector3 (helmetPos.x + 0.33f+0.25f, helmetPos.y-0.36f, helmetPos.z-0.25f), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
//			//				tempMoonAnswer2.transform.localScale = new Vector3 (30.0f, 30.0f, 30.0f);
//			tempHelmetAnswer2.transform.localScale = new Vector3 (40.0f, 40.0f, 40.0f);
//			tempHelmetAnswer2.transform.Rotate (0.0f, 180.0f, 0.0f);
//			tempHelmetAnswer3 = Instantiate (helmetAnswer3, new Vector3 (helmetPos.x + 1.003f+0.25f, helmetPos.y-0.36f, helmetPos.z-0.25f), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
//			//				tempMoonAnswer3.transform.localScale = new Vector3 (30.0f, 30.0f, 30.0f);
//			tempHelmetAnswer3.transform.localScale = new Vector3 (40.0f, 40.0f, 40.0f);
//			tempHelmetAnswer3.transform.Rotate (0.0f, 180.0f, 0.0f);
//
//			helmetQuestionOnce = false;
//		}

//		Debug.Log ("Update Moon Answer: "+moonAnswer + "Update Old Moon Answer:" + oldMoon);
//		Debug.Log ("old " + oldMoon);

		//get the positions of all of the original game objects within space
		if (GameObject.Find ("helmet(Clone)")) {
			helmetPos = GameObject.Find ("helmet(Clone)").transform.position;
		}
		if (GameObject.Find ("Rocket (1)(Clone)")) {
			rocketPos = GameObject.Find("Rocket (1)(Clone)").transform.position ;
		}
		if (GameObject.Find ("Moon(Clone)")) {
			moonPos = GameObject.Find ("Moon(Clone)").transform.position;
		}

		//check to see if player tapped screen
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				//cast a ray on where the player tapped ;
				Ray touchRay = Camera.main.ScreenPointToRay(touch.position) ;
				RaycastHit hit2 = new RaycastHit();
				if (Physics.Raycast (touchRay, out hit2, maxRayDistance, collisionLayerMask)) {
					answerDetected = hit2.transform.gameObject.name;
					//moon answers
					if (answerDetected == "twoFourths(Clone)" && selectMoonAnswer == true) {
						source.PlayOneShot(correctAnswer,volume);
						foreach (Renderer rend in GameObject.Find("twoFourths(Clone)").GetComponentsInChildren<Renderer>()) {
							rend.material.color = Color.green;
						}
						selectMoonAnswer = false;
						oldMoon = moonAnswer;
						moonAnswer = 1;
						updateProgressBar = true;
					}
					if (answerDetected == "twoEighths(Clone)" && selectMoonAnswer == true) {
							foreach (Renderer rend in GameObject.Find("twoEighths(Clone)").GetComponentsInChildren<Renderer>()) {
								rend.material.color = Color.red;
							}
						source.PlayOneShot(wrongAnswer,volume);
						if (moonAnswer == 2) {
							selectMoonAnswer = false;
							moonAnswer = 3;
						} else {
							moonAnswer = 2;
						}
					}

					if (answerDetected == "oneFourths(Clone)" && selectMoonAnswer == true) {
							foreach (Renderer rend in GameObject.Find("oneFourths(Clone)").GetComponentsInChildren<Renderer>()) {
								rend.material.color = Color.red;
							}
						source.PlayOneShot(wrongAnswer,volume);
						if (moonAnswer == 2) {
							selectMoonAnswer = false;
							moonAnswer = 3;
						} else {
							moonAnswer = 2;
						}

					}

					//rocket answers
					if (answerDetected == "threeFourths(Clone)" && selectRocketAnswer == true) {
						source.PlayOneShot(correctAnswer,volume);
						foreach (Renderer rend in GameObject.Find("threeFourths(Clone)").GetComponentsInChildren<Renderer>()) {
							rend.material.color = Color.green;
						}
						rocketAnswer = 1;
						updateProgressBar = true;
						selectRocketAnswer = false;
					}
					if (answerDetected == "fiveEighths(Clone)" && selectRocketAnswer == true) {
						foreach (Renderer rend in GameObject.Find("fiveEighths(Clone)").GetComponentsInChildren<Renderer>()) {
							rend.material.color = Color.red;
						}
						source.PlayOneShot(wrongAnswer,volume);
						if (rocketAnswer == 2) {
							selectRocketAnswer = false;
							rocketAnswer = 3;
						} else {
							rocketAnswer = 2;
						}

					}
					if (answerDetected == "fiveFourths(Clone)" && selectRocketAnswer == true) {
						foreach (Renderer rend in GameObject.Find("fiveFourths(Clone)").GetComponentsInChildren<Renderer>()) {
							rend.material.color = Color.red;
						}
						source.PlayOneShot(wrongAnswer,volume);
						if (rocketAnswer == 2) {
							selectRocketAnswer = false;
							rocketAnswer = 3;
						} else {
							rocketAnswer = 2;
						}

					}

					//helmet answers
					if (answerDetected == "twoThirds(Clone)" && selectHelmetAnswer == true) {
						source.PlayOneShot(correctAnswer,volume);
						foreach (Renderer rend in GameObject.Find("twoThirds(Clone)").GetComponentsInChildren<Renderer>()) {
							rend.material.color = Color.green;
						}
						helmetAnswer = 1;
						updateProgressBar = true;
						selectHelmetAnswer = false;
					}
					if (answerDetected == "threeThirds(Clone)" && selectHelmetAnswer == true) {
						foreach (Renderer rend in GameObject.Find("threeThirds(Clone)").GetComponentsInChildren<Renderer>()) {
							rend.material.color = Color.red;
						}
						source.PlayOneShot(wrongAnswer,volume);
						if (helmetAnswer == 2) {
							selectHelmetAnswer = false;
							helmetAnswer = 3;
						} else {
							helmetAnswer = 2;
						}

					}
					if (answerDetected == "threeHalves(Clone)" && selectHelmetAnswer == true) {
						foreach (Renderer rend in GameObject.Find("threeHalves(Clone)").GetComponentsInChildren<Renderer>()) {
							rend.material.color = Color.red;
						}
						source.PlayOneShot(wrongAnswer,volume);
						if (helmetAnswer == 2) {
							selectHelmetAnswer = false;
							helmetAnswer = 3;
						} else {
							helmetAnswer = 2;
						}
					}

				}
			}
				

		}

		if (checkServer == true && rocketAnswer == 1 && helmetAnswer == 1 && moonAnswer == 1 && updateProgressBar == true) {
			if (GameObject.Find ("cnofill(Clone)")) {
				Destroy (GameObject.Find ("cnofill(Clone)"));
			}
			if (GameObject.Find ("cone(Clone)")) {
				Destroy (GameObject.Find ("cone(Clone)"));
			}
			if (GameObject.Find ("ctwo(Clone)")) {
				Destroy (GameObject.Find ("ctwo(Clone)"));
			}
			tempcthree = Instantiate (cthree, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
			tempcthree.transform.SetParent (GameObject.Find ("NetWorkCanvas").transform, false);
			updateProgressBar = false;
		} else if (checkServer == true && updateProgressBar == true && ((rocketAnswer == 1 && helmetAnswer == 1) || (rocketAnswer == 1 && moonAnswer == 1) || (helmetAnswer == 1 && moonAnswer == 1))) {
			if (GameObject.Find ("cnofill(Clone)")) {
				Destroy (GameObject.Find ("cnofill(Clone)"));
			}
			if (GameObject.Find ("cone(Clone)")) {
				Destroy (GameObject.Find ("cone(Clone)"));
			}
			tempctwo = Instantiate (ctwo, new Vector3 (0,0,0), Quaternion.identity);
			tempctwo.transform.SetParent (GameObject.Find ("NetWorkCanvas").transform, false);
			updateProgressBar = false;
		} else if (checkServer == true && updateProgressBar == true && (rocketAnswer == 1 || helmetAnswer == 1 || moonAnswer == 1)) {
			if (GameObject.Find ("cnofill(Clone)")) {
				Destroy (GameObject.Find ("cnofill(Clone)"));
			}
			tempcone = Instantiate (cone, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
			tempcone.transform.SetParent (GameObject.Find ("NetWorkCanvas").transform, false);
			updateProgressBar = false;
		}

		if (checkClient == true && rocketAnswer == 1 && helmetAnswer == 1 && moonAnswer == 1 && updateProgressBar2 == true) {
			if (GameObject.Find ("pnofill(Clone)")) {
				Destroy (GameObject.Find ("pnofill(Clone)"));
			}
			if (GameObject.Find ("pone(Clone)")) {
				Destroy (GameObject.Find ("pone(Clone)"));
			}
			if (GameObject.Find ("ptwo(Clone)")) {
				Destroy (GameObject.Find ("ptwo(Clone)"));
			}
			temppthree = Instantiate (pthree, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
			temppthree.transform.SetParent (GameObject.Find ("NetWorkCanvas").transform, false);
			updateProgressBar2 = false;
		} else if (checkClient == true && updateProgressBar2 == true && ((rocketAnswer == 1 && helmetAnswer == 1) || (rocketAnswer == 1 && moonAnswer == 1) || (helmetAnswer == 1 && moonAnswer == 1))) {
			if (GameObject.Find ("pnofill(Clone)")) {
				Destroy (GameObject.Find ("pnofill(Clone)"));
			}
			if (GameObject.Find ("pone(Clone)")) {
				Destroy (GameObject.Find ("pone(Clone)"));
			}
			tempptwo = Instantiate (ptwo, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
			tempptwo.transform.SetParent (GameObject.Find ("NetWorkCanvas").transform, false);
			updateProgressBar2 = false;
		} else if (checkClient == true && updateProgressBar2 == true && (rocketAnswer == 1 || helmetAnswer == 1 || moonAnswer == 1)) {
			if (GameObject.Find ("pnofill(Clone)")) {
				Destroy (GameObject.Find ("pnofill(Clone)"));
			}
			temppone = Instantiate (pone, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
			temppone.transform.SetParent (GameObject.Find ("NetWorkCanvas").transform, false);
			updateProgressBar2 = false;
		}

		if(GameObject.Find("PlayerObject(Clone)")) {
			GameObject playerStatus = GameObject.Find ("PlayerObject(Clone)");
			PlayerScript getServer = playerStatus.GetComponent<PlayerScript> ();
			checkServer = getServer.isthistheserver;
		}
		if(GameObject.Find("PlayerObject(Clone)") && checkClient == true) {
			GameObject moonStatus = GameObject.Find ("PlayerObject(Clone)");
			PlayerScript getMoonAnswer = moonStatus.GetComponent<PlayerScript> ();
			moonAnswer = getMoonAnswer.moon;
			selectMoonAnswer = getMoonAnswer.setMoon;
		}
		if(GameObject.Find("PlayerObject(Clone)") && checkClient == true) {
			GameObject rocketStatus = GameObject.Find ("PlayerObject(Clone)");
			PlayerScript getRocketAnswer = rocketStatus.GetComponent<PlayerScript> ();
			rocketAnswer = getRocketAnswer.rocket;
			helmetAnswer = getRocketAnswer.helmet;
			selectRocketAnswer = getRocketAnswer.setRocket;
			selectHelmetAnswer = getRocketAnswer.setHelmet;
		}

		if (GameObject.Find ("MenuControl")) {
			GameObject playerStatus = GameObject.Find ("MenuControl");
			MenuControl getServer = playerStatus.GetComponent<MenuControl> ();
			checkClient = getServer.isClient;
		}

		if (GameObject.Find ("ImageTarget")) {
			GameObject imageTarget = GameObject.Find ("ImageTarget");
			DefaultTrackableEventHandler getImagePos = imageTarget.GetComponent<DefaultTrackableEventHandler> ();
			imagePos = getImagePos.imageTargetPos;
		}


		//create ui borders
		if (checkServer == true && createBorder == true) {
			//2.523659306
			//163.7574
			//6.510946
//			tempcBorder = Instantiate (cBorder, new Vector3 (0.0f, 0.0f, 0.0f), new Quaternion (0, 0, 0, 0));
//			tempcBorder.transform.localScale = new Vector3 (28.65640375f, 28.65640375f, 28.65640375f);
//			tempcBorder.transform.SetParent(GameObject.Find("NetWorkCanvas").transform);
			//2.53
			//2.5236
			tempcnoFill = Instantiate (cnoFill, new Vector3 (0,0,0), Quaternion.identity);
//			tempcnoFill.transform.localScale = new Vector3 (2.5f, 2.5f, 2.5f);
			tempcnoFill.transform.SetParent(GameObject.Find("NetWorkCanvas").transform,false);

			createBorder = false;
		}

		if (checkClient == true && createBorder == true) {
			temppnoFill = Instantiate (pnoFill, new Vector3 (0,0,0),  Quaternion.identity);
//			temppnoFill.transform.localScale = new Vector3 (2.5f, 2.5f, 2.5f);
			temppnoFill.transform.SetParent(GameObject.Find("NetWorkCanvas").transform,false);

			createBorder = false;
		}

		if (checkClient == true && createBorder == true) {
			createBorder = false;
		}

		//use center of screen for focusing
		Vector3 center = new Vector3(Screen.width/2, Screen.height/2, findingSquareDist);
		Ray ray = Camera.main.ScreenPointToRay (center);
		Debug.DrawRay( ray.origin, ray.direction * 50f, Color.red);
		RaycastHit hit = new RaycastHit();

		if (Physics.Raycast (ray, out hit, maxRayDistance, collisionLayerMask)) {
//			Debug.Log ("Running");

			objectDetected = hit.transform.gameObject.name;

//			Debug.Log (objectDetected);

			//child raycasts
			if (objectDetected == "Moon(Clone)" && moonQuestionOnce == true && checkServer == true) {
				Debug.Log ("the moon");
				moonPos = GameObject.Find ("Moon(Clone)").transform.position;
				tempMoonQuarterQuestion = Instantiate (moonQuarterQuestion, new Vector3 (moonPos.x + 1.35f, moonPos.y + 0.37f, moonPos.z + 0.5f), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));			
				tempMoonQuarterQuestion.transform.localScale = new Vector3 (15.0f, 15.0f, 15.0f);
				tempMoonQuarterQuestion.transform.Rotate (0.0f, 90.0f, 0.0f);

				tempMoonAnswer1 = Instantiate (moonAnswer1, new Vector3 (moonPos.x + 0.1f, moonPos.y - 0.65f, moonPos.z - 0.25f), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
				tempMoonAnswer1.transform.localScale = new Vector3 (15.0f, 15.0f, 15.0f);
				tempMoonAnswer1.transform.Rotate (0.0f, 180.0f, 0.0f);
				tempMoonAnswer2 = Instantiate (moonAnswer2, new Vector3 (moonPos.x + 0.6f, moonPos.y - 0.65f, moonPos.z - 0.25f), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
				tempMoonAnswer2.transform.localScale = new Vector3 (15.0f, 15.0f, 15.0f);
				tempMoonAnswer2.transform.Rotate (0.0f, 180.0f, 0.0f);
				tempMoonAnswer3 = Instantiate (moonAnswer3, new Vector3 (moonPos.x + 1.1f, moonPos.y - 0.65f, moonPos.z - 0.25f), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
				tempMoonAnswer3.transform.localScale = new Vector3 (15.0f, 15.0f, 15.0f);
				tempMoonAnswer3.transform.Rotate (0.0f, 180.0f, 0.0f);

				Destroy (GameObject.Find("Moon(Clone)"));

				moonQuestionOnce = false;

				if(GameObject.Find("rocketQuestion(Clone)") && selectRocketAnswer == true) {
					Destroy (GameObject.Find("rocketQuestion(Clone)"));
					Destroy (GameObject.Find("threeFourths(Clone)"));
					Destroy (GameObject.Find("fiveFourths(Clone)"));
					Destroy (GameObject.Find("fiveEighths(Clone)"));
					rocketQuestionOnce = true;
					rocketAnimation.SetTrigger ("disappear");
					rocketAnimation.SetTrigger ("popWindow");
					tempRocket = Instantiate(rocket, rocketPos, new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
					tempRocket.transform.localScale = new Vector3 (15.0f, 15.0f, 15.0f);
					tempRocket.transform.Rotate (0.0f, 90.0f, 0.0f);
				}
				if (GameObject.Find ("thirdQuestion(Clone)") && selectHelmetAnswer == true) {
					Destroy (GameObject.Find("fourth 1(Clone)"));
					Destroy (GameObject.Find("threeHalves(Clone)"));
					Destroy (GameObject.Find("threeThirds(Clone)"));
					Destroy (GameObject.Find("twoThirds(Clone)"));
					helmetQuestionOnce = true;
					tempHelmet = Instantiate(helmet, helmetPos, new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
					tempHelmet.transform.localScale = new Vector3 (20.0f, 20.0f, 20.0f);
					tempHelmet.transform.Rotate (0.0f, 180.0f, 0.0f);
				}

			} else if (objectDetected == "Rocket (1)(Clone)" && rocketQuestionOnce == true && checkServer == true) {
				Debug.Log ("the Rocket");

				rocketPos = GameObject.Find ("Rocket (1)(Clone)").transform.position;
				tempRocketQuestion = Instantiate (rocketQuestion, new Vector3 (rocketPos.x - 0.2f, rocketPos.y + 0.08f, rocketPos.z + 0.75f), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
				tempRocketQuestion.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
				GameObject rocketChild = tempRocketQuestion.transform.GetChild (0).gameObject;
				rocketAnimation = rocketChild.GetComponent<Animator> ();
				rocketAnimation.SetTrigger ("popWindow");
				rocketAnimation.SetTrigger ("disappear");

				tempRocketAnswer1 = Instantiate (rocketAnswer1, new Vector3 (rocketPos.x + 1.47f, rocketPos.y + 1.0f, rocketPos.z - 7.79f), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
				tempRocketAnswer2 = Instantiate (rocketAnswer2, new Vector3 (rocketPos.x + 0.3f, rocketPos.y - 0.263f, rocketPos.z - 0.25f), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
				tempRocketAnswer2.transform.Rotate (0.0f, 180.0f, 0.0f);
				tempRocketAnswer3 = Instantiate (rocketAnswer3, new Vector3 (rocketPos.x + 0.0f, rocketPos.y - 0.261f, rocketPos.z - 0.25f), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
				tempRocketAnswer3.transform.Rotate (0.0f, 180.0f, 0.0f);

				Destroy (GameObject.Find ("Rocket (1)(Clone)"));

				rocketQuestionOnce = false;

				if (GameObject.Find ("fourth 1(Clone)") && selectMoonAnswer == true) {
					Destroy (GameObject.Find("fourth 1(Clone)"));
					Destroy (GameObject.Find("oneFourths(Clone)"));
					Destroy (GameObject.Find("twoFourths(Clone)"));
					Destroy (GameObject.Find("twoEighths(Clone)"));
					moonQuestionOnce = true;
					tempMoon = Instantiate(moon, moonPos, new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
					tempMoon.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f) ;
				}
				if (GameObject.Find ("thirdQuestion(Clone)") && selectHelmetAnswer == true) {
					Destroy (GameObject.Find("fourth 1(Clone)"));
					Destroy (GameObject.Find("threeHalves(Clone)"));
					Destroy (GameObject.Find("threeThirds(Clone)"));
					Destroy (GameObject.Find("twoThirds(Clone)"));
					helmetQuestionOnce = true;
					tempHelmet = Instantiate(helmet, helmetPos, new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
					tempHelmet.transform.localScale = new Vector3 (20.0f, 20.0f, 20.0f);
					tempHelmet.transform.Rotate (0.0f, 180.0f, 0.0f);
				}

			} else if (objectDetected == "helmet(Clone)" && helmetQuestionOnce == true && checkServer == true) {
				tempHelmetQuestion = Instantiate (helmetQuestion, new Vector3 (helmetPos.x+0.75f, helmetPos.y+0.4f, helmetPos.z+0.5f), new Quaternion (0, 0, 0, 0));
				tempHelmetQuestion.transform.localScale = new Vector3 (0.03f, 0.03f, 0.4f);
				tempHelmetQuestion.transform.Rotate (0.0f, 270.0f, 0.0f);

				tempHelmetAnswer1 = Instantiate (helmetAnswer1, new Vector3 (helmetPos.x -0.29f+0.25f, helmetPos.y-0.36f, helmetPos.z-0.25f), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
				tempHelmetAnswer1.transform.localScale = new Vector3 (40.0f, 40.0f, 40.0f);
				tempHelmetAnswer1.transform.Rotate (0.0f, 180.0f, 0.0f);
				tempHelmetAnswer2 = Instantiate (helmetAnswer2, new Vector3 (helmetPos.x + 0.33f+0.25f, helmetPos.y-0.36f, helmetPos.z-0.25f), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
				tempHelmetAnswer2.transform.localScale = new Vector3 (40.0f, 40.0f, 40.0f);
				tempHelmetAnswer2.transform.Rotate (0.0f, 180.0f, 0.0f);
				tempHelmetAnswer3 = Instantiate (helmetAnswer3, new Vector3 (helmetPos.x + 1.003f+0.25f, helmetPos.y-0.36f, helmetPos.z-0.25f), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
				tempHelmetAnswer3.transform.localScale = new Vector3 (40.0f, 40.0f, 40.0f);
				tempHelmetAnswer3.transform.Rotate (0.0f, 180.0f, 0.0f);

				Destroy (GameObject.Find("helmet(Clone)")) ;

				helmetQuestionOnce = false;

				if (GameObject.Find ("fourth 1(Clone)") && selectMoonAnswer == true) {
					Destroy (GameObject.Find("fourth 1(Clone)"));
					Destroy (GameObject.Find("oneFourths(Clone)"));
					Destroy (GameObject.Find("twoFourths(Clone)"));
					Destroy (GameObject.Find("twoEighths(Clone)"));
					moonQuestionOnce = true;
					tempMoon = Instantiate(moon, moonPos, new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
					tempMoon.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f) ;
				}
				if(GameObject.Find("rocketQuestion(Clone)") && selectRocketAnswer == true) {
					Destroy (GameObject.Find("rocketQuestion(Clone)"));
					Destroy (GameObject.Find("threeFourths(Clone)"));
					Destroy (GameObject.Find("fiveFourths(Clone)"));
					Destroy (GameObject.Find("fiveEighths(Clone)"));
					rocketQuestionOnce = true;
					rocketAnimation.SetTrigger ("disappear");
					rocketAnimation.SetTrigger ("popWindow");
					tempRocket = Instantiate(rocket, rocketPos, new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
					tempRocket.transform.localScale = new Vector3 (15.0f, 15.0f, 15.0f);
					tempRocket.transform.Rotate (0.0f, 90.0f, 0.0f);
				}
			}

			//parent raycasts
			if (objectDetected == "Moon(Clone)" && checkClient == true && showMoonHintOnce == true && moonAnswer == 0) {
				tempMoonHint1 = Instantiate(moonHint1, new Vector3 (moonPos.x+1.51f, moonPos.y+0.7f, moonPos.z), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
				tempMoonHint1.transform.localScale = new Vector3 (50.0f, 50.0f, 1.0f);
				tempMoonHint1.transform.Rotate (0.0f, 180.0f, 0.0f);
				showMoonHintOnce = false;

				if (GameObject.Find ("parenthint1(Clone)")) {
					Destroy (GameObject.Find ("parenthint1(Clone)"));
					showRocketHintOnce = true;
				}
				if (GameObject.Find ("astrohint(Clone)")) {
					Destroy (GameObject.Find ("astrohint(Clone)"));
					showHelmetHintOnce = true;
				}
			}

			if (objectDetected == "Rocket (1)(Clone)" && checkClient == true && showRocketHintOnce == true && rocketAnswer == 0) {
				tempRocketHint1 = Instantiate(rocketHint1, new Vector3 (rocketPos.x + 5.6f-10.29f, rocketPos.y-0.44f-0.9f, rocketPos.z), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
				tempRocketHint1.transform.localScale = new Vector3 (50.0f, 50.0f, 1.0f);
				tempRocketHint1.transform.Rotate (0.0f, 180.0f, 0.0f);
				showRocketHintOnce = false;

				if (GameObject.Find ("moon1Hint")) {
					Destroy (GameObject.Find ("moon1Hint"));
					showMoonHintOnce = true;
				}
				if (GameObject.Find ("astrohint(Clone)")) {
					Destroy (GameObject.Find ("astrohint(Clone)"));
					showHelmetHintOnce = true;
				}
			}

			if (objectDetected == "helmet(Clone)" && checkClient == true && showHelmetHintOnce == true && helmetAnswer == 0) {
				tempHelmetHint1 = Instantiate (helmetHint1, new Vector3 (helmetPos.x-2.5f, helmetPos.y-1.09f, helmetPos.z), new Quaternion (0, 0, 0, 0));
				tempHelmetHint1.transform.Rotate (0.0f, 180.0f, 0.0f);
				showHelmetHintOnce = false;

				if (GameObject.Find ("parenthint1(Clone)")) {
					Destroy (GameObject.Find ("parenthint1(Clone)"));
					showRocketHintOnce = true;
				}
				if (GameObject.Find ("moon1Hint")) {
					Destroy (GameObject.Find ("moon1Hint"));
					showMoonHintOnce = true;
				}
			}

			if (rocketAnswer == 1 && checkClient == true && rocketCorrectOnce == true) {
				updateProgressBar = true;
				if (GameObject.Find ("parenthint1(Clone)")) {
					Destroy(GameObject.Find("parenthint1(Clone)")) ;
				}
				if (GameObject.Find ("rockethintr2(Clone)")) {
					Destroy (GameObject.Find ("rockethintr2(Clone)"));
				}
				tempRocketCorrect = Instantiate(rocketCorrect, new Vector3 (rocketPos.x+5.6f, rocketPos.y-1.51f, rocketPos.z), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
				tempRocketCorrect.transform.Rotate (0.0f, 180.0f, 0.0f);
				tempRocketCorrect.transform.localScale = new Vector3 (150.0f, 150.0f, 1.0f);
				rocketCorrectOnce = false;
			}

			if (rocketAnswer == 2 && checkClient == true && rocketHint2Once == true) {
				if (GameObject.Find ("parenthint1(Clone)")) {
					Destroy(GameObject.Find("parenthint1(Clone)")) ;
				}
				tempRocketHint2 = Instantiate(rocketHint2, new Vector3(rocketPos.x-2.0f, rocketPos.y, rocketPos.z), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
				tempRocketHint2.transform.localScale = new Vector3 (30.0f, 30.0f, 1.0f);
				tempRocketHint2.transform.Rotate (0.0f, 180.0f, 0.0f);
				rocketHint2Once = false;
			}

			if (moonAnswer == 1 && checkClient == true && moonCorrectOnce == true) {
				updateProgressBar = true;
				if (GameObject.Find ("moon1Hint(Clone)")) {
					Destroy(GameObject.Find("moon1Hint(Clone)")) ;
				}
				if (GameObject.Find ("tryagainparentr1(Clone)")) {
					Destroy (GameObject.Find ("tryagainparentr1(Clone)"));
				}
				tempMoonCorrect = Instantiate(moonCorrect, new Vector3 (moonPos.x+5.75f, moonPos.y-2.08f, moonPos.z), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
				tempMoonCorrect.transform.Rotate (0.0f, 180.0f, 0.0f);
				tempMoonCorrect.transform.localScale = new Vector3 (150.0f, 150.0f, 1.0f);
				moonCorrectOnce = false;
			}

			if (moonAnswer == 2 && checkClient == true && moonHint2Once == true) {
				if (GameObject.Find ("moon1Hint(Clone)")) {
					Destroy(GameObject.Find("moon1Hint(Clone)")) ;
				}
				tempMoonHint2 = Instantiate(moonHint2, new Vector3 (moonPos.x+3.06f, moonPos.y, moonPos.z), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
				tempMoonHint2.transform.Rotate (0.0f, 180.0f, 0.0f);
				tempMoonHint2.transform.localScale = new Vector3 (55.0f, 55.0f, 1.0f);
				moonHint2Once = false;
			}

			if (helmetAnswer == 1 && checkClient == true && helmetCorrectOnce == true) {
				updateProgressBar = true;
				source.PlayOneShot (correctAnswer, volume);
				if (GameObject.Find ("astrohint(Clone)")) {
					Destroy (GameObject.Find ("astrohint(Clone)"));
				}
				if (GameObject.Find ("astrohint1(Clone)")) {
					Destroy (GameObject.Find ("astrohint1(Clone)"));
				}
				tempHelmetCorrect = Instantiate (helmetCorrect, new Vector3 (helmetPos.x + 5.9f, helmetPos.y-1.93f, helmetPos.z), new Quaternion (0, 0, 0, 0));
				tempHelmetCorrect.transform.Rotate (0.0f, 180.0f, 0.0f);
				tempHelmetCorrect.transform.localScale = new Vector3 (150.0f, 150.0f, 1.0f);
				helmetCorrectOnce = false;
			}
			if (helmetAnswer == 2 && checkClient == true && helmetHint2Once == true) {
				if (GameObject.Find ("astrohint(Clone)")) {
					Destroy (GameObject.Find ("astrohint(Clone)"));
				}
				tempHelmetHint2 = Instantiate (helmetHint2, new Vector3 (helmetPos.x-2.18f, helmetPos.y, helmetPos.z), new Quaternion (0, 0, 0, 0));
				tempHelmetHint2.transform.localScale = new Vector3 (40.0f, 40.0f, 1.0f);
				tempHelmetHint2.transform.Rotate(0.0f, 180.0f, 0.0f) ;
				helmetHint2Once = false;
			}

		}

		if (checkClient == true) {
			Debug.Log ("Parent Moon Answer: "+moonAnswer + "Parent Old Moon Answer:" + oldMoon);
			if (oldRocket != rocketAnswer) {
				if (rocketAnswer == 1) {
					updateProgressBar2 = true;
					source.PlayOneShot (correctAnswer, volume);
				} else if (rocketAnswer == 2 || rocketAnswer == 3) {
					source.PlayOneShot (wrongAnswer, volume);
				}
				oldRocket = rocketAnswer;
				Debug.Log ("Run Rocket");
			}
			if (oldMoon != moonAnswer) {
				if (moonAnswer == 1) {
					updateProgressBar2 = true;
					source.PlayOneShot (correctAnswer, volume);
				} else if (moonAnswer == 2) {
					source.PlayOneShot (wrongAnswer, volume);
				} else if (moonAnswer == 3) {
					source.PlayOneShot (wrongAnswer, volume);
				}
				oldMoon = moonAnswer;
				Debug.Log ("Run Moon");
			}
			if (oldHelmet != helmetAnswer) {
				if (helmetAnswer == 1) {
					updateProgressBar2 = true;
					source.PlayOneShot (correctAnswer, volume);
				} else if (helmetAnswer == 2 || helmetAnswer == 3) {
					source.PlayOneShot (wrongAnswer, volume);
				}
				oldHelmet = helmetAnswer;
				Debug.Log ("Run Helmet");
			}
		}

		if (moonAnswer == 1 && selectMoonAnswer == false && displayMoonParticles == true) {
			if (GameObject.Find ("fourth 1(Clone)")) {
				Destroy (GameObject.Find("fourth 1(Clone)"));
			}
			tempMoon = Instantiate(moon, moonPos, new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
			tempMoon.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f) ;
			tempMoonParticles = Instantiate (moonParticles, new Vector3 (moonPos.x, moonPos.y, moonPos.z), new Quaternion (0, 0, 0, 0));
			tempMoonParticles.GetComponent<ParticleSystem>().Emit(10);
			displayMoonParticles = false;
		}
		if (rocketAnswer == 1 && selectRocketAnswer == false && displayRocketParticles == true) {
			if (GameObject.Find ("rocketQuestion(Clone)")) {
				Destroy (GameObject.Find ("rocketQuestion(Clone)"));
			}
			tempRocket = Instantiate(rocket, rocketPos, new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
			tempRocket.transform.localScale = new Vector3 (15.0f, 15.0f, 15.0f);
			tempRocket.transform.Rotate (0.0f, 90.0f, 0.0f);
			tempRocketParticles = Instantiate (rocketParticles, new Vector3 (rocketPos.x, rocketPos.y, rocketPos.z), new Quaternion (0, 0, 0, 0));
			tempRocketParticles.GetComponent<ParticleSystem> ().Emit (10);
			displayRocketParticles = false;
		}
		if(helmetAnswer == 1 && selectHelmetAnswer == false && displayHelmetParticles == true) {
			if (GameObject.Find ("thirdQuestion(Clone)")) {
				Destroy (GameObject.Find ("thirdQuestion(Clone)"));
			}
			tempAstronaut = Instantiate(astronaut, helmetPos, new Quaternion (0,0,0,0)) ;
			tempHelmetParticles = Instantiate (helmetParticles, new Vector3 (helmetPos.x, helmetPos.y, helmetPos.z), new Quaternion (0,0,0,0)) ;
			tempHelmetParticles.GetComponent<ParticleSystem> ().Emit (10);
			displayHelmetParticles = false ;
		}

		if (setEndSceneOnce== true && selectHelmetAnswer == false && displayHelmetParticles == false && selectMoonAnswer == false && displayMoonParticles == false && selectRocketAnswer == false && displayRocketParticles == false) {
			Debug.Log ("Running");
			StartCoroutine(SetEndScene()) ;
			setEndSceneOnce = false;

		}
	}



	//DELAYYYYYYYY
	IEnumerator SetEndScene(){
		//Wait Length after the animation
		Debug.Log("Waiting") ;
		yield return new WaitForSeconds(10.0f);
		//Code Set Active 
		//instantiate the canvas
		tempEndScene = Instantiate(endScene, new Vector3 (0,0,0), Quaternion.identity) ;
		tempEndScene.transform.SetParent (GameObject.Find ("NetWorkCanvas").transform, false);
	}
}


