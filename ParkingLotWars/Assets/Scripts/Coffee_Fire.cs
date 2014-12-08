using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Coffee_Fire : MonoBehaviour {
					//All this mess is just to figure out where the coffee is to be shot from.
	public GameObject Weapon;
	public GameObject Source;
	GameObject clone;
	int n, i, j;
	void Start() {
		if(gameObject.name.Contains("1")){
			n = 1;
			i = 0;
		}
		if(gameObject.name.Contains("2")){
			n = 2;
			i = 2;
		}
		Source = GameObject.Find (string.Format ("Player{0}Source",n));
		Weapon = Resources.Load ("Weapon_Coffee", typeof(GameObject)) as GameObject;
	}
	void Update () {
		if (Input.GetButtonDown (string.Format ("Player{0}Fire", n))) {
			//Debug.Log ("Source is " + Source.gameObject.name);
			clone = Instantiate (Weapon, Source.transform.position, Source.transform.rotation) as GameObject;
			Coffee_Collider.Source = string.Format ("Player{0}", n);
			clone.name = string.Format("Wpn_Coffee{0}", i);
			Debug.Log ("coffee is live");
			clone.gameObject.rigidbody2D.AddRelativeForce (Vector2.right * 1000);
			if(n == 1) {
				Inventory1.PlayerItems.Pop (); //Remove the top item in the stack
			}
			else if(n == 2) {
				Inventory2.PlayerItems.Pop();
			}
			Destroy (this);
		}
	}
}
