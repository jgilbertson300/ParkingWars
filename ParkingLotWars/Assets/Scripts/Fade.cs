using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {
	public float duration = 3.0f;
	public SpriteRenderer sprite;
	bool max = false;
	void Update() {
	
		float a = Mathf.PingPong (Time.time / duration, 1.0f);
		sprite.color = new Color(1f, 1f, 1f, a);
		if (a >= .99) {
						max = true;
				}
		if (a <= 0.01 && max == true) {
						Application.LoadLevel (1);
				}
	}
}
