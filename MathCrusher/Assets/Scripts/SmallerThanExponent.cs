using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SmallerThanExponent : MonoBehaviour {


	public Text summaOnBox;
	public Text Exponent;

	public float summaX;
	public float summaY;
	public float summaBox;
	public float sumBoxToPlayer;
	public float BoxRange;
	public float maxRange;

	public GameObject LessExplode;

	void Start (){
		{

			GameObject thePlayer = GameObject.Find ("Player");
			PlayerMovement playerScript = thePlayer.GetComponent<PlayerMovement> ();
			maxRange = playerScript.summa / 50;

			if (playerScript.summa < 100000) { // 10k-100k

				summaX = Random.Range (4, 8);
				summaY = Random.Range (4, 8);
				summaBox = Mathf.Pow(summaX, summaY); // ger 256 - 823 543
				SetBoxText ();
			}

			if (playerScript.summa > 100000 && playerScript.summa < 1000000 ) { // 100k - 1miljon

				summaX = Random.Range (5, 9);
				summaY = Random.Range (5, 9);
				summaBox = Mathf.Pow(summaX, summaY); // ger 3125 till 16 777 216
				SetBoxText ();
			}

			if (playerScript.summa > 1000000 && playerScript.summa < 800000000 ) { // 1 miljon - 1 miljard
				summaX = Random.Range (7, 10);
				summaY = Random.Range (7, 10);
				summaBox = Mathf.Pow(summaX, summaY); // ger 823 543 till 387 420 489 - om jag går över så spräcker jag BigInt
				SetBoxText ();
			}
			if (playerScript.summa > 800000000) { // över 800milj
				summaX = Random.Range (6, 16);
				summaY = Random.Range (6, 16);
				summaBox = Mathf.Pow(summaX, summaY); // 
				SetBoxText ();
			}

			//  if (playerScript.summa > 1000 000) { 100 milj -> 1 miljard
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
		summaOnBox.text = "<" + summaX.ToString();
		Exponent.text = summaY.ToString ();
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