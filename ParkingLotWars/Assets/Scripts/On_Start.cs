using UnityEngine;
using System.Collections;
									//this is the brain of the game. Most of the important stuff happens in here
public class On_Start : MonoBehaviour {		
	//Spawn locations
	public Transform SpawnP1;
	public Transform SpawnP2;
	public Transform SpawnStudent;
	public Transform SpawnHydrant;
	public Transform SpawnCoyote;

	//The objects that will be made(most are chosen from resources.load for now)
	public GameObject Player1Car;
	public GameObject Player2Car;
	public GameObject Hazard;
	public GameObject StudentTarget;
	public GameObject Backpack;
	public GameObject Goal;
	public GameObject CarGoal;
	public GameObject SpawnBP;
	GameObject NPC;
	GameObject SpawnNPC;
	GameObject BP;
	GameObject P1, P2;

	string Player1Choice;
	string Player2Choice;

	//The time is takes the Backpack to spawn.
	public float Timer_Items = 10.0f;

	//The time is takes for a hazard to appear(anywhere from 10 to 30 seconds)
	public float Timer_Hazard;
	int Haz_Index;
	int Puddlenumber = 1;
	public static int Count1 = 0;
	int Count2 = 0;

	public string Car_NPC = "";

	bool Timer_ItemsActive = true;
	public static bool Timer_HazardActive;

	public static bool BPisLive;
	

	void Reset() { //Called when a player parks.
		P1.transform.position = SpawnP1.transform.position;
		P1.transform.rotation = SpawnP1.transform.rotation;
		P2.transform.position = SpawnP2.transform.position;
		P2.transform.rotation = SpawnP2.transform.rotation; 
		CarGoal.SetActive (true);
		Car_NPC = string.Format ("Car_NPC{0}", Random.Range (1, 58));
		CarGoal = GameObject.Find (Car_NPC);
		Timer_Items = 10.0f;
		Timer_ItemsActive = true;
		Destroy (BP);
	}
	void Timer_ItemsEnd(){
		GameObject Goal_Live;
		int BPSpawn = Random.Range (1, 5);
		SpawnBP = GameObject.Find (string.Format ("Spawn_BP{0}", BPSpawn));
		BP = Instantiate (Backpack, SpawnBP.transform.position, SpawnBP.transform.rotation) as GameObject;
		BP.name = "Backpack";
		BPisLive = true;
		Debug.Log ("Backpack is live!");
		Goal_Live = Instantiate (Goal, CarGoal.transform.position, BP.transform.rotation) as GameObject;
		Goal_Live.name = "Goal";
		CarGoal.SetActive (false);
	}
	void Timer_HazardEnd() {
		GameObject Haz, puddle, puddletemp, puddlespawn;

		if (Haz_Index == 1) {
				Hazard = Resources.Load ("Student", typeof(GameObject)) as GameObject; 
				Haz = Instantiate (Hazard, SpawnStudent.position, SpawnStudent.rotation) as GameObject;
				Haz.name = "Student";
				Student_Collider.target = StudentTarget.transform;
				//Haz_Index = Random.Range (2, 4);
		} else if (Haz_Index == 2) {
				if (GameObject.Find ("Puddle")) {
					Debug.Log ("Both puddles already out. restarting timer.");
					Timer_Hazard = Random.Range (10.0f, 30.0f);
					Timer_HazardActive = true;
					return;
				}
				puddlespawn = GameObject.Find ("Spawn_Puddle");
				puddle = Resources.Load ("Puddle", typeof(GameObject)) as GameObject;
				puddletemp = Instantiate (puddle, puddlespawn.transform.position, puddlespawn.transform.rotation) as GameObject;
				puddletemp.name = "Puddle";
				Puddlenumber++;
				Haz_Index = 1;
		} else if (Haz_Index == 3) {
			if (GameObject.Find ("Coyote_Static")) {
				Debug.Log ("Coyote is already out. restarting timer.");
				Timer_Hazard = Random.Range (10.0f, 30.0f);
				Haz_Index = Random.Range (1, 3);
				Timer_HazardActive = true;
				return;
			}
			Hazard = Resources.Load ("Coyote",typeof(GameObject)) as GameObject;
			Haz = Instantiate (Hazard, SpawnCoyote.position, SpawnCoyote.rotation) as GameObject;
			Haz.name = "Coyote";
			Haz_Index = 2;
		}
		Timer_Hazard = Random.Range (10.0f, 30.0f);
	}
	void NPC_Spawn() {
		string NPC_Name = "";
		string Spawn_Name = "";
		int j;
		GameObject NPCTemp;
		for(int num = 1;num<62;num++) {
			j = Random.Range (1, 5);
			NPC_Name = string.Format("Car_NPC{0}", j);
			Spawn_Name = string.Format ("Spawn_NPC{0}", num);
			NPC = Resources.Load (NPC_Name, typeof(GameObject)) as GameObject; 
			SpawnNPC = GameObject.Find(Spawn_Name);
			NPCTemp = Instantiate (NPC, SpawnNPC.transform.position, SpawnNPC.transform.rotation) as GameObject;
			NPCTemp.name = string.Format("Car_NPC{0}", num);
		}
	}
	void Start () {
		GameObject music;
		music = GameObject.Find ("Main_Music");
		Destroy (music);
		GameObject P1Source1, P1Source2, P2Source1, P2Source2;
						//load all the prefabs into their proper GameObjects
		Player1Choice = PlayerPrefs.GetString ("Player1Choice");
		Player2Choice = PlayerPrefs.GetString ("Player2Choice");
		Player1Car = Resources.Load (Player1Choice, typeof(GameObject)) as GameObject; 
		Player2Car = Resources.Load (Player2Choice, typeof(GameObject)) as GameObject;
		//Hazard = Resources.Load ("Student", typeof(GameObject)) as GameObject; 			
		Backpack = Resources.Load ("Backpack", typeof(GameObject)) as GameObject;
		Goal = Resources.Load ("Goal", typeof(GameObject)) as GameObject;
		NPC_Spawn ();
						//Choose a random parked car to disappear where the parking spot will be
		Car_NPC = string.Format ("Car_NPC{0}", Random.Range (1, 58));
		CarGoal = GameObject.Find (Car_NPC);

		BPisLive = false;
						//Choose a random time for the Hazard to appear
		Timer_Hazard = Random.Range (10.0f, 30.0f);
		Timer_HazardActive = true;
		Haz_Index = 3;
		//Haz_Index = Random.Range (1, 4);
						//Spawn vehicles and attach the proper scripts
		P1 = Instantiate (Player1Car, SpawnP1.position, SpawnP1.rotation) as GameObject;
		P1.name = "Player1";
		P1.AddComponent ("Player_Inputs");
		Player_Inputs P1Input = P1.GetComponent ("Player_Inputs") as Player_Inputs;
		P1Input.playerNumber = 1;
		P1Source1 = GameObject.Find (PlayerPrefs.GetString ("Player1Source"));
		P1Source1.name = "Player1Source";
		P1Source2 = GameObject.Find (PlayerPrefs.GetString ("Player1Source2"));
		P1Source2.name = "Player1Source2";
		P2 = Instantiate (Player2Car, SpawnP2.position, SpawnP2.rotation) as GameObject;
		P2.name = "Player2";
		P2.AddComponent ("Player_Inputs");
		Player_Inputs P2Input = P2.GetComponent ("Player_Inputs") as Player_Inputs;
		P2Input.playerNumber = 2;
		P2Source1 = GameObject.Find (PlayerPrefs.GetString ("Player2Source"));
		P2Source1.name = "Player2Source";
		P2Source2 = GameObject.Find (PlayerPrefs.GetString ("Player2Source2"));
		P2Source2.name = "Player2Source2";
	
	}

	void Update() { 
		if(Timer_ItemsActive == true) {
			Timer_Items -= Time.deltaTime;
		}
		if (Timer_HazardActive == true) {
			Timer_Hazard -= Time.deltaTime;
		}

		if (Timer_Items <= 0.0f && Timer_ItemsActive == true) {
				Timer_ItemsEnd ();
				Timer_ItemsActive = false;
		}
		if (Timer_Hazard <= 0.0f && Timer_HazardActive == true) {
				Timer_HazardEnd();
				Timer_HazardActive = false;
		}
		if (Count1 > Count2) {
			Count2++;
			Reset ();
		}
	} 
}
