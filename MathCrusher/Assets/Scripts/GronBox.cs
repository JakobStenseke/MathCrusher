using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GronBox : MonoBehaviour {

	public GameObject WhiteExplode;

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