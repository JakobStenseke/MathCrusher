using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Surprise : MonoBehaviour {


	public float summa1;
	public float summa2;
	public float summa3;
	public float summaBox;

	public float sumBoxToPlayer;

	public GameObject WhiteExplode;


	void Start (){

		GameObject thePlayer = GameObject.Find ("Player");
		PlayerMovement playerScript = thePlayer.GetComponent<PlayerMovement> ();


		if (Random.value < 0.5f) {

			summaBox = playerScript.summa * 2;

		} else {

			summaBox = playerScript.summa / 4;
		}



		//summa1 = Random.Range (playerScript.summa, (playerScript.summa * 2));  // borde vara mellan summan och dubbla summan
		//summa2 = Random.Range (playerScript.summa - (playerScript.summa * 4), 0);  // borde vara mellan minus summan och noll

		//summaBox = Random.Range (summa1, summa2);

		}
		
	void Update () {


		// Get enemy current position
		Vector2 position = transform.position;
		// Update the enemy position
		transform.position = position;

		// This is the bottom-left point of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		// If enemy goes outside the bottom screen, destroy it
		if(transform.position.y < min.y) 
		{
			Invoke ("DestroyBox", 0.5f);
		}
	}

	void DestroyBox (){
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet") {

			// ev. funktion, t ex. att det sprängs.

			Instantiate (WhiteExplode, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		if (other.tag == "Player") {
			Instantiate (WhiteExplode, transform.position, transform.rotation);
		}
	}
		
}