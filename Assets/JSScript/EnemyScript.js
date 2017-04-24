import System.Collections;
import System.Collections.Generic;
import UnityEngine;
import UnityEngine.UI;
import UnityEngine.SceneManagement;

 var Player : Transform;
 var controller:CharacterController;
 var myCG: CanvasGroup;
 var MoveSpeed = 4;
 var MaxDist = 10;
 var MinDist = 0;
 var TimerLight: Light;
 var MainDoorRotation: Quaternion;
 var AntechamberDoorRotation: Quaternion;
 var AnnexDoorRotation: Quaternion;
 var BurialChamberDoorRotation: Quaternion;
 var TreasuryDoorRotation: Quaternion;
 
 function Start () 
 {
 	controller = gameObject.GetComponent(CharacterController);
 	MainDoorRotation = GameObject.Find ("MainDoor").gameObject.transform.rotation;
 	AntechamberDoorRotation = GameObject.Find ("Antechamber Door").gameObject.transform.rotation;
 	AnnexDoorRotation = GameObject.Find ("AnnexDoor").gameObject.transform.rotation;
 	BurialChamberDoorRotation = GameObject.Find ("Burial Chamber Door").gameObject.transform.rotation;
 	TreasuryDoorRotation = GameObject.Find ("TreasuryDoor").gameObject.transform.rotation;
 }
 
 function Update () 
 {
     transform.LookAt(new Vector3(Player.position.x, Player.position.y, Player.position.z));
     
     if(Vector3.Distance(transform.position,Player.position) >= MinDist){
 			controller.SimpleMove(MoveSpeed*transform.forward);

          if(Vector3.Distance(transform.position,Player.position) <= MaxDist)
              {
                 //Here Call any function U want Like Shoot at here or something
    } 
    
    }
 }

 function OnControllerColliderHit(hit: ControllerColliderHit){
  if (hit.gameObject.name == "FPSController"){
    transform.LookAt(GameObject.Find("Tomb").transform);
    GameObject.Find ("Quiz").GetComponent.<CanvasGroup>().alpha = 0;
    GameObject.Find ("SuccessMessage").GetComponent.<CanvasGroup>().alpha = 0;
    GameObject.Find("KillMessage").GetComponent.<CanvasGroup>().alpha = 1;
  	// Restart the game
     Invoke("Restart", 1);  
  }
}

function Restart(){
	//Application.LoadLevel (0);
	//SceneManager.LoadScene ("Init", LoadSceneMode.Single);
	GameObject.Find("KillMessage").GetComponent.<CanvasGroup>().alpha = 0;
	GameObject.Find ("FPSController").gameObject.transform.position = Vector3(513.4,6.5,69.2);
	GameObject.Find ("Uncle").gameObject.transform.position = Vector3(466,-0.9,289.6);
	GameObject.Find("KeyRenderer").GetComponent.<Renderer>().enabled = true;
	GameObject.Find ("MainDoor").gameObject.transform.rotation = Quaternion.Slerp(GameObject.Find ("MainDoor").gameObject.transform.rotation, MainDoorRotation, Time.time * 1.0f);
	GameObject.Find("Grandfather").GetComponent.<UnityEngine.UI.Image> ().color = Color.black;
	GameObject.Find("Direction").GetComponentInChildren.<Text>().text = "Collect the key from Temple Altar!!";
	GameObject.Find("FPSController").GetComponent.<CursorScript>().QuizNo = 0;
	GameObject.Find("FPSController").GetComponent.<CursorScript>().LevelNo = 0;
	GameObject.Find("FPSController").GetComponent.<CursorScript>().TimeLeft = 300;
	GameObject.Find ("Timer").GetComponent.<CanvasGroup>().alpha = 0;

	GameObject.Find("TutSword").GetComponent.<Renderer>().enabled = true;
	GameObject.Find ("Antechamber Door").gameObject.transform.rotation = Quaternion.Slerp(GameObject.Find ("Antechamber Door").gameObject.transform.rotation, AntechamberDoorRotation, Time.time * 1.0f);
	GameObject.Find("Grandmother").GetComponent.<UnityEngine.UI.Image> ().color = Color.black;

	GameObject.Find("CanopicJar1").GetComponent.<Renderer>().enabled = true;
	GameObject.Find("CanopicJar2").GetComponent.<Renderer>().enabled = true;
	GameObject.Find("CanopicJar3").GetComponent.<Renderer>().enabled = true;
	GameObject.Find("CanopicJar4").GetComponent.<Renderer>().enabled = true;
	GameObject.Find ("AnnexDoor").gameObject.transform.rotation = Quaternion.Slerp(GameObject.Find ("AnnexDoor").gameObject.transform.rotation, AnnexDoorRotation, Time.time * 1.0f);
	GameObject.Find("Father").GetComponent.<UnityEngine.UI.Image> ().color = Color.black;

	GameObject.Find("BookofDead").GetComponent.<Renderer>().enabled = true;
	GameObject.Find ("Burial Chamber Door").gameObject.transform.rotation = Quaternion.Slerp(GameObject.Find ("Burial Chamber Door").gameObject.transform.rotation, BurialChamberDoorRotation, Time.time * 1.0f);
	GameObject.Find("Mother").GetComponent.<UnityEngine.UI.Image> ().color = Color.black;

	GameObject.Find("Cody").GetComponent.<Renderer>().enabled = true;
	GameObject.Find ("TreasuryDoor").gameObject.transform.rotation = Quaternion.Slerp(GameObject.Find ("TreasuryDoor").gameObject.transform.rotation, TreasuryDoorRotation, Time.time * 1.0f);
	GameObject.Find("Tut").GetComponent.<UnityEngine.UI.Image> ().color = Color.black;

	GameObject.Find("God").GetComponent.<Renderer>().enabled = true;

	GameObject.Find ("Q1O1").GetComponent.<Toggle> ().isOn = false;
	GameObject.Find ("Q1O2").GetComponent.<Toggle> ().isOn = false;
	GameObject.Find ("Q1O3").GetComponent.<Toggle> ().isOn = false;
	GameObject.Find ("Q1O4").GetComponent.<Toggle> ().isOn = false;
	GameObject.Find ("Q2O1").GetComponent.<Toggle> ().isOn = false;
	GameObject.Find ("Q2O2").GetComponent.<Toggle> ().isOn = false;
	GameObject.Find ("Q2O3").GetComponent.<Toggle> ().isOn = false;
	GameObject.Find ("Q2O4").GetComponent.<Toggle> ().isOn = false;
	GameObject.Find ("Q3O1").GetComponent.<Toggle> ().isOn = false;
	GameObject.Find ("Q3O2").GetComponent.<Toggle> ().isOn = false;
	GameObject.Find ("Q3O3").GetComponent.<Toggle> ().isOn = false;
	GameObject.Find ("Q3O4").GetComponent.<Toggle> ().isOn = false;
	TimerLight.intensity = 1;
}