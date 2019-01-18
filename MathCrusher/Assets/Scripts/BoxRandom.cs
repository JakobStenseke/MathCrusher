using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoxRandom : MonoBehaviour {


	public Text summaOnBox;
	public float summaBox;
	public float sumBoxToPlayer;
	public float BoxRange;
	public float maxRange;

	public GameObject GreenExplode;

	void Start (){

		GameObject thePlayer = GameObject.Find ("Player");
		PlayerMovement playerScript = thePlayer.GetComponent<PlayerMovement> ();
		maxRange = playerScript.summa / 5;

		if (playerScript.summa < 50) {
			
			summaBox = Random.Range (1, 10);
			int roundedSumma = Mathf.CeilToInt (summaBox);
			summaBox = roundedSumma;
			SetBoxText ();
		} 
		else {
			if (playerScript.summa > 5000) {
				
				summaBox = Random.Range (1, 1000);
				int roundedSumma = Mathf.CeilToInt (summaBox);
				summaBox = roundedSumma;
				SetBoxText ();
			} 
			else {
				

				summaBox = Random.Range (1, maxRange);
				int roundedSumma = Mathf.CeilToInt (summaBox);
				summaBox = roundedSumma;
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

			Instantiate (GreenExplode, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		if (other.tag == "Player") {
			Instantiate (GreenExplode, transform.position, transform.rotation);
		}
	}
		

	void SetBoxText ()
	{
		summaOnBox.text = summaBox.ToString();
		sumBoxToPlayer = summaBox;
	}
}