using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BiggerThan : MonoBehaviour {


	public Text summaOnBox;

	public int summaX;
	public int summaY;
	public int summaBox;
	public int sumBoxToPlayer;
	public float BoxRange;
	public float maxRange;


	public GameObject BigExplode;

	void Start (){

		GameObject thePlayer = GameObject.Find ("Player");
		PlayerMovement playerScript = thePlayer.GetComponent<PlayerMovement> ();
		maxRange = playerScript.summa / 30;

		// är med i epok 0 (0-1000), epok 1 (1000-10000), bort från epok 2 då 99x99 < 10k

		if (playerScript.TutorialMode == true) {

			summaX = Random.Range (1, 9);
			summaY = Random.Range (1, 9);
			summaBox = summaX * summaY;  // 
			SetBoxText ();
		}

		if (playerScript.TutorialMode == false) {

			if (playerScript.summa < 500) { //0-500 -- max borde vara 400, minsta 0

				summaX = Random.Range (1, 20);
				summaY = Random.Range (1, 20);
				summaBox = summaX * summaY;  // 
				SetBoxText ();

			}
			if (playerScript.summa > 500 && playerScript.summa < 1000) { //500-1000

				summaX = Random.Range (20, 30);
				summaY = Random.Range (20, 30);
				summaBox = summaX * summaY;
				SetBoxText ();

			}



			if (playerScript.summa > 1000 && playerScript.summa < 5000) { // 1000-5000 

				summaX = Random.Range (30, 85);
				summaY = Random.Range (30, 85);
				summaBox = summaX * summaY;
				SetBoxText ();
			}


			if (playerScript.summa > 5000) { // 5000-10 000
				summaX = Random.Range (70, 100);
				summaY = Random.Range (70, 100);
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
		summaOnBox.text = ">" + summaX + "×" + summaY.ToString();
		sumBoxToPlayer = summaBox;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet") {

			// ev. funktion, t ex. att det sprängs.

			Instantiate (BigExplode, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		if (other.tag == "Player") {
			Instantiate (BigExplode, transform.position, transform.rotation);
		}
	}
}