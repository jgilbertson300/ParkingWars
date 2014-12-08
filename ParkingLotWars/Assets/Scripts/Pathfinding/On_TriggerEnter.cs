using UnityEngine;
using System.Collections;

public class On_TriggerEnter : MonoBehaviour {
	public GameObject next;
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "Coyote") {
			AI_Movement.target = next;
			}
	}
}
