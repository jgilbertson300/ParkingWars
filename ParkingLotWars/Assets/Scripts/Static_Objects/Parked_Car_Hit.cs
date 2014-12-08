using UnityEngine;
using System.Collections;

public class Parked_Car_Hit : MonoBehaviour {
	//Probaly not necessary, but eh I already made it lol
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name.Contains ("Coffee")) { 
				Destroy (col.gameObject); 
		}
	}
	void OnCollisionEnter2D(Collision2D col2) {
		if(col2.gameObject.name.Contains("Player")){
			Car_Controller controller = col2.gameObject.GetComponent("Car_Controller") as Car_Controller;
			controller.counter++;
			//Debug.Log (controller.counter + " hits for " + col2.gameObject.name);
		}
	}

}
