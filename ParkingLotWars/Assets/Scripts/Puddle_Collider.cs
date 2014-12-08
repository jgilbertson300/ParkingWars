using UnityEngine;
using System.Collections;

public class Puddle_Collider : MonoBehaviour {
	void Start () {
		On_Start.Timer_HazardActive = true;
		Debug.Log("Puddle is live!");
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name.Contains("Player")) {
			Car_Controller carcontroller = col.GetComponent ("Car_Controller") as Car_Controller;
			carcontroller.speed = 2.0f;
			carcontroller.rotationSpeed = 40.0f;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.name.Contains("Player")) {
			Car_Controller carcontroller = col.GetComponent ("Car_Controller") as Car_Controller;
			if(col.name.Contains("1")){
				carcontroller.speed = PlayerPrefs.GetFloat("Player1Speed");
				carcontroller.rotationSpeed = PlayerPrefs.GetFloat("Player1Rotation");
			}
			if(col.name.Contains("2")){
				carcontroller.speed = PlayerPrefs.GetFloat("Player2Speed");
				carcontroller.rotationSpeed = PlayerPrefs.GetFloat("Player2Rotation");
			}
		}
	}
}