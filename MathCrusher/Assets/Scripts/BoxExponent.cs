using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoxExponent : MonoBehaviour {


	public Text summaOnBox;
	public Text Exponent;

	public int summaX;
	public int summaY;
	public float summaBox;
	public float sumBoxToPlayer;
	public float maxRange;

	public GameObject GreenExplode;

	void Start (){

		GameObject thePlayer = GameObject.Find ("Player");
		PlayerMovement playerScript = thePlayer.GetComponent<PlayerMovement> ();
		maxRange = playerScript.summa / 50;

		if (playerScript.summa < 10000) {

			summaX = Random.Range (1, 5);
			summaY = Random.Range (1, 5);
			summaBox = (int)Mathf.Pow(summaX, summaY);
			SetBoxText ();
		}
		if (playerScript.summa > 10000) {
			summaX = Random.Range (1, 9);
			summaY = Random.Range (1, 9);
			summaBox = (int)Mathf.Pow(summaX, summaY);
			SetBoxText ();
			}

		if (playerScript.summa > 1000000000) {
			summaX = Random.Range (1, 12);
			summaY = Random.Range (1, 12);
			summaBox = Mathf.Pow(summaX, summaY);
			SetBoxText ();
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
		summaOnBox.text = summaX.ToString();
		Exponent.text = summaY.ToString ();
		sumBoxToPlayer = summaBox;
	}
}