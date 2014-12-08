using UnityEngine;
using System.Collections;
using System.Collections.Generic;
						//this dense script controls the inventory. It has a stack of strings which hold names for the items
public class Inventory1 : MonoBehaviour {
	
	public static Stack<string> PlayerItems = new Stack<string> ();
	
	public Transform Space1Pos, Space2Pos;
	
	public GameObject Coffee, Book, StopSign, SpareTire;
	
	public GameObject Item1, Item2;
	
	public static bool Space1Filled;
	bool Space2Filled;
	
	GameObject Wep1;
	
	string Wep1Name, Wep2Name, Wep1Fire;
	string item;
	void WhichWeapon() {
		item = PlayerItems.Peek ();
		if (item == "Coffee") {
			Wep1 = Coffee;
			Wep1Name = "CoffeeP1";
			Wep1Fire = "Coffee_Fire";
		} else if (item == "Book") {
			Wep1 = Book;
			Wep1Name = "BookP1";
			Wep1Fire = "Book_Fire";
		} else if (item == "StopSign") {
			Wep1 = StopSign;
			Wep1Name = "StopSignP1";
			Wep1Fire = "StopSign_Fire";
		}
		else if(item == "SpareTire"){
			Wep1 = SpareTire;
			Wep1Name = "SpareTireP1";
			Wep1Fire = "SpareTire_Fire";
		}
	}
	
	void Start() {
		PlayerItems.Clear();
		Space1Filled = false;
		Space2Filled = false;
	}
	
	void Update() {
		if (PlayerItems.Count == 0) {//does the player have no items? Destroy both icons and free up Space1 and Space2.
			Destroy (Item1);
			Destroy (Item2);
			Destroy(GetComponent(Wep1Fire));
			Space1Filled = false;
			Space2Filled = false;
		}
		if(PlayerItems.Count == 1 && Space1Filled == false ) { //does Player have one item? If so create an icon for it
			WhichWeapon();											// and load the fire script
			Item1 = Instantiate(Wep1, Space1Pos.position, Space1Pos.rotation) as GameObject;
			Item1.gameObject.name = Wep1Name;
			Space1Filled = true;
			gameObject.AddComponent(Wep1Fire);
			Debug.Log ("Player1 now has " + item);
		}
		if(PlayerItems.Count == 2 && Space2Filled == false ) { //does player have two items but no icon for item2? 
			Destroy (Item1);											//If so Destroy the icon and script for item1 and move the icon 
			Destroy(GetComponent(Wep1Fire));									//into space2. Then load the icon
			Item2 = Instantiate(Wep1, Space2Pos.position, Space2Pos.rotation) as GameObject; //and script for the weapon in the front  
			Item2.gameObject.name = Wep1Name; 													//of the stack.
			WhichWeapon();										
			Item1 = Instantiate(Wep1, Space1Pos.position, Space1Pos.rotation) as GameObject;
			Item1.gameObject.name = Wep1Name;
			Space2Filled = true;
			gameObject.AddComponent(Wep1Fire);
			Debug.Log ("Player1 now has " + item);
		}

		if(PlayerItems.Count == 1 && Space2Filled == true ){ //Did player use/lose an item while still having another? If so											
			Destroy (Item1);									//remove both icons from toolbox and remove the fire script.
			Destroy (Item2);										//Then in the next frame load the icon and script for 
			Destroy(GetComponent(Wep1Fire));							//the weapon now in the front of the stack.
			Space1Filled = false;
			Space2Filled = false;
		}
		if (PlayerItems.Count == 3) {
			Debug.Log ("Player1 Wins!!");
			Application.LoadLevel("Win_Screen");
		}
	}
}
