using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingTextScript : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Start () {

		text = GetComponent<Text> ();
		StartBlinking ();

	}

	IEnumerator Blink()
	{
		while (true) {
			switch (text.color.a.ToString ()) {
			case "0":
				text.color = new Color (text.color.r, text.color.g, text.color.b, 1);
				yield return new WaitForSeconds (0.5f);
				break;
			case "1":
				text.color = new Color (text.color.r, text.color.g, text.color.b, 0);
				yield return new WaitForSeconds (0.5f);
				break;
			}
		}
	}
	void StartBlinking(){
		StopCoroutine ("Blink");
		StartCoroutine ("Blink");
	}

	void StopBlinking()
	{
		StopCoroutine ("Blink");
	}
}
