using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		//Set Cursor to be visible
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		//GameObject.Find("KillMessage").SetActive(false);
	}

	void Update () 
	{
		//Set Cursor to be visible
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

}
