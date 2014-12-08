using UnityEngine;
using System.Collections;

public class Player_Inputs : MonoBehaviour {

	// set player number(either 1 or 2)
	//this is done in the On_Start script
	//this script is needed for the controller scripts for each car
	public int playerNumber;
	
	// get X axis from -1 to +1
	public float x {
		get {
			return Input.GetAxis(string.Format("Player{0}X", playerNumber));
		}
	}
	
	// get raw X axis from -1 to +1
	public float rawX {
		get {
			return Input.GetAxisRaw(string.Format("Player{0}X", playerNumber));
		}
	}
	
	// get Y axis from -1 to +1
	public float y {
		get {
			return Input.GetAxis(string.Format("Player{0}Y", playerNumber));
		}
	}
	
	// get raw Y axis from -1 to +1
	public float rawY {
		get {
			return Input.GetAxisRaw(string.Format("Player{0}Y", playerNumber));
		}
	}
	
	// true if fire button (1 or 2) is currently held
	public bool GetFireButton(int n) {
		return Input.GetButton(string.Format("Player{0}Fire{1}", playerNumber, n));
	}
	
	// true if fire button (1 or 2) is down this frame
	public bool GetFireButtonDown(int n) {
		return Input.GetButtonDown(string.Format("Player{0}Fire{1}", playerNumber, n));
	}
}
