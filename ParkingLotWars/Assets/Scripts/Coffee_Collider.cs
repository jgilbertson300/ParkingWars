using UnityEngine;
using System.Collections;

public class Coffee_Collider : MonoBehaviour {
	public static string Source;
	int timer = 0;
	int n;
	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.name.Contains("Trigger") == false){
			if (col.gameObject.name != Source){
				Debug.Log ("Coffee collided with " + col.gameObject.name);
				if(col.gameObject.name.Contains("Player")) {
					GameObject spwn;
					if(col.gameObject.name.Contains("1")) {
						n = 1;
					}
					if(col.gameObject.name.Contains("2")) {
						n = 2;
					}
					string tmp;
					tmp = string.Format("Spawn_P{0}", n);
					spwn = GameObject.Find (tmp);
					col.audio.Play ();
					col.transform.position = spwn.transform.position;
					col.transform.rotation = spwn.transform.rotation;
				}
				Destroy (gameObject);
			}
		}
	}
	void Update() {
		timer++;
		if (timer >= 500) {
				Destroy (gameObject);
		}
	}
}
