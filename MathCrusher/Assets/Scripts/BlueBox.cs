using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlueBox : MonoBehaviour {


	public Text summaOnBox;
	public int summaBox;
	public int sumBoxToPlayer;
	public float BoxRange;
	public int maxRange;

	public GameObject BlueExplode;

	void Start (){

		GameObject thePlayer = GameObject.Find ("Player");
		PlayerMovement playerScript = thePlayer.GetComponent<PlayerMovement> ();


		if (playerScript.summa < 500) {

			summaBox = 2;
			SetBoxText ();
		} 
		else {
			summaBox = Random.Range (2, 4);
			SetBoxText ();

			if (playerScript.summa > 10000) {

				summaBox = Random.Range (2, 5);
				SetBoxText ();
			}
			if (playerScript.summa > 10000000) {

				summaBox = 2;
				SetBoxText ();

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

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet") {

			// ev. funktion, t ex. att det sprängs.

			Instantiate (BlueExplode, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		if (other.tag == "Player") {
			Instantiate (BlueExplode, transform.position, transform.rotation);
		}
	}

	void SetBoxText ()
	{
		summaOnBox.text = "×" + summaBox.ToString();
		sumBoxToPlayer = summaBox;
	}
}