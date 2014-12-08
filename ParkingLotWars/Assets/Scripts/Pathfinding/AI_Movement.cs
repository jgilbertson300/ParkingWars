using UnityEngine;
using System.Collections;

public class AI_Movement : MonoBehaviour {
	public static GameObject target;
	public float speed;
	GameObject coyote, coyote2, spawn;
	// Use this for initialization
	void Start () {

		coyote = Resources.Load("Coyote_Static", typeof(GameObject)) as GameObject;
		spawn = GameObject.Find ("Spawn_Coyote_Static");
		coyote2 = Instantiate (coyote, spawn.transform.position, spawn.transform.rotation) as GameObject;
		coyote2.name = "Coyote_Static";
		coyote2.SetActive(false);
		target = GameObject.Find ("Coyote_Spawn1");
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name.Contains ("Player")) {

		On_Start.Timer_HazardActive = true;

		if (col.gameObject.name.Contains ("1")) {
			if (Inventory1.PlayerItems.Count != 0) {
					Inventory1.PlayerItems.Pop ();
					Debug.Log ("Player1 has lost an item!");
			}
		}
		if (col.gameObject.name.Contains ("2")) {
			if (Inventory2.PlayerItems.Count != 0) {
					Inventory2.PlayerItems.Pop ();
					Debug.Log ("Player2 has lost an items!");
			}
		}
		Destroy (gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		if(target.name == "Coyote_Spawn5"){
			Destroy(GetComponent("Coyote_Animator"));
			Destroy(gameObject);
			coyote2.SetActive(true);
			On_Start.Timer_HazardActive = true;

		}
		Vector3 dir = -(target.gameObject.transform.position - transform.position);
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		float step = speed * Time.deltaTime; 
		transform.position = Vector3.MoveTowards(transform.position, target.gameObject.transform.position, step); //Move in (speed) meters per second
	}
}
