using UnityEngine;
using System.Collections;

public class Student_Collider : MonoBehaviour {
					//this is called when the student spawns
	public float speed;
	public AudioClip clip;
	public static Transform target;
	GameObject audiosrc;
	GameObject Right, Left;
	void Start() {
		Debug.Log ("Student is live!");
		Right = GameObject.Find ("Student_Right");
		Left = GameObject.Find ("Student_Left");
		audiosrc = GameObject.Find ("audiosource");
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.name == Right.name) {
			gameObject.transform.rotation = col.transform.rotation;
			target = Left.transform;
		}
		if(col.gameObject.name == Left.name) {
			gameObject.transform.rotation = col.transform.rotation;
			target = Right.transform;
		}
		if(col.gameObject.name.Contains("Player")) {
			AudioSource.PlayClipAtPoint(clip, audiosrc.transform.position);
			On_Start.Timer_HazardActive = true;

			if(col.gameObject.name.Contains("1")) {
				if(Inventory1.PlayerItems.Count !=0) {
					Inventory1.PlayerItems.Pop ();
					Debug.Log ("Player1 has lost an item!");
				}
			}
			if(col.gameObject.name.Contains("2")) {
				if(Inventory2.PlayerItems.Count != 0) {
					Inventory2.PlayerItems.Pop();
					Debug.Log ("Player2 has lost an items!");
				}
			}
			Destroy(gameObject);
		}
	}
	
	void Update() {
		speed = 8;
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
