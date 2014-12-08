using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
						//called once a player parks
	public AudioClip[] sounds;
	int conf = 0;
	GameObject audiosrc;
	void Start(){
		audiosrc = GameObject.Find ("audiosource");
	}
	void OnTriggerEnter2D (Collider2D other) {
		string tmp;
		Weapon_Select WpnSel = GetComponent ("Weapon_Select") as Weapon_Select;
		tmp = WpnSel.ChooseItem ();
		if (other.gameObject.name == "Player1") {
				Inventory1.PlayerItems.Push (tmp);
				conf = PlayerPrefs.GetInt("Player1Conf");
			AudioSource.PlayClipAtPoint(sounds[conf],audiosrc.transform.position);
				
		} else if(other.gameObject.name == "Player2") {
				Inventory2.PlayerItems.Push (tmp);
				conf = PlayerPrefs.GetInt("Player2Conf");
			AudioSource.PlayClipAtPoint(sounds[conf],audiosrc.transform.position);
		}
		On_Start.Count1++;
		Destroy (gameObject);
	}
}