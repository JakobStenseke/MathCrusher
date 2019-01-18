using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SmallerThan : MonoBehaviour {


	public Text summaOnBox;

	public int summaX;
	public int summaY;
	public int summaBox;
	public int sumBoxToPlayer;
	public float BoxRange;
	public float maxRange;

	public GameObject LessExplode; 

	void Start (){

		GameObject thePlayer = GameObject.Find ("Player");
		PlayerMovement playerScript = thePlayer.GetComponent<PlayerMovement> ();
		maxRange = playerScript.summa / 30;

		if (playerScript.TutorialMode == true) {
			summaX = Random.Range (10, 30);
			summaY = Random.Range (10, 30);
			summaBox = summaX * summaY;  // 
			SetBoxText ();

		}

		if (playerScript.TutorialMode == false) {

			if (playerScript.summa < 500) { //0-500 -- max borde vara 1000, minsta 0

				summaX = Random.Range (1, 30);
				summaY = Random.Range (1, 30);
				summaBox = summaX * summaY;  // 
				SetBoxText ();

			}
			if (playerScript.summa > 500 && playerScript.summa < 1000) { //500-1000 -- max borde vara 1500, minsta 250

				summaX = Random.Range (10, 54); // t ex. mitten 
				summaY = Random.Range (10, 54);
				summaBox = summaX * summaY;  // max borde vara 1500, minsta 
				SetBoxText ();

			}



			if (playerScript.summa > 1000 && playerScript.summa < 5000) { // 1000-5000 -- max 7500, minsta 500

				summaX = Random.Range (20, 85); // t ex. mitten 
				summaY = Random.Range (20, 85);
				summaBox = summaX * summaY;  // max borde vara 1500, minsta 
				SetBoxText ();


			}


			if (playerScript.summa > 5000) { // 5000-10 000 -- max 9800, minsta 2500
				summaX = Random.Range (50, 100);
				summaY = Random.Range (50, 100);
				summaBox = summaX * summaY;
				SetBoxText ();

				// player score 
			} 

		}
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


	void SetBoxText ()
	{
		summaOnBox.text = "<" + summaX + "×" + summaY.ToString();
		sumBoxToPlayer = summaBox;
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet") {

			// ev. funktion, t ex. att det sprängs.

			Instantiate (LessExplode, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		if (other.tag == "Player") {
			Instantiate (LessExplode, transform.position, transform.rotation);
		}
	}
}