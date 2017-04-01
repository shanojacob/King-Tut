using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickupable : MonoBehaviour {
	public Transform onhand;
	// Use this for initialization
	void OnCollisionEnter(Collision col){
		this.transform.position = onhand.position;
		this.transform.parent = GameObject.Find("FPSController").transform;
		this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;

		GameObject btnGFather = GameObject.Find ("Grandfather");
		GameObject btnDirection = GameObject.Find ("Direction");
		if (col.gameObject.name == "EntranceDoor") {
			this.transform.parent = null;
			this.GetComponent<Rigidbody>().useGravity = true;

			col.gameObject.transform.parent.Rotate (0,45,0);
			btnGFather.GetComponent<UnityEngine.UI.Image> ().color = Color.green;
			btnDirection.GetComponentInChildren<Text>().text = "Get the Sword!";
		}
	}
		

}
