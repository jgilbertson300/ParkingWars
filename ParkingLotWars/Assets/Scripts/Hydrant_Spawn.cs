using UnityEngine;
using System.Collections;

public class Hydrant_Spawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject puddle, puddletemp, puddlespawn;
		puddlespawn = GameObject.Find ("Spawn_Puddle");
		puddle = Resources.Load("Puddle", typeof(GameObject)) as GameObject;
		puddletemp = Instantiate (puddle, puddlespawn.transform.position, puddlespawn.transform.rotation) as GameObject;
		puddletemp.name = "Puddle";
	}
}
