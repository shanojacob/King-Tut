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
 
 function Start () 
 {
 	controller = gameObject.GetComponent(CharacterController);
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
    controller.SimpleMove(MoveSpeed*transform.forward);
    Destroy(GameObject.Find("UncleIcon"));
    Destroy(GameObject.Find("TutIcon"));
  	GameObject.Find("KillMessage").GetComponent.<CanvasGroup>().alpha = 1;
  	// Restart the game
     Invoke("Restart", 1);  
  }
}

function Restart(){
	//Application.LoadLevel (0);
	SceneManager.LoadScene ("Init", LoadSceneMode.Single);
}