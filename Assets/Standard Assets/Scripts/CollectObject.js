import System.Collections;
import System.Collections.Generic;
import UnityEngine;
import UnityEngine.UI;

function Update(){
 
}

function OnMouseOver() 
 {
     if (Input.GetKeyDown (KeyCode.G)) {
     	Destroy(GameObject.Find("Sword"));
     	GameObject.Find("Antechamber Door").transform.Rotate (0,270,0);
     	GameObject.Find("Grandmother").GetComponent.<UnityEngine.UI.Image> ().color = Color.green;
		GameObject.Find("Direction").GetComponentInChildren.<Text>().text = "Collect all four canopic jars!";
	  }
 }
