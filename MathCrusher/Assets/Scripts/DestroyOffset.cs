using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyOffset : MonoBehaviour {

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
}