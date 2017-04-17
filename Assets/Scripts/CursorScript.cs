using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour 
{
	public Question[] Quiz;
	public int QuizNo = 0;
	public CanvasGroup cgQuiz;
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
		Quiz[4] = new Question ("What type of business does Isis own?", "Funeral home", "Nursing home", "Funeral home", "Car dealership", "Cleaning business");
		Quiz[5] = new Question ("What did Tut have to do to open the scroll?", "Let a drop of his blood fall onto it", "Let a drop of his blood fall onto it", "Chant the verse that Horus taught him", "Dance to the song \"Walk Like an Egyptian\"", "Wave a jewel over it");
		Quiz[6] = new Question ("What was inside the pizza box?", "Asps", "Pizza", "Cobras", "Scorpions", "Asps");
		Quiz[7] = new Question ("What object is Tut looking for?", "A knife", "A knife", "A fork", "A sword", "A scroll");
		Quiz[8] = new Question ("What is the spell Tut tries to use in his tomb?", "Judgement of the Dead", "Judgement of the Dead", "Stars of the Dead", "Blood of the Dead", "Night of the Dead");
		Quiz[9] = new Question ("Who did Isis say has the object?", "Gilgamesh", "Set", "Osiris", "Gilgamesh", "Tia");
		Quiz[10] = new Question ("What is the name of Tut's favorite Shabti?", "Colonel Cody", "General Holden", "Captain John", "Colonel Cody", "Cheif Ken");
		Quiz[11] = new Question ("Which son of Horus works at a funeral home?", "Hapi", "Qeb", "Imsety", "Hapi", "Duamutef");
		Quiz[12] = new Question ("What is the name of Horus's cat girlfriend?", "Bast", "Bast", "Beth", "Tia", "Isis");
		Quiz[13] = new Question ("What is the name of Tut's World Cultures teacher?", "Mr. Plant", "Mr. Pleasant", "Mr. Plant", "Mr. Smith", "Mrs. Tia");
		Quiz[14] = new Question ("What does Henry's t-shirt supporting?", "Pluto is a Planet", "Go Green", "Global Warming", "Solar Energy", "Pluto is a Planet");
		Quiz[15] = new Question ("What is the take-out place Henry gets Hamburgers from?", "White Castle", "Burger King", "White Castle", "Wendy's", "McDonalds");
		Quiz[16] = new Question ("In what neighborhood in Washington, D.C. is Tut's townhouse?", "Foggy Bottom", "Froggy Pad", "Bikini Bottom", "Foggy Bottom", "Soggy Bottom");
		Quiz[17] = new Question ("What is the name of the funeral home Tut visits?", "Dynasty Funeral Homes", "Isis's Funeral Homes", "Dynasty Funeral Homes", "Heavenly Funeral Homes", "Destiny Funeral Homes");

		//Set Cursor to be visible
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		cgQuiz = GameObject.Find ("Quiz").GetComponent<CanvasGroup> ();


		//Submit Quiz
		GameObject.Find ("Submit").GetComponent<Button> ().onClick.AddListener (SubmitQuiz);
		GameObject.Find ("Close").GetComponent<Button> ().onClick.AddListener (CloseMessage);
	}

	void Update () 
	{
		//Set Cursor to be visible
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		//Check distance with key (1st level)
		if (QuizNo == 0 && Vector3.Distance (transform.position, GameObject.Find ("key").transform.position) <= 10) {
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
		if (QuizNo == 1 && Vector3.Distance (transform.position, GameObject.Find ("TutSword").transform.position) <= 10) {
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
			// Make quiz visible
			cgQuiz.alpha = 1;
		}
		//Check distance with canopic jars (3rd level)
		if (QuizNo == 2 && Vector3.Distance (transform.position, GameObject.Find ("CanopicJarTable").transform.position) <= 10) {
			QuizNo = 3;
			//Reset options
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
		if (QuizNo == 3 && Vector3.Distance (transform.position, GameObject.Find ("BookofDead").transform.position) <= 10) {
			QuizNo = 4;
			//Reset options
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
		if (QuizNo == 4 && Vector3.Distance (transform.position, GameObject.Find ("Cody").transform.position) <= 10) {
			QuizNo = 5;
			//Reset options
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
		if (QuizNo == 5 && Vector3.Distance (transform.position, GameObject.Find ("God").transform.position) <= 10) {
			QuizNo = 6;
			//Reset options
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
			
	}

	void SubmitQuiz(){
		if (QuizNo == 1 && GameObject.Find ("Q1O2").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q2O2").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q3O3").GetComponent<Toggle> ().isOn == true) {
			cgQuiz.alpha = 0;
			GameObject.Find ("SuccessMessage").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find ("SuccessMessage").GetComponentInChildren<Text> ().text = "Congratulations!!! You've successfully collected the key. Tomb is open!";
			GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup> ().alpha = 1;
			//Destroy Key
			Destroy(GameObject.Find("key"));
			//Open Tomb entrance
			GameObject.Find ("MainDoor").gameObject.transform.Rotate (0,270,0);
			//Highlight level in family tree and give next direction
			GameObject.Find("Grandfather").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find("Direction").GetComponentInChildren<Text>().text = "Collect the Sword!";
		} else if (QuizNo == 2 && GameObject.Find ("Q1O4").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q2O2").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q3O1").GetComponent<Toggle> ().isOn == true) {
			cgQuiz.alpha = 0;
			GameObject.Find ("SuccessMessage").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find ("SuccessMessage").GetComponentInChildren<Text> ().text = "Congratulations!!! You've successfully collected the sword. Door to the next chamber is open!";
			GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup> ().alpha = 1;
			//Destroy Sword
			Destroy(GameObject.Find("TutSword"));
			//Open chamber door
			GameObject.Find("Antechamber Door").transform.Rotate (0,270,0);
			//Highlight level in family tree and give next direction
			GameObject.Find("Grandmother").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find("Direction").GetComponentInChildren<Text>().text = "Collect all four canopic jars!";
		} else if (QuizNo == 3 && GameObject.Find ("Q1O4").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q2O1").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q3O1").GetComponent<Toggle> ().isOn == true) {
			cgQuiz.alpha = 0;
			GameObject.Find ("SuccessMessage").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find ("SuccessMessage").GetComponentInChildren<Text> ().text = "Congratulations!!! You've successfully collected the jars. Door to the next chamber is open!";
			GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup> ().alpha = 1;
			//Destroy Canopic Jars
			Destroy(GameObject.Find("CanopicJar1"));
			Destroy(GameObject.Find("CanopicJar2"));
			Destroy(GameObject.Find("CanopicJar3"));
			Destroy(GameObject.Find("CanopicJar4"));
			//Open chamber door
			GameObject.Find("AnnexDoor").transform.Rotate (0,270,0);
			//Highlight level in family tree and give next direction
			GameObject.Find("Father").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find("Direction").GetComponentInChildren<Text>().text = "Collect the Book of the Dead!";
		} else if (QuizNo == 4 && GameObject.Find ("Q1O3").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q2O3").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q3O3").GetComponent<Toggle> ().isOn == true) {
			cgQuiz.alpha = 0;
			GameObject.Find ("SuccessMessage").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find ("SuccessMessage").GetComponentInChildren<Text> ().text = "Congratulations!!! You've successfully collected the Book of the Dead. Door to the next chamber is open!";
			GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup> ().alpha = 1;
			//Destroy Book of Dead
			Destroy(GameObject.Find("BookofDead"));
			//Open chamber door
			GameObject.Find("Burial Chamber Door").transform.Rotate (0,270,0);
			//Highlight level in family tree and give next direction
			GameObject.Find("Mother").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find("Direction").GetComponentInChildren<Text>().text = "Collect Colonel Cody!";
		} else if (QuizNo == 5 && GameObject.Find ("Q1O1").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q2O2").GetComponent<Toggle> ().isOn == true && GameObject.Find ("Q3O4").GetComponent<Toggle> ().isOn == true) {
			cgQuiz.alpha = 0;
			GameObject.Find ("SuccessMessage").GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			GameObject.Find ("SuccessMessage").GetComponentInChildren<Text> ().text = "Congratulations!!! You've successfully collected the Shabti. Door to the next chamber is open!";
			GameObject.Find ("SuccessMessage").GetComponent<CanvasGroup> ().alpha = 1;
			//Destroy Book of Dead
			Destroy(GameObject.Find("Cody"));
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
			//Destroy Book of Dead
			Destroy(GameObject.Find("God"));
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

}
