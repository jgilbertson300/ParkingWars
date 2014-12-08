using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Backpack_grab : MonoBehaviour
{
	public AudioClip[] sounds;
	int conf = 0;
	GameObject audiosrc;
	void Start(){
				audiosrc = GameObject.Find ("audiosource");
		}
	void OnCollisionEnter2D(Collision2D col) //called when a player(or item with physical collision) hits the backpack
	{
		Debug.Log ("BP picked up by " + col.gameObject.name);
		string tmp = "";	
		Weapon_Select WpnSel = GetComponent ("Weapon_Select") as Weapon_Select;
		tmp = WpnSel.ChooseItem ();
		if (col.gameObject.name == "Player1") {
			Inventory1.PlayerItems.Push (tmp); //Give Player1 an item
			conf = PlayerPrefs.GetInt("Player1Conf");
				AudioSource.PlayClipAtPoint(sounds[conf],audiosrc.transform.position);
		}
		else if (col.gameObject.name == "Player2") {
			Inventory2.PlayerItems.Push (tmp);
			conf = PlayerPrefs.GetInt("Player2Conf");
			AudioSource.PlayClipAtPoint(sounds[conf],audiosrc.transform.position);
		}
		On_Start.BPisLive = false; //This is used to prevent duplicates
		Destroy (gameObject);
	}
}