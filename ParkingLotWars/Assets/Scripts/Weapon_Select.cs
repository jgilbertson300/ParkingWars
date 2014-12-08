using UnityEngine;
using System.Collections;

public class Weapon_Select : MonoBehaviour {
							//This script is used by Backpack_grab and goal
	public string ChooseItem(){			//It decides what weapon will be given to a player when they pick one up.
		int ItemNum;
		ItemNum = Random.Range (1, 5);
		if (ItemNum == 1) {
			return "Coffee";
		} else if (ItemNum == 2) {
			return "Book";
		} else if (ItemNum == 3) {
			return "StopSign";
		} else if (ItemNum == 4) {
			return "SpareTire";
		}
		else {
			return "Coffee";
		}

	}
}
