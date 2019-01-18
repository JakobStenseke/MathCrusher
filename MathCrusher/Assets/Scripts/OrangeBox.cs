using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OrangeBox : MonoBehaviour {


	public Text summaOnBox;
	public int summaBox;
	public int sumBoxToPlayer;
	public float BoxRange;
	public int maxRange;

	public GameObject OrangeExplode;

	void Start (){

		GameObject thePlayer = GameObject.Find ("Player");
		PlayerMovement playerScript = thePlayer.GetComponent<PlayerMovement> ();


		if (playerScript.summa < 50) {

			summaBox = 2;
			SetBoxText ();
		} 
		else {
			if (playerScript.summa > 1000) {

				summaBox = Random.Range (2, 5);
				SetBoxText ();
			}
			else {
				
				summaBox = Random.Range (2, 4);
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

			Instantiate (OrangeExplode, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		if (other.tag == "Player") {
			Instantiate (OrangeExplode, transform.position, transform.rotation);
		}
	}

	void SetBoxText ()
	{
		summaOnBox.text = "÷" + summaBox.ToString();
		sumBoxToPlayer = summaBox;
	}
}