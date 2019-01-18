using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoxMultiply : MonoBehaviour {


	public Text summaOnBox;

	public float summaX;
	public float summaY;
	public float summaBox;
	public float sumBoxToPlayer;
	public float BoxRange;
	public float maxRange;

	public GameObject GreenExplode;

	void Start (){

		GameObject thePlayer = GameObject.Find ("Player");
		PlayerMovement playerScript = thePlayer.GetComponent<PlayerMovement> ();
		maxRange = playerScript.summa / 50;

		if (playerScript.summa < 500) {

			summaX = Random.Range (1, 10);
			summaY = Random.Range (1, 10);
			summaBox = summaX * summaY;

			SetBoxText ();
		}
		else {
			if (playerScript.summa > 5000) {
				
				summaX = Random.Range (1, 100);
				summaY = Random.Range (1, 100);
				summaBox = summaX * summaY;
				SetBoxText ();
			} 
			else {
				summaX = Random.Range (1, maxRange);
				summaY = Random.Range (1, maxRange);

				int roundedSummaX = Mathf.CeilToInt (summaX);
				summaX = roundedSummaX;

				int roundedSummaY = Mathf.CeilToInt (summaY);
				summaY = roundedSummaY;

				summaBox = summaX * summaY;

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
		summaOnBox.text = summaX + "×" + summaY.ToString();
		sumBoxToPlayer = summaBox;
	}
}