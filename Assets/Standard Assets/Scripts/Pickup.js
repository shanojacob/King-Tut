import System.Collections;
import System.Collections.Generic;
import UnityEngine;
import UnityEngine.UI;

var onhand : Transform;
var carrying = 0;
var Speed = 5;

function Update(){
	
  /*if (Input.GetKeyDown (KeyCode.D)) {
  	carrying = 0;
  	this.transform.parent = null;
	GetComponent.<Rigidbody>().useGravity = true;
  }*/
}

function OnMouseOver() 
 {
     if (Input.GetKeyDown (KeyCode.G)) {
     	carrying = 1;
     	GetComponent.<Rigidbody>().useGravity = false;
		this.transform.position = onhand.position;
		this.transform.parent = GameObject.Find("FPSController").transform;
		this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
	  }
 }

 function OnCollisionEnter(col:Collision){
 	
	if (col.gameObject.name == "EntranceDoor") {
		carrying = 0;
		this.transform.parent = null;
		this.GetComponent.<Rigidbody>().useGravity = true;

		col.gameObject.transform.parent.Rotate (0,270,0);
		GameObject.Find("Grandfather").GetComponent.<UnityEngine.UI.Image> ().color = Color.green;
		GameObject.Find("Direction").GetComponentInChildren.<Text>().text = "Grab the Sword!";
	} else if(carrying == 1){
 		this.GetComponent.<Rigidbody>().isKinematic = true;
 		GetComponent.<Rigidbody>().useGravity = false;
		this.transform.position = onhand.position;
		this.transform.parent = GameObject.Find("FPSController").transform;
		this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
	}
}
	function OnCollisionExit(col:Collision){
 	
		if(carrying == 1){
	 		this.GetComponent.<Rigidbody>().isKinematic = false;
		}
	}

