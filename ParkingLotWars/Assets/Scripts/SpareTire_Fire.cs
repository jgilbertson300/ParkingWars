using UnityEngine;
using System.Collections;

public class SpareTire_Fire : MonoBehaviour {

	public GameObject Weapon;
	public GameObject Source;
	GameObject clone;
	int n,i;
	void Start() {
		if (gameObject.name.Contains ("1")) {
			n = 1;
			i = 2;
		}
		if (gameObject.name.Contains ("2")) {
			n = 2;
			i = 1;
		}
		Source = GameObject.Find (string.Format ("Player{0}Source2",n));
		Weapon = Resources.Load ("Weapon_SpareTire", typeof(GameObject)) as GameObject;
	}
	void Update () {
		if (Input.GetButtonDown (string.Format ("Player{0}Fire", n))) {
			clone = Instantiate(Weapon, Source.gameObject.transform.position, Source.transform.rotation) as GameObject;
			clone.name = string.Format("Wpn_SpareTireP{0}", n);
			SpareTire_Collider.target = GameObject.Find (string.Format("Player{0}",i));
			Debug.Log ("SpareTire is live");
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
