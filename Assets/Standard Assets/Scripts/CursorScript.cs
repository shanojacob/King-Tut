using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour 
{
	public Question[] Quiz;
	public int QuizNo = 0;
	public int LevelNo = 0;
	public CanvasGroup cgQuiz;
	public float TimeLeft = 300;
	public Light TimerLight;
	public AudioSource beepAudio;
	public AudioClip beep;
	public int bPlayed = 0;
	public Quaternion MainDoorRotation;
	public Quaternion AntechamberDoorRotation;
	public Quaternion AnnexDoorRotation;
	public Quaternion BurialChamberDoorRotation;
	public Quaternion TreasuryDoorRotation;
	public class Question
	{
		public string QuestionText;
		public string Answer;
		public string Option1;
		public string Option2;
		public string Option3;
		public string Option4;
		public Question(string q, string a, string o1, string o2, string o3, string o4){
			this.QuestionText = q;
			this.Answer = a;
			this.Option1 = o1;
			this.Option2 = o2;
			this.Option3 = o3;
			this.Option4 = o4;
		}
	}

	// Use this for initialization
	void Start () 
	{
		Quiz = new Question[20];
		Quiz[0] = new Question ("Who was trying to remove Tut from the throne?", "Horemheb", "Set", "Horemheb", "Horus", "Anubis");
		Quiz[1] = new Question ("What is Colonel Cody?", "A shabti", "A god", "A shabti", "The god Horus", "Another immortal");
		Quiz[2] = new Question ("Which book did Tut need power from?", "Book of the Dead", "Book of the Egyptians", "Egyptian Mythology", "Book of the Dead", "Tut's Guide to Immortality");
		Quiz[3] = new Question ("Where was the obelisk that exploded?", "Dupont Circle", "The National Mall", "Arlington", "Pentagon City", "Dupont Circle");
		Quiz[4] = new Question ("How old is King Tut?", "14", "16", "14", "21", "12");
		Quiz[5] = new Question ("What did Tut have to do to open the scroll?", "Let a drop of his blood fall onto it", "Let a drop of his blood fall onto it", "Chant the verse that Horus taught him", "Dance to the song \"Walk Like an Egyptian\"", "Wave a jewel over it");
		Quiz[6] = new Question ("What is one of the Egyptian symbols on Tia’s necklace?", "Ankh", "Bird", "Scarab", "Eye", "Ankh");
		Quiz[7] = new Question ("What object is Tut looking for?", "A knife", "A knife", "A fork", "A sword", "A scroll");
		Quiz[8] = new Question ("What is the spell Tut tries to use in his tomb?", "Judgement of the Dead", "Judgement of the Dead", "Stars of the Dead", "Blood of the Dead", "Night of the Dead");
		Quiz[9] = new Question ("Who was Tut’s partner on the field trip?", "Henry", "Seth", "Tia", "Henry", "Gil");
		Quiz[10] = new Question ("What is the name of Tut's favorite Shabti?", "Colonel Cody", "General Holden", "Captain John", "Colonel Cody", "Cheif Ken");
		Quiz[11] = new Question ("What type of bird feathers are on Osiris’s head?", "Ostrich", "Peacock", "Macaw", "Ostrich", "Quetzal");
		Quiz[12] = new Question ("What type of cat is Horus?", "Egyptian Mau", "Egyptian Mau", "Korat", "Sphynx", "Persian");
		Quiz[13] = new Question ("What is the name of Tut's World Cultures teacher?", "Mr. Plant", "Mr. Pleasant", "Mr. Plant", "Mr. Smith", "Mrs. Tia");
		Quiz[14] = new Question ("What does Henry's t-shirt supporting?", "Pluto is a Planet", "Go Green", "Global Warming", "Solar Energy", "Pluto is a Planet");
		Quiz[15] = new Question ("What color does Tut’s skin turn when he gets nervous?", "Green", "Purple", "Green", "Red", "Yellow");
		Quiz[16] = new Question ("What year was King Tut’s tomb opened?", "1922", "1935", "1917", "1922", "1940");
		Quiz[17] = new Question ("Who was the archaeologist who first opened King Tut’s tomb?", "Howard Carter", "Bernard Grenfell", "Howard Carter", "Arthur Hunt", "Pierre Montet");

		//Set Cursor to be visible
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		cgQuiz = GameObject.Find ("Quiz").GetComponent<CanvasGroup> ();


		//Submit Quiz
		GameObject.Find ("Submit").GetComponent<Button> ().onClick.AddListener (SubmitQuiz);
		GameObject.Find ("Close").GetComponent<Button> ().onClick.AddListener (CloseMessage);

		//Save door rotations
		MainDoorRotation = GameObject.Find ("MainDoor").gameObject.transform.rotation;
		AntechamberDoorRotation = GameObject.Find ("Antechamber Door").gameObject.transform.rotation;
		AnnexDoorRotation = GameObject.Find ("AnnexDoor").gameObject.transform.rotation;
		BurialChamberDoorRotation = GameObject.Find ("Burial Chamber Door").gameObject.transform.rotation;
		TreasuryDoorRotation = GameObject.Find ("TreasuryDoor").gameObject.transform.rotation;

	}

	void Update () 
	{
		//Set Cursor to be visible
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		//Check distance with key (1st level)
		if (QuizNo == 0 && Vector3.Distance (transform.position, GameObject.Find ("key").transform.position) < 3.0f) {
			QuizNo = 1;
			//Populate questions and answers
			GameObject.Find ("Question1").GetComponentInChildren<Text> ().text = Quiz [0].QuestionText;
			GameObject.Find ("Q1O1").GetComponentInChildren<Text> ().text = Quiz [0].Option1;
			GameObject.Find ("Q1O2").GetComponentInChildren<Text> ().text = Quiz [0].Option2;
			GameObject.Find ("Q1O3").GetComponentInChildren<Text> ().text = Quiz [0].Option3;
			GameObject.Find ("Q1O4").GetComponentInChildren<Text> ().text = Quiz [0].Option4;
			GameObject.Find ("Question2").GetComponentInChildren<Text> ().text = Quiz [1].QuestionText;
			GameObject.Find ("Q2O1").GetComponentInChildren<Text> ().text = Quiz [1].Option1;
			GameObject.Find ("Q2O2").GetComponentInChildren<Text> ().text = Quiz [1].Option2;
			GameObject.Find ("Q2O3").GetComponentInChildren<Text> ().text = Quiz [1].Option3;
			GameObject.Find ("Q2O4").GetComponentInChildren<Text> ().text = Quiz [1].Option4;
			GameObject.Find ("Question3").GetComponentInChildren<Text> ().text = Quiz [2].QuestionText;
			GameObject.Find ("Q3O1").GetComponentInChildren<Text> ().text = Quiz [2].Option1;
			GameObject.Find ("Q3O2").GetComponentInChildren<Text> ().text = Quiz [2].Option2;
			GameObject.Find ("Q3O3").GetComponentInChildren<Text> ().text = Quiz [2].Option3;
			GameObject.Find ("Q3O4").GetComponentInChildren<Text> ().text = Quiz [2].Option4;
			// Make quiz visible
			cgQuiz.alpha = 1;
		} 
		//Check distance with sword (2nd level)
		if (QuizNo == 1 && Vector3.Distance (transform.position, GameObject.Find ("TutSword").transform.position) < 7.0f) {
			QuizNo = 2;
			//Populate questions and answers
			GameObject.Find ("Question1").GetComponentInChildren<Text> ().text = Quiz [3].QuestionText;
			GameObject.Find ("Q1O1").GetComponentInChildren<Text> ().text = Quiz [3].Option1;
			GameObject.Find ("Q1O2").GetComponentInChildren<Text> ().text = Quiz [3].Option2;
			GameObject.Find ("Q1O3").GetComponentInChildren<Text> ().text = Quiz [3].Option3;
			GameObject.Find ("Q1O4").GetComponentInChildren<Text> ().text = Quiz [3].Option4;
			GameObject.Find ("Question2").GetComponentInChildren<Text> ().text = Quiz [4].QuestionText;
			GameObject.Find ("Q2O1").GetComponentInChildren<Text> ().text = Quiz [4].Option1;
			GameObject.Find ("Q2O2").GetComponentInChildren<Text> ().text = Quiz [4].Option2;
			GameObject.Find ("Q2O3").GetComponentInChildren<Text> ().text = Quiz [4].Option3;
			GameObject.Find ("Q2O4").GetComponentInChildren<Text> ().text = Quiz [4].Option4;
			GameObject.Find ("Question3").GetComponentInChildren<Text> ().text = Quiz [5].QuestionText;
			GameObject.Find ("Q3O1").GetComponentInChildren<Text> ().text = Quiz [5].Option1;
			GameObject.Find ("Q3O2").GetComponentInChildren<Text> ().text = Quiz [5].Option2;
			GameObject.Find ("Q3O3").GetComponentInChildren<Text> ().text = Quiz [5].Option3;
			GameObject.Find ("Q3O4").GetComponentInChildren<Text> ().text = Quiz [5].Option4;
			//Reset options
			ResetQuiz ();
			// Make quiz visible
			cgQuiz.alpha = 1;
		}
		//Check distance with canopic jars (3rd level)
		if (QuizNo == 2 && Vector3.Distance (transform.position, GameObject.Find ("CanopicJarTable").transform.position) < 7.0f) {
			QuizNo = 3;
			//Reset options
			ResetQuiz ();
			//Populate questions and answers
			GameObject.Find ("Question1").GetComponentInChildren<Text> ().text = Quiz [6].QuestionText;
			GameObject.Find ("Q1O1").GetComponentInChildren<Text> ().text = Quiz [6].Option1;
			GameObject.Find ("Q1O2").GetComponentInChildren<Text> ().text = Quiz [6].Option2;
			GameObject.Find ("Q1O3").GetComponentInChildren<Text> ().text = Quiz [6].Option3;
			GameObject.Find ("Q1O4").GetComponentInChildren<Text> ().text = Quiz [6].Option4;
			GameObject.Find ("Question2").GetComponentInChildren<Text> ().text = Quiz [7].QuestionText;
			GameObject.Find ("Q2O1").GetComponentInChildren<Text> ().text = Quiz [7].Option1;
			GameObject.Find ("Q2O2").GetComponentInChildren<Text> ().text = Quiz [7].Option2;
			GameObject.Find ("Q2O3").GetComponentInChildren<Text> ().text = Quiz [7].Option3;
			GameObject.Find ("Q2O4").GetComponentInChildren<Text> ().text = Quiz [7].Option4;
			GameObject.Find ("Question3").GetComponentInChildren<Text> ().text = Quiz [8].QuestionText;
			GameObject.Find ("Q3O1").GetComponentInChildren<Text> ().text = Quiz [8].Option1;
			GameObject.Find ("Q3O2").GetComponentInChildren<Text> ().text = Quiz [8].Option2;
			GameObject.Find ("Q3O3").GetComponentInChildren<Text> ().text = Quiz [8].Option3;
			GameObject.Find ("Q3O4").GetComponentInChildren<Text> ().text = Quiz [8].Option4;
			// Make quiz visible
			cgQuiz.alpha = 1;
		} 
		//Check distance with Book of Dead (4th level)
		if (QuizNo == 3 && Vector3.Distance (transform.position, GameObject.Find ("BookofDead").transform.position) < 7.0f) {
			QuizNo = 4;
			//Reset options
			ResetQuiz ();
			//Populate questions and answers
			GameObject.Find ("Question1").GetComponentInChildren<Text> ().text = Quiz [9].QuestionText;
			GameObject.Find ("Q1O1").GetComponentInChildren<Text> ().text = Quiz [9].Option1;
			GameObject.Find ("Q1O2").GetComponentInChildren<Text> ().text = Quiz [9].Option2;
			GameObject.Find ("Q1O3").GetComponentInChildren<Text> ().text = Quiz [9].Option3;
			GameObject.Find ("Q1O4").GetComponentInChildren<Text> ().text = Quiz [9].Option4;
			GameObject.Find ("Question2").GetComponentInChildren<Text> ().text = Quiz [10].QuestionText;
			GameObject.Find ("Q2O1").GetComponentInChildren<Text> ().text = Quiz [10].Option1;
			GameObject.Find ("Q2O2").GetComponentInChildren<Text> ().text = Quiz [10].Option2;
			GameObject.Find ("Q2O3").GetComponentInChildren<Text> ().text = Quiz [10].Option3;
			GameObject.Find ("Q2O4").GetComponentInChildren<Text> ().text = Quiz [10].Option4;
			GameObject.Find ("Question3").GetComponentInChildren<Text> ().text = Quiz [11].QuestionText;
			GameObject.Find ("Q3O1").GetComponentInChildren<Text> ().text = Quiz [11].Option1;
			GameObject.Find ("Q3O2").GetComponentInChildren<Text> ().text = Quiz [11].Option2;
			GameObject.Find ("Q3O3").GetComponentInChildren<Text> ().text = Quiz [11].Option3;
			GameObject.Find ("Q3O4").GetComponentInChildren<Text> ().text = Quiz [11].Option4;
			// Make quiz visible
			cgQuiz.alpha = 1;
		} 
		//Check distance with Cody (5th level)
		if (QuizNo == 4 && Vector3.Distance (transform.position, GameObject.Find ("Cody").transform.position) < 7.0f) {
			QuizNo = 5;
			//Reset options
			ResetQuiz ();
			//Populate questions and answers
			GameObject.Find ("Question1").GetComponentInChildren<Text> ().text = Quiz [12].QuestionText;
			GameObject.Find ("Q1O1").GetComponentInChildren<Text> ().text = Quiz [12].Option1;
			GameObject.Find ("Q1O2").GetComponentInChildren<Text> ().text = Quiz [12].Option2;
			GameObject.Find ("Q1O3").GetComponentInChildren<Text> ().text = Quiz [12].Option3;
			GameObject.Find ("Q1O4").GetComponentInChildren<Text> ().text = Quiz [12].Option4;
			GameObject.Find ("Question2").GetComponentInChildren<Text> ().text = Quiz [13].QuestionText;
			GameObject.Find ("Q2O1").GetComponentInChildren<Text> ().text = Quiz [13].Option1;
			GameObject.Find ("Q2O2").GetComponentInChildren<Text> ().text = Quiz [13].Option2;
			GameObject.Find ("Q2O3").GetComponentInChildren<Text> ().text = Quiz [13].Option3;
			GameObject.Find ("Q2O4").GetComponentInChildren<Text> ().text = Quiz [13].Option4;
			GameObject.Find ("Question3").GetComponentInChildren<Text> ().text = Quiz [14].QuestionText;
			GameObject.Find ("Q3O1").GetComponentInChildren<Text> ().text = Quiz [14].Option1;
			GameObject.Find ("Q3O2").GetComponentInChildren<Text> ().text = Quiz [14].Option2;
			GameObject.Find ("Q3O3").GetComponentInChildren<Text> ().text = Quiz [14].Option3;
			GameObject.Find ("Q3O4").GetComponentInChildren<Text> ().text = Quiz [14].Option4;
			// Make quiz visible
			cgQuiz.alpha = 1;
		} 
		//Check distance with god (6th level)
		if (QuizNo == 5 && Vector3.Distance (transform.position, GameObject.Find ("God").transform.position) < 7.0f) {
			QuizNo = 6;
			//Reset options
			ResetQuiz ();
			//Populate questions and answers
			GameObject.Find ("Question1").GetComponentInChildren<Text> ().text = Quiz [15].QuestionText;
			GameObject.Find ("Q1O1").GetComponentInChildren<Text> ().text = Quiz [15].Option1;
			GameObject.Find ("Q1O2").GetComponentInChildren<Text> ().text = Quiz [15].Option2;
			GameObject.Find ("Q1O3").GetComponentInChildren<Text> ().text = Quiz [15].Option3;
			GameObject.Find ("Q1O4").GetComponentInChildren<Text> ().text = Quiz [15].Option4;
			GameObject.Find ("Question2").GetComponentInChildren<Text> ().text = Quiz [16].QuestionText;
			GameObject.Find ("Q2O1").GetComponentInChildren<Text> ().text = Quiz [16].Option1;
			GameObject.Find ("Q2O2").GetComponentInChildren<Text> ().text = Quiz [16].Option2;
			GameObject.Find ("Q2O3").GetComponentInChildren<Text> ().text = Quiz [16].Option3;
			GameObject.Find ("Q2O4").GetComponentInChildren<Text> ().text = Quiz [16].Option4;
			GameObject.Find ("Question3").GetComponentInChildren<Text> ().text = Quiz [17].QuestionText;
			GameObject.Find ("Q3O1").GetComponentInChildren<Text> ().text = Quiz [17].Option1;
			GameObject.Find ("Q3O2").GetComponentInChildren<Text> ().text = Quiz [17].Option2;
			GameObject.Find ("Q3O3").GetComponentInChildren<Text> ().text = Quiz [17].Option3;
			GameObject.Find ("Q3O4").GetComponentInChildren<Text> ().text = Quiz [17].Option4;
			// Make quiz visible
			cgQuiz.alpha = 1;
		}

		//Timer & Beep sounds
		if (LevelNo == 1) {
			//Timer
			TimerStart();
			TimerLight.intensity -= Time.deltaTime * 0.003f;
			// Play Beep sound
			if ((int)TimeLeft < 9 && bPlayed == 0) {
				beepAudio.clip = beep;
				beepAudio.Play ();
				bPlayed = 1; 
			} else if ((int)TimeLeft < 0) {
				ResetLevel1 ();
				ResetQuiz ();
			}
		} else if (LevelNo == 2) {
			//Timer
			TimerStart();
			TimerLight.intensity -= Time.deltaTime * 0.004f;
			// Play Beep sound
			if ((int)TimeLeft < 9 && bPlayed == 0) {
				beepAudio.clip = beep;
				beepAudio.Play ();
				bPlayed = 1; 
			} else if ((int)TimeLeft < 0) {
				ResetLevel2 ();
				ResetQuiz ();
			}
		} else if (LevelNo == 3) {
			//Timer
			TimerStart();
			TimerLight.intensity -= Time.deltaTime * 0.005f;
			// Play Beep sound
			if ((int)TimeLeft < 9 && bPlayed == 0) {
				beepAudio.clip = beep;
				beepAudio.Play ();
				bPlayed = 1; 
			} else if ((int)TimeLeft < 0) {
				ResetLevel3 ();
				ResetQuiz ();
			}
		} else if (LevelNo == 4) {
			//Timer
			TimerStart();
			TimerLight.intensity -= Time.deltaTime * 0.008f;
			// Play Beep sound
			if ((int)TimeLeft < 9 && bPlayed == 0) {
				beepAudio.clip = beep;
				beepAudio.Play ();
				bPlayed = 1; 
			} else if ((int)TimeLeft < 0) {
				ResetLevel4 ();
				ResetQuiz ();
			}
		} else if (LevelNo == 5) {
			//Timer
			TimerStart();
			TimerLight.intensity -= Time.deltaTime * 0.01f;
			// Play Beep sound
			if ((int)TimeLeft < 9 && bPlayed == 0) {
				beepAudio.clip = beep;
				beepAudio.Play ();
				bPlayed = 1; 
			} else if ((int)TimeLeft < 0) {
				ResetLevel5 ();
				ResetQuiz ();
			}
		}
			
	}

	void SubmitQuiz(){
		if (QuizNo == 1 && GameObject.Find ("Q1O2").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q2O2").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q3O3").GetComponent<Toggle> ().isOn == true) {
			cgQuiz.alpha = 0;
			LevelNo = 1;
			GameObject.Find ("SuccessMessage").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find ("SuccessMessage").GetComponentInChildren<Text> ().text = "Congratulations!!! You've successfully collected the key. Tomb is open!";
			GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup> ().alpha = 1;
			//Hide Key
			GameObject.Find("KeyRenderer").GetComponent<Renderer>().enabled = false;
			//Open Tomb entrance
			GameObject.Find ("MainDoor").gameObject.transform.Rotate (0,270,0);
			//Highlight level in family tree and give next direction
			GameObject.Find("Grandfather").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find("Direction").GetComponentInChildren<Text>().text = "Collect the Sword!";

		} else if (QuizNo == 2 && GameObject.Find ("Q1O4").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q2O2").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q3O1").GetComponent<Toggle> ().isOn == true) {
			cgQuiz.alpha = 0;

			LevelNo = 2;
			TimeLeft = 240;
			TimerLight.intensity = 1;
			bPlayed = 0;

			GameObject.Find ("SuccessMessage").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find ("SuccessMessage").GetComponentInChildren<Text> ().text = "Congratulations!!! You've successfully collected the sword. Door to the next chamber is open!";
			GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup> ().alpha = 1;
			//Hide Sword
			GameObject.Find("TutSword").GetComponent<Renderer>().enabled = false;
			//Open chamber door
			GameObject.Find("Antechamber Door").transform.Rotate (0,270,0);
			//Highlight level in family tree and give next direction
			GameObject.Find("Grandmother").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find("Direction").GetComponentInChildren<Text>().text = "Collect all four canopic jars!";
		} else if (QuizNo == 3 && GameObject.Find ("Q1O4").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q2O1").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q3O1").GetComponent<Toggle> ().isOn == true) {
			cgQuiz.alpha = 0;

			LevelNo = 3;
			TimeLeft = 180;
			TimerLight.intensity = 1;
			bPlayed = 0;

			GameObject.Find ("SuccessMessage").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find ("SuccessMessage").GetComponentInChildren<Text> ().text = "Congratulations!!! You've successfully collected the jars. Door to the next chamber is open!";
			GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup> ().alpha = 1;
			//Hide Canopic Jars
			GameObject.Find("CanopicJar1").GetComponent<Renderer>().enabled = false;
			GameObject.Find("CanopicJar2").GetComponent<Renderer>().enabled = false;
			GameObject.Find("CanopicJar3").GetComponent<Renderer>().enabled = false;
			GameObject.Find("CanopicJar4").GetComponent<Renderer>().enabled = false;
			//Open chamber door
			GameObject.Find("AnnexDoor").transform.Rotate (0,270,0);
			//Highlight level in family tree and give next direction
			GameObject.Find("Father").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find("Direction").GetComponentInChildren<Text>().text = "Collect the Book of the Dead!";
		} else if (QuizNo == 4 && GameObject.Find ("Q1O3").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q2O3").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q3O3").GetComponent<Toggle> ().isOn == true) {
			cgQuiz.alpha = 0;

			LevelNo = 4;
			TimeLeft = 120;
			TimerLight.intensity = 1;
			bPlayed = 0;

			GameObject.Find ("SuccessMessage").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find ("SuccessMessage").GetComponentInChildren<Text> ().text = "Congratulations!!! You've successfully collected the Book of the Dead. Door to the next chamber is open!";
			GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup> ().alpha = 1;
			//Hide Book of Dead
			GameObject.Find("BookofDead").GetComponent<Renderer>().enabled = false;
			//Open chamber door
			GameObject.Find("Burial Chamber Door").transform.Rotate (0,270,0);
			//Highlight level in family tree and give next direction
			GameObject.Find("Mother").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find("Direction").GetComponentInChildren<Text>().text = "Collect Colonel Cody!";
		} else if (QuizNo == 5 && GameObject.Find ("Q1O1").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q2O2").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q3O4").GetComponent<Toggle> ().isOn == true) {
			cgQuiz.alpha = 0;

			LevelNo = 5;
			TimeLeft = 90;
			TimerLight.intensity = 1;
			bPlayed = 0;

			GameObject.Find ("SuccessMessage").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find ("SuccessMessage").GetComponentInChildren<Text> ().text = "Congratulations!!! You've successfully collected the Shabti. Door to the next chamber is open!";
			GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup> ().alpha = 1;
			//Hide Cody
			GameObject.Find("Cody").GetComponent<Renderer>().enabled = false;
			//Open chamber door
			GameObject.Find("TreasuryDoor").transform.Rotate (0,270,0);
			//Highlight level in family tree and give next direction
			GameObject.Find("Tut").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find("Direction").GetComponentInChildren<Text>().text = "Collect the God to complete the game!";
		} else if (QuizNo == 6 && GameObject.Find ("Q1O2").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q2O3").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q3O2").GetComponent<Toggle> ().isOn == true) {
			cgQuiz.alpha = 0;
			GameObject.Find ("SuccessMessage").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find ("SuccessMessage").GetComponentInChildren<Text> ().text = "Congratulations!!! You've successfully completed the game!";
			GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup> ().alpha = 1;
			//Hide God
			GameObject.Find("God").GetComponent<Renderer>().enabled = false;
			LevelNo = 6;
			TimerLight.intensity = 1;
			GameObject.Find ("Timer").GetComponent<CanvasGroup>().alpha = 0;
			//Open chamber door
			//GameObject.Find("TreasuryDoor").transform.Rotate (0,270,0);
			//Highlight level in family tree and give next direction
			//GameObject.Find("Tut").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find("Direction").GetComponentInChildren<Text>().text = "Congratulations!!!";
		} else {
			GameObject.Find ("SuccessMessage").GetComponent<UnityEngine.UI.Image> ().color = Color.red;
			GameObject.Find ("SuccessMessage").GetComponentInChildren<Text> ().text = "Some of your answers are wrong, please try again!!!";
			GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup> ().alpha = 1;
		}
	}

	void CloseMessage(){
		GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup> ().alpha = 0;
	}

	void TimerStart(){
		GameObject.Find ("Timer").GetComponent<CanvasGroup> ().alpha = 1;
		TimeLeft -= Time.deltaTime;
		string minutes = ((int)TimeLeft / 60).ToString ();
		string seconds = (TimeLeft % 60).ToString ("f2");
		GameObject.Find ("Timer").GetComponentInChildren<Text> ().text = minutes + " : " + seconds;
	}

	void ResetLevel1(){
		GameObject.Find ("FPSController").gameObject.transform.position = new Vector3(513.4f,6.5f,69.2f);
		GameObject.Find ("Uncle").gameObject.transform.position = new Vector3(466f,-0.9f,289.6f);
		GameObject.Find("KeyRenderer").GetComponent<Renderer>().enabled = true;
		GameObject.Find ("MainDoor").gameObject.transform.rotation = Quaternion.Slerp(GameObject.Find ("MainDoor").gameObject.transform.rotation, MainDoorRotation, Time.time * 1.0f);
		GameObject.Find("Grandfather").GetComponent<UnityEngine.UI.Image> ().color = Color.black;
		GameObject.Find("Direction").GetComponentInChildren<Text>().text = "Collect the key from Temple Altar!!";
		QuizNo = 0;
		LevelNo = 0;
		GameObject.Find ("Timer").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find ("Quiz").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup>().alpha = 0;
		TimerLight.intensity = 1;
		TimeLeft = 300;
	}

	void ResetQuiz(){
		GameObject.Find ("Q1O1").GetComponent<Toggle> ().isOn = false;
		GameObject.Find ("Q1O2").GetComponent<Toggle> ().isOn = false;
		GameObject.Find ("Q1O3").GetComponent<Toggle> ().isOn = false;
		GameObject.Find ("Q1O4").GetComponent<Toggle> ().isOn = false;
		GameObject.Find ("Q2O1").GetComponent<Toggle> ().isOn = false;
		GameObject.Find ("Q2O2").GetComponent<Toggle> ().isOn = false;
		GameObject.Find ("Q2O3").GetComponent<Toggle> ().isOn = false;
		GameObject.Find ("Q2O4").GetComponent<Toggle> ().isOn = false;
		GameObject.Find ("Q3O1").GetComponent<Toggle> ().isOn = false;
		GameObject.Find ("Q3O2").GetComponent<Toggle> ().isOn = false;
		GameObject.Find ("Q3O3").GetComponent<Toggle> ().isOn = false;
		GameObject.Find ("Q3O4").GetComponent<Toggle> ().isOn = false;
	}

	void ResetLevel2(){
		GameObject.Find ("FPSController").gameObject.transform.position = new Vector3(429.8f,6.5f,66.3f);
		GameObject.Find("TutSword").GetComponent<Renderer>().enabled = true;
		GameObject.Find ("Antechamber Door").gameObject.transform.rotation = Quaternion.Slerp(GameObject.Find ("Antechamber Door").gameObject.transform.rotation, AntechamberDoorRotation, Time.time * 1.0f);
		GameObject.Find("Grandmother").GetComponent<UnityEngine.UI.Image> ().color = Color.black;
		GameObject.Find("Direction").GetComponentInChildren<Text>().text = "Collect the Sword!";
		QuizNo = 1;
		LevelNo = 1;
		GameObject.Find ("Timer").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find ("Quiz").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup>().alpha = 0;
		TimerLight.intensity = 1;
		TimeLeft = 300;
	}

	void ResetLevel3(){
		GameObject.Find ("FPSController").gameObject.transform.position = new Vector3(363.5f,6.5f,63.9f);
		GameObject.Find("CanopicJar1").GetComponent<Renderer>().enabled = true;
		GameObject.Find("CanopicJar2").GetComponent<Renderer>().enabled = true;
		GameObject.Find("CanopicJar3").GetComponent<Renderer>().enabled = true;
		GameObject.Find("CanopicJar4").GetComponent<Renderer>().enabled = true;
		GameObject.Find ("AnnexDoor").gameObject.transform.rotation = Quaternion.Slerp(GameObject.Find ("AnnexDoor").gameObject.transform.rotation, AnnexDoorRotation, Time.time * 1.0f);
		GameObject.Find("Father").GetComponent<UnityEngine.UI.Image> ().color = Color.black;
		GameObject.Find("Direction").GetComponentInChildren<Text>().text = "Collect all four canopic jars!";
		QuizNo = 2;
		LevelNo = 2;
		GameObject.Find ("Timer").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find ("Quiz").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup>().alpha = 0;
		TimerLight.intensity = 1;
		TimeLeft = 240;
	}

	void ResetLevel4(){
		GameObject.Find ("FPSController").gameObject.transform.position = new Vector3(324.7f,6.5f,49.9f);
		GameObject.Find("BookofDead").GetComponent<Renderer>().enabled = true;
		GameObject.Find ("Burial Chamber Door").gameObject.transform.rotation = Quaternion.Slerp(GameObject.Find ("Burial Chamber Door").gameObject.transform.rotation, BurialChamberDoorRotation, Time.time * 1.0f);
		GameObject.Find("Mother").GetComponent<UnityEngine.UI.Image> ().color = Color.black;
		GameObject.Find("Direction").GetComponentInChildren<Text>().text = "Collect the Book of the Dead!";
		QuizNo = 3;
		LevelNo = 3;
		GameObject.Find ("Timer").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find ("Quiz").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup>().alpha = 0;
		TimerLight.intensity = 1;
		TimeLeft = 180;
	}

	void ResetLevel5(){
		GameObject.Find ("FPSController").gameObject.transform.position = new Vector3(365.9f,6.5f,128.3f);
		GameObject.Find("Cody").GetComponent<Renderer>().enabled = true;
		GameObject.Find ("TreasuryDoor").gameObject.transform.rotation = Quaternion.Slerp(GameObject.Find ("TreasuryDoor").gameObject.transform.rotation, TreasuryDoorRotation, Time.time * 1.0f);
		GameObject.Find("Tut").GetComponent<UnityEngine.UI.Image> ().color = Color.black;
		GameObject.Find("Direction").GetComponentInChildren<Text>().text = "Collect Colonel Cody!";
		QuizNo = 4;
		LevelNo = 4;
		GameObject.Find ("Timer").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find ("Quiz").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup>().alpha = 0;
		TimerLight.intensity = 1;
		TimeLeft = 120;
	}

}
