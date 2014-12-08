using UnityEngine;
using System.Collections;

public class Book_Collider : MonoBehaviour {
						//This is called after the book is fired
	public float speed; 
	public static Transform target; //this is set by the Book_Fire script
	Transform Spwn;
	void Start() {
				GameObject tmp;
				if (target.name == "Player1") {
					tmp = GameObject.Find ("Spawn_P1");
					Spwn = tmp.transform;
				}
				if (target.name == "Player2") {
					tmp = GameObject.Find ("Spawn_P2");
					Spwn = tmp.transform;
				}
		}
	void OnTriggerEnter2D(Collider2D col) { 	//called once the book collides with target
				if (col.gameObject.name == target.gameObject.name) { 
						col.audio.Play ();
						Debug.Log ("Book collided with " + target.gameObject.name);
						target.transform.position = Spwn.transform.position; //this moves the player back to their spawn and resets
						target.transform.rotation = Spwn.transform.rotation;	//their cars rotation to 0
						Destroy (gameObject);
				}
		}

	void Update() {
		speed = 35;
		float step = speed * Time.deltaTime; 
		transform.position = Vector3.MoveTowards(transform.position, target.position, step); //Move in (speed) meters per second
	}																					
}