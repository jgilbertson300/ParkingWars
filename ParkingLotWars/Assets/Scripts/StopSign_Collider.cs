using UnityEngine;
using System.Collections;

public class StopSign_Collider : MonoBehaviour {
	public float TimeAtStopSign;
	public static GameObject target;
	public AudioClip clip;
	public bool timerActive = false;
	void Start(){
		TimeAtStopSign = 3.0f;
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.gameObject.name == target.name) {
			timerActive = true;
			Car_Controller carcontroller = col.GetComponent ("Car_Controller") as Car_Controller;
			carcontroller.speed = 0.0f;
			carcontroller.rotationSpeed = 0.0f;
			if (TimeAtStopSign <= 0.0f) {
				timerActive = false;
				if(col.name.Contains("1")){
					col.audio.Play ();
					carcontroller.speed = PlayerPrefs.GetFloat("Player1Speed");
					carcontroller.rotationSpeed = PlayerPrefs.GetFloat("Player1Rotation");
				}
				if(col.name.Contains("2")){
					col.audio.Play ();
					carcontroller.speed = PlayerPrefs.GetFloat("Player2Speed");
					carcontroller.rotationSpeed = PlayerPrefs.GetFloat("Player2Rotation");
				}
				Debug.Log ("StopSign is gone");
				Destroy (gameObject);
			}
		}
	}
	void FixedUpdate() {
		if (timerActive == true) {
			TimeAtStopSign -= Time.deltaTime;
		}
	}
}
