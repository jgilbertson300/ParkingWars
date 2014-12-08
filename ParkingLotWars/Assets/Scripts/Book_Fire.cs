using UnityEngine;
using System.Collections;

public class Book_Fire : MonoBehaviour {
				//All this mess is just to figure out where the book is to be shot from and where it's going. Once it's shot,
	public GameObject Weapon;		//the weapon itself has a script(Book_Collider) that tells it how to move.
	public GameObject Source;
	public GameObject target;
	public Transform targetTransform;
	GameObject clone;
	int n, i, j;
	void Start() {
		if(gameObject.name.Contains("1")){
			n = 1;
			i = 0;
			j = 2;
		}
		if(gameObject.name.Contains("2")){
			n = 2;
			i = 2;
			j = 1;
		}
		Source = GameObject.Find (string.Format ("Player{0}Source",n));
		Weapon = Resources.Load ("Weapon_Book", typeof(GameObject)) as GameObject;
		target = GameObject.Find (string.Format("Player{0}", j));
		targetTransform = target.transform;
	}
	void Update () {
		if (Input.GetButtonDown (string.Format ("Player{0}Fire", n))) { //This just spawns the book which has 
			Debug.Log ("Source is " + Source.gameObject.name); 		//its own script for its behavior.
			clone = Instantiate (Weapon, Source.transform.position, Source.transform.rotation) as GameObject;
			Book_Collider.target = targetTransform;
			clone.name = string.Format("Wpn_Book{0}", i);
			Debug.Log ("Book is live");
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
