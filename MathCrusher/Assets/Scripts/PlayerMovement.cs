using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class PlayerMovement : MonoBehaviour {

	public float summa = 1;
	public float currenthighest;

	public bool ReverseMode;
	public bool InfinityMode;
	public int InfinityTimer;
	public int ReverseTimer;
	public int RandomTimer;

	public int NewExperience;
	public Text NewExperienceText;
	public Text LevelUpText;
	public Text DeathExplanation;

	private float lane;
	public float speed = 5f;
	public float acceleration = 3.0f;
	public float maxSpeed = 60.0f;

	public float LoadBullet;
	public Image LoadingBar;
	public Image GigaBar;

	public GameObject PlayerBullet;
	public GameObject bulletPosition;

	public Text summaText;
	public Text CurrentHighest;
	public Text highScoreText;
	public GameObject NewHighScoreText;

	private int dividedBy;

	public GameObject ScoreText;
	public GameObject DeadScore;
	public GameObject Spawners;
	public GameObject Reverse;
	public GameObject Infinity;
	public GameObject HowToPlay;

	private int desiredWidth = Screen.width / 3;
	//private int desiredHeight = Screen.height / 2;

	private bool tenK = false;
	private bool hundredK = false;
	private bool fivehundredK = false;
	private bool onemillionK = false;
	private bool onehundredmillionK = false;
	private bool fivehundredmillionK = false;
	private bool billion = false;
	private bool trillion = false;

	public AudioClip GreenSFX;
	public AudioClip RedSFX;
	public AudioClip BlueSFX;
	public AudioClip BigSmallSFX;
	public AudioClip OrangeSFX;
	public AudioClip SurpriseSFX;
	public AudioClip ReverseSFX;
	public AudioClip DeadSFX;

	private AudioSource source;
	public bool TutorialMode;


	// för att swipa uppåt
	private Vector2 fp; // first finger position
	private Vector2 lp; // last finger position
	private float angle;
	//private float swipeDistanceX;
	private float swipeDistanceY;

	public GameObject Skin1;
	public GameObject Skin2;
	public GameObject Skin3;
	public GameObject Skin4;
	public GameObject Skin5;
	public GameObject Skin6;
	public GameObject Skin7;

	public GameObject GunIsReady;
	public bool GunHasBeenShown;


	void Start () {


		//SpriteRenderer renderer = GetComponent<SpriteRenderer> ();

		Scene scene = SceneManager.GetActiveScene();
		if (scene.name == "Tutorial") {
			TutorialMode = true;
			speed = 1.8f;
		}

		if (scene.name == "MainScene") {
			TutorialMode = false;
			speed = PlayerPrefs.GetFloat ("Speed");
		}

		source = GetComponent<AudioSource> ();
		AudioListener.volume = PlayerPrefs.GetInt ("Sound");

		lane = 0;
		ReverseMode = false;
		InfinityMode = false;
		GunHasBeenShown = false;


		if (PlayerPrefs.GetInt ("Skin") == 1) {
			Skin1.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("Skin") == 2) {
			Skin2.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("Skin") == 3) {
			Skin3.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("Skin") == 4) {
			Skin4.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("Skin") == 5) {
			Skin5.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("Skin") == 6) {
			Skin6.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("Skin") == 7) {
			Skin7.SetActive (true);
		}


		//speed = PlayerPrefs.GetFloat ("Speed");
	
		SetCountText ();

		//float totalexp = PlayerPrefs.GetFloat ("TotalExperience");
		//if (totalexp > 100) {
		//	HowToPlay.SetActive (false);
		//}
	}

	void Update () {

		//TESTA SHOOT
		if (Input.GetKeyDown (KeyCode.Space)) {

			GameObject bullet01 = (GameObject)Instantiate (PlayerBullet);
			bullet01.transform.position = bulletPosition.transform.position;
			LoadingBar.fillAmount = 0;
			GunHasBeenShown = false;
			GunIsReady.SetActive(false);
		}
		//TESTA SHOOT

		transform.Translate (0, speed * Time.deltaTime, 0);
		// HÄN MAN REFERERA SUMMAN LivesUIText.text = summa.ToString();


		speed += acceleration;

		if (speed > maxSpeed)
			speed = maxSpeed;
		
		if (Input.touchCount == 1) {
			foreach (Touch touch in Input.touches) {
				//For left half screen


				if (touch.position.x < desiredWidth) {
					// MOVE LEFT FUNCTON

					if (ReverseMode == false) {
						if (lane > -1.5)
							lane = lane - 1.5f;
					} else {
						if (lane < 1.5)
							lane = lane + 1.5f;
					}
				}
				if (touch.position.x > desiredWidth) {


					// MOVE LEFT FUNCTION

					if (ReverseMode == false) {
						if (lane < 1.5)
							lane = lane + 1.5f;
					} else {
						if (lane > -1.5)
							lane = lane - 1.5f;
					}
				}


				if (touch.position.x >= desiredWidth && touch.position.x < 2 * desiredWidth) {


					lane = 0;


				}

				Vector3 newPosition = transform.position;
				newPosition.x = lane;
				transform.position = newPosition;

				if (touch.phase == TouchPhase.Began) {

					fp = touch.position;
					lp = touch.position;
				}

				if (touch.phase == TouchPhase.Moved) {
					lp = touch.position;
					//swipeDistanceX = Mathf.Abs ((lp.x - fp.x));
					swipeDistanceY = Mathf.Abs ((lp.y - fp.y));
				}

				if (touch.phase == TouchPhase.Ended) {
					angle = Mathf.Atan2 ((lp.x - fp.x), (lp.y - fp.y)) * 57.2957795f;

					if (angle > -30 && angle < 30 && swipeDistanceY > 40) { // UP SHOOT

						if (LoadingBar.fillAmount == 1) {

							GameObject bullet01 = (GameObject)Instantiate (PlayerBullet);
							bullet01.transform.position = bulletPosition.transform.position;  //set the bullet initial position
							LoadingBar.fillAmount = 0;
							GunHasBeenShown = false;
							GunIsReady.SetActive(false);
						}
					}
				}
			}
		}
	}
					
				// OLD SHOOT:
				//	if  (touch.position.y > desiredHeight) {
				//
					
				//	if (LoadingBar.fillAmount == 1) {

				//		GameObject bullet01 = (GameObject)Instantiate (PlayerBullet);
				//		bullet01.transform.position = bulletPosition.transform.position;  //set the bullet initial position
				//		LoadingBar.fillAmount = 0;
				//	}
						

	void OnTriggerEnter2D(Collider2D other)
	{



		if (TutorialMode == false) {

			NewExperience += 5;

			if (LoadingBar.fillAmount == 1 && GunHasBeenShown == false) {

				GunIsReady.SetActive(true);
				GunHasBeenShown = true;
				Invoke ("SetOff", 2f);
			}
		}

		//if (NewExperience > 14) {
		//	HowToPlay.SetActive (false);
		//}


		if (other.gameObject.tag == "Surprise")
		{

			if (InfinityMode == false) {

				//if (TutorialMode == false) {

					//Surprise randomBox = other.gameObject.GetComponent<Surprise> ();

					//summa = summa + randomBox.summaBox;
					//summa = randomBox.summaBox;

				//} else {
				//	summa = summa + Random.Range (1, 100);
				//}

				if (Random.value < 0.5f) {

					summa = summa * 2;

				} else {

					summa = summa / 4;
				}

			}

			if (LoadingBar.fillAmount <= 1) {
				LoadingBar.fillAmount += 0.05f;
			}

			PlayerPrefs.SetInt("TotalSurprise", PlayerPrefs.GetInt("TotalSurprise")+1);
			source.PlayOneShot (SurpriseSFX, 0.7F);
			SetCountText ();
			Destroy (other.gameObject);
		}


		if (other.gameObject.tag == "GronRandom")
		{

			BoxRandom randomBox = other.gameObject.GetComponent<BoxRandom>();

			summa = summa + randomBox.summaBox;

			if (LoadingBar.fillAmount <= 1) {
				LoadingBar.fillAmount += 0.05f;
			}

			PlayerPrefs.SetInt("TotalGreen", PlayerPrefs.GetInt("TotalGreen")+1);
			source.PlayOneShot (GreenSFX, 0.7F);
			SetCountText ();
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "GreenPlus")
		{

			BoxPlus randomBox = other.gameObject.GetComponent<BoxPlus>();

			summa = summa + randomBox.summaBox;

			if (LoadingBar.fillAmount <= 1) {
				LoadingBar.fillAmount += 0.05f;
			}

			PlayerPrefs.SetInt("TotalGreen", PlayerPrefs.GetInt("TotalGreen")+1);
			source.PlayOneShot (GreenSFX, 0.7F);
			SetCountText ();
			Destroy (other.gameObject);
		}


		if (other.gameObject.tag == "GreenMultiply")
		{

			BoxMultiply randomBox = other.gameObject.GetComponent<BoxMultiply>();

			summa = summa + randomBox.summaBox;

			if (LoadingBar.fillAmount <= 1) {
				LoadingBar.fillAmount += 0.05f;
			}

			PlayerPrefs.SetInt("TotalGreen", PlayerPrefs.GetInt("TotalGreen")+1);
			source.PlayOneShot (GreenSFX, 0.7F);
			SetCountText ();
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "GreenExponent")
		{

			BoxExponent randomBox = other.gameObject.GetComponent<BoxExponent>();
			summa = summa + randomBox.summaBox;

			if (LoadingBar.fillAmount <= 1) {
				LoadingBar.fillAmount += 0.05f;
			}

			PlayerPrefs.SetInt("TotalGreen", PlayerPrefs.GetInt("TotalGreen")+1);
			source.PlayOneShot (GreenSFX, 0.7F);
			SetCountText ();
			Destroy (other.gameObject);
		}


		if (other.gameObject.tag == "RodRandom")
		{

			if (InfinityMode == false) {

				BoxRandom randomBox = other.gameObject.GetComponent<BoxRandom> ();
				float sumBeforeDeath = summa;
				summa = summa - randomBox.summaBox;
				if (summa < 0) {
					DeathExplanation.text = sumBeforeDeath + " - " + randomBox.summaBox + " = " + summa.ToString ();
				}
			}    
			else {
				BoxRandom randomBox = other.gameObject.GetComponent<BoxRandom> ();
				summa = summa + randomBox.summaBox;
			}

			if (LoadingBar.fillAmount <= 1) {
				LoadingBar.fillAmount += 0.05f;
			}

			PlayerPrefs.SetInt("TotalRed", PlayerPrefs.GetInt("TotalRed")+1);
			source.PlayOneShot (RedSFX, 0.7F);
			SetCountText ();
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "RedPlus")
		{

			if (InfinityMode == false) {

				BoxPlus randomBox = other.gameObject.GetComponent<BoxPlus> ();
				float sumBeforeDeath = summa;
				summa = summa - randomBox.summaBox;
				if (summa < 0) {
					DeathExplanation.text = sumBeforeDeath + " - (" + randomBox.summaX + "+" + randomBox.summaY + ") = " + summa.ToString ();
				}
			}    
			else {
				BoxPlus randomBox = other.gameObject.GetComponent<BoxPlus> ();
				summa = summa + randomBox.summaBox;
			}

			if (LoadingBar.fillAmount <= 1) {
				LoadingBar.fillAmount += 0.05f;
			}

			PlayerPrefs.SetInt("TotalRed", PlayerPrefs.GetInt("TotalRed")+1);
			source.PlayOneShot (RedSFX, 0.7F);
			SetCountText ();
			Destroy (other.gameObject);
		}


		if (other.gameObject.tag == "RedMultiply")
		{

			if (InfinityMode == false) {

				BoxMultiply randomBox = other.gameObject.GetComponent<BoxMultiply> ();
				float sumBeforeDeath = summa;
				summa = summa - randomBox.summaBox;
				if (summa < 0) {
					DeathExplanation.text = sumBeforeDeath + " - (" + randomBox.summaX + "×" + randomBox.summaY + ") = " + summa.ToString ();
					// här behövs ingen särskild formatering då max är 99x99
				}

			}
			else {
				BoxMultiply randomBox = other.gameObject.GetComponent<BoxMultiply> ();
				summa = summa + randomBox.summaBox;
			}

			if (LoadingBar.fillAmount <= 1) {
				LoadingBar.fillAmount += 0.05f;
			}

			PlayerPrefs.SetInt("TotalRed", PlayerPrefs.GetInt("TotalRed")+1);
			source.PlayOneShot (RedSFX, 0.7F);
			SetCountText ();
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "RedExponent")
		{

			if (InfinityMode == false) {

				BoxExponent randomBox = other.gameObject.GetComponent<BoxExponent> ();
				float sumBeforeDeath = summa;
				summa = summa - randomBox.summaBox;
				if (summa < 0) {
					if (sumBeforeDeath < 1000000) {
						DeathExplanation.text = sumBeforeDeath + " - (" + randomBox.summaX + "^" + randomBox.summaY + ") = " + summa.ToString ();
					} else {
						DeathExplanation.text = (sumBeforeDeath / 1000000).ToString ("0.###") + "M" + " - (" + randomBox.summaX + "^" + randomBox.summaY + ") = " + (summa / 1000000).ToString ("0.###") + "M";
					}
				}
			}
			else {
				BoxExponent randomBox = other.gameObject.GetComponent<BoxExponent> ();
				summa = summa + randomBox.summaBox;
			}

			if (LoadingBar.fillAmount <= 1) {
				LoadingBar.fillAmount += 0.05f;
			}

			PlayerPrefs.SetInt("TotalRed", PlayerPrefs.GetInt("TotalRed")+1);
			source.PlayOneShot (RedSFX, 0.7F);
			SetCountText ();
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "OrangeRandom") 
		{

			if (InfinityMode == false) {

				OrangeBox randomBox = other.gameObject.GetComponent<OrangeBox> ();
				dividedBy = randomBox.summaBox;

				// if (summa % dividedBy == 0) { //om det älbart med summan påen
					summa = summa / dividedBy; //dividera med summan påen

			//	}    else {
				//	toMenu ();
			//	}
			}

			if (LoadingBar.fillAmount <= 1) {
				LoadingBar.fillAmount += 0.05f;
			}

			PlayerPrefs.SetInt("TotalOrange", PlayerPrefs.GetInt("TotalOrange")+1);
			Destroy (other.gameObject);
			source.PlayOneShot (OrangeSFX, 0.7F);
			SetCountText ();

		}
		if (other.gameObject.tag == "BiggerThan")
		{
			if (InfinityMode == false) {

				BiggerThan randomBox = other.gameObject.GetComponent<BiggerThan> ();
				float sumBeforeDeath = summa;

				if (summa > randomBox.summaBox) {
					summa = (float)(summa * 1.25);
					source.PlayOneShot (BigSmallSFX, 0.7F);

				}    else {
					DeathExplanation.text = sumBeforeDeath + " IS NOT > " + randomBox.summaX + "×" + randomBox.summaY + "\n" + randomBox.summaX + "×" + randomBox.summaY + " = " + randomBox.summaBox.ToString ();
					toMenu ();
				}
			}

			if (InfinityMode == true) {
				summa = (float)(summa * 1.1);
			}

			PlayerPrefs.SetInt("TotalBigger", PlayerPrefs.GetInt("TotalBigger")+1);
			Destroy (other.gameObject);
			SetCountText ();

			if (LoadingBar.fillAmount <= 1) {
				LoadingBar.fillAmount += 0.05f;
			}

		}
		if (other.gameObject.tag == "BiggerThanExponent")
		{

			if (InfinityMode == false) {

				BiggerThanExponent randomBox = other.gameObject.GetComponent<BiggerThanExponent> ();
				float sumBeforeDeath = summa;

				if (summa > randomBox.summaBox) {
					summa = (float)(summa * 1.1);
					source.PlayOneShot (BigSmallSFX, 0.7F);


				}    
				else {
					if (sumBeforeDeath < 1000000) {
						DeathExplanation.text = sumBeforeDeath + " IS NOT > " + randomBox.summaX + "^" + randomBox.summaY + "\n" + randomBox.summaX + "^" + randomBox.summaY + " = " + randomBox.summaBox.ToString ();
					} else {
						DeathExplanation.text = (sumBeforeDeath / 1000000).ToString ("0.###") + "M" + " IS NOT > " + randomBox.summaX + "^" + randomBox.summaY + "\n" + randomBox.summaX + "^" + randomBox.summaY + " = " + (randomBox.summaBox / 1000000).ToString ("0.###") + "M";
					}
					toMenu ();
				}
			}

			if (InfinityMode == true) {
				summa = (float)(summa * 1.1);
			}


			PlayerPrefs.SetInt("TotalBigger", PlayerPrefs.GetInt("TotalBigger")+1);
			Destroy (other.gameObject);
			SetCountText ();

			if (LoadingBar.fillAmount <= 1) {
				LoadingBar.fillAmount += 0.05f;
			}


		}


		if (other.gameObject.tag == "SmallerThan")
		{
			if (InfinityMode == false) {

				SmallerThan randomBox = other.gameObject.GetComponent<SmallerThan> ();
				float sumBeforeDeath = summa;

				if (summa < randomBox.summaBox) {
					summa = (float)(summa * 1.1);
					source.PlayOneShot (BigSmallSFX, 0.7F);


				}    else {

					DeathExplanation.text = sumBeforeDeath + " IS NOT < " + randomBox.summaX + "×" + randomBox.summaY + "\n" + randomBox.summaX + "×" + randomBox.summaY + " = " + randomBox.summaBox.ToString ();
					toMenu ();
				}
			}

			if (InfinityMode == true) {
				summa = (float)(summa * 1.1);
			}

			PlayerPrefs.SetInt("TotalSmaller", PlayerPrefs.GetInt("TotalSmaller")+1);
			Destroy (other.gameObject);
			SetCountText ();

			if (LoadingBar.fillAmount <= 1) {
				LoadingBar.fillAmount += 0.05f;
			}


		}
		if (other.gameObject.tag == "SmallerThanExponent")
		{
			if (InfinityMode == false) {


				SmallerThanExponent randomBox = other.gameObject.GetComponent<SmallerThanExponent> ();
				float sumBeforeDeath = summa;

				if (summa < randomBox.summaBox) {
					summa = (float)(summa * 1.1);
					source.PlayOneShot (BigSmallSFX, 0.7F);
				} 
				else {
					if (sumBeforeDeath < 1000000) {
						DeathExplanation.text = sumBeforeDeath + " IS NOT < " + randomBox.summaX + "^" + randomBox.summaY + "\n" + randomBox.summaX + "^" + randomBox.summaY + " = " + randomBox.summaBox.ToString ();
					} else {
						DeathExplanation.text = (sumBeforeDeath / 1000000).ToString ("0.###") + "M" + " IS NOT < " + randomBox.summaX + "^" + randomBox.summaY + "\n" + randomBox.summaX + "^" + randomBox.summaY + " = " + (randomBox.summaBox / 1000000).ToString ("0.###") + "M";
					}
					toMenu ();
				}
			}

			if (InfinityMode == true) {
				summa = (float)(summa * 1.1);
			}

			PlayerPrefs.SetInt("TotalSmaller", PlayerPrefs.GetInt("TotalSmaller")+1);
			Destroy (other.gameObject);
			SetCountText ();

			if (LoadingBar.fillAmount <= 1) {
				LoadingBar.fillAmount += 0.05f;
			}
		}



		if (other.gameObject.CompareTag ("BlueRandom")) 
		{
			BlueBox randomBox = other.gameObject.GetComponent<BlueBox> ();
			summa = summa * randomBox.summaBox; //gåa med siffran

			if (LoadingBar.fillAmount <= 1) {
				LoadingBar.fillAmount += 0.05f;
			}

			PlayerPrefs.SetInt("TotalBlue", PlayerPrefs.GetInt("TotalBlue")+1);
			Destroy (other.gameObject);
			source.PlayOneShot (BlueSFX, 0.7F);
			SetCountText ();
		}

		if (other.gameObject.CompareTag ("Black")) 
		{
			Destroy (other.gameObject);
			// eventuellt nå ljud
		}
		if (other.gameObject.CompareTag ("Prim")) 
		{
			other.gameObject.SetActive (false);
			if (summa == 0 || summa == 1) {
				toMenu ();
			}
			else
			{
				for (int a = 2; a <= summa / 2; a++)
				{
					if (summa % a == 0)
					{
						toMenu ();
					}
				}
				summa = summa * 3; //trippla

				if (LoadingBar.fillAmount <= 1) {
					LoadingBar.fillAmount += 0.05f;
				}

				SetCountText ();
			}
		}



		if (other.gameObject.tag == "Reverse") {


			RandomTimer = Random.Range (4, 7);

			summa = (float)(summa * 1.25);

			if (InfinityMode == false){

				if (ReverseMode == false) {
					ReverseMode = true;
					Reverse.SetActive (true);
				}    

				ReverseTimer = 0;
				//	if (ReverseMode == true) {
				//			ReverseMode = false;
				//			Reverse.SetActive (false);
				//		}
			}

			if (LoadingBar.fillAmount <= 1) {
				LoadingBar.fillAmount += 0.05f;

			}
			PlayerPrefs.SetInt("TotalReverse", PlayerPrefs.GetInt("TotalReverse")+1);
			source.PlayOneShot (ReverseSFX, 0.7F);
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "Infinity") {

			if (InfinityMode == false) {
				InfinityMode = true;
				ReverseMode = false;
				Reverse.SetActive (false);
				Infinity.SetActive (true);
			}

			InfinityTimer = 0;

			if (LoadingBar.fillAmount <= 1) {
				LoadingBar.fillAmount += 0.05f;

			}
			Destroy (other.gameObject);
		}



		if(summa < 0)  // if our player is dead
		{
			toMenu ();
			// Hä jag ocksåöud och döimering, sedan vä-2 sek, sedan en restart/till main menu med touch-knappar
		}




		InfinityTimer += 1;

		if (InfinityTimer == 6) {

			InfinityMode = false;
			Infinity.SetActive (false);
		}

		ReverseTimer += 1;


		if (ReverseTimer == RandomTimer) {

			ReverseMode = false;
			Reverse.SetActive (false);
		}

	}
	void SetCountText () {

		if (summa < 1000000000) {
			int roundedSumma = Mathf.CeilToInt (summa);
			summa = roundedSumma;
		}

		if (currenthighest <= summa){
			currenthighest = summa;
		}

		// int testNumber = 134566548;  summa
		float highscore = PlayerPrefs.GetFloat ("Highscore");
		GigaBar.fillAmount = summa / highscore;

		//float A = -summa / 3f;
		//float B = (summa / 5f) / 3f;
		//float C = Mathf.Log(16.0f);

		//float sliderValue = summa / highscore; // ger 0-1 av ens score
		//float DisplayValue = B * (Mathf.Exp(C * sliderValue) - 1f);
		//float DisplayValue = B * (Mathf.Exp(C - 1f));
		//Debug.Log(DisplayValue);

		//if (summa < highscore / 10f) {
		//	GigaBar.fillAmount = summa * 2f / highscore;
		//} else {
		//}

		//GigaBar.fillAmount = DisplayValue;
	
		//summaText.text = summa.ToString("N0");
		if (summa < 10000) {

			summaText.text = summa.ToString ();

		}    
		if (summa > 10000 && summa < 1000000000) {
			summaText.text = summa.ToString ("### ### ###");
		}

		if (summa > 1000000000) {


			if (summa>= 1000000000) {
				summaText.text = (summa / 1000000000).ToString ("0.###") + "B";
			}
			if (summa >= 1000000000000) {
				summaText.text = (summa / 1000000000000).ToString ("0.###") + "T";
			}
			if (summa >= 1000000000000000) {
				summaText.text = (summa / 1000000000000000).ToString ("0.###") + "QUAD";
			}
			if (summa >= 1000000000000000000) {
				summaText.text = (summa / 1000000000000000000).ToString ("0.###") + "QUINT";
			}

		}






		if (summa > 10000 && tenK == false) {
			NewExperience += 50;
			tenK = true;
		}
		if (summa > 100000 && hundredK == false) {
			NewExperience += 100;
			hundredK = true;
		}
		if (summa > 500000 && fivehundredK == false) {
			NewExperience += 250;
			fivehundredK = true;
		}
		if (summa > 1000000 && onemillionK == false) {
			NewExperience += 250;
			onemillionK = true;
		}
		if (summa > 100000000 && onehundredmillionK == false) {
			NewExperience += 350;
			onehundredmillionK = true;
		}
		if (summa > 500000000 && fivehundredmillionK == false) {
			NewExperience += 500;
			fivehundredmillionK = true;
		}
		if (summa > 1000000000 && billion == false) {
			NewExperience += 1000;
			billion = true;
		}
		if (summa > 1000000000000 && trillion == false) {
			NewExperience += 2500;
			trillion = true;
		}




	}

	void SetOff(){
		GunIsReady.SetActive(false);
	}



	void toMenu(){



	
		source.Stop ();
		source.PlayOneShot (DeadSFX, 0.7F);

		if (TutorialMode == false) {

		

		if (PlayerPrefs.GetFloat ("Highscore") < currenthighest) {
			PlayerPrefs.SetFloat ("Highscore", currenthighest);
				NewHighScoreText.SetActive (true);
		}

		if (currenthighest < 10000) {

			CurrentHighest.text = currenthighest.ToString ();

		}     

		if (currenthighest > 10000) {
			CurrentHighest.text = currenthighest.ToString ("### ### ###");
		}

		if (currenthighest > 1000000000) {
			CurrentHighest.text = (currenthighest / 1000000000).ToString ("0.###") + "B";
		}
		if (currenthighest > 1000000000000) {
			CurrentHighest.text = (currenthighest / 1000000000000).ToString ("0.###") + "T";
		}
		if (currenthighest > 1000000000000000) {
			CurrentHighest.text = (currenthighest / 1000000000000000).ToString ("0.###") + "QUAD";
		}
		if (currenthighest > 1000000000000000000) {
			CurrentHighest.text = (currenthighest / 1000000000000000000).ToString ("0.###") + "QUINT";
		}


		if ((PlayerPrefs.GetFloat ("Highscore") < 10000)) {

			highScoreText.text = "☆" + PlayerPrefs.GetFloat ("Highscore").ToString ();

		}     

		if ((PlayerPrefs.GetFloat ("Highscore") > 10000)) {
			highScoreText.text = "☆" + PlayerPrefs.GetFloat ("Highscore").ToString ("### ### ###");
		}


		if ((PlayerPrefs.GetFloat ("Highscore") > 1000000000)) {
			highScoreText.text = "☆" + (PlayerPrefs.GetFloat ("Highscore") / 1000000000).ToString ("0.###") + "B";
		}
		if ((PlayerPrefs.GetFloat ("Highscore") > 1000000000000)) {
			highScoreText.text = "☆" + (PlayerPrefs.GetFloat ("Highscore") / 1000000000000).ToString ("0.###") + "T";
		}
		if ((PlayerPrefs.GetFloat ("Highscore") > 1000000000000000)) {
			highScoreText.text = "☆" + (PlayerPrefs.GetFloat ("Highscore") / 1000000000000000).ToString ("0.###") + "QUAD";
		}
		if ((PlayerPrefs.GetFloat ("Highscore") > 1000000000000000000)) {
			highScoreText.text = "☆" + (PlayerPrefs.GetFloat ("Highscore") / 1000000000000000000).ToString ("0.###") + "QUINT";
		}


		DeadScore.SetActive (true);
		ScoreText.SetActive (false);
		this.GetComponent<BoxCollider2D> ().enabled = false;
		Destroy (Spawners);

		float totalexp = PlayerPrefs.GetFloat ("TotalExperience");
		int CurrentLevel = (int)(0.1f * Mathf.Sqrt (totalexp));
		float XPnextlevel = 100 * (CurrentLevel + 1) * (CurrentLevel + 1); // xp from current level to next level
		float differenceXP = XPnextlevel - totalexp;	


		// if totalexperience + new experience > xp to next level -> "LEVEL UP!".ToString.


		//if (totalexp > 400) {

			if (NewExperience >= differenceXP) {

				LevelUpText.text = "LEVEL UP!".ToString ();


		//	}


		}

		PlayerPrefs.SetFloat ("TotalExperience", PlayerPrefs.GetFloat ("TotalExperience") + NewExperience);


		NewExperienceText.text = "+" + NewExperience + " EXP".ToString ();

	}

		if (TutorialMode == true) {
			// HÄR GÖR JAG NÅGOT
			DeadScore.SetActive (true);
			HowToPlay.SetActive (false);
			ScoreText.SetActive (false);
			this.GetComponent<BoxCollider2D> ().enabled = false;
			Destroy (Spawners);



		}
	}
}



