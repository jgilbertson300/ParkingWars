using UnityEngine;
using System.Collections;

public class StopSign_Fire : MonoBehaviour {
	public GameObject Weapon;
	public GameObject Source;
	public GameObject Source2;
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
			Source2 = GameObject.Find ("Transform_StopSign"); //Just because it has 0 rotation
			Weapon = Resources.Load ("Weapon_StopSign", typeof(GameObject)) as GameObject;
		}
	void Update () {
		if (Input.GetButtonDown (string.Format ("Player{0}Fire", n))) {
			clone = Instantiate(Weapon, Source.gameObject.transform.position, Source2.transform.rotation) as GameObject;
			clone.name = string.Format("Wpn_StopSignP{0}", n);
			StopSign_Collider.target = GameObject.Find (string.Format("Player{0}",i));
			Debug.Log ("StopSign is live");
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
