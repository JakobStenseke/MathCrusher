using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSpawnerScript : MonoBehaviour
{
	public GameObject[] epochStart;
	public GameObject[] epoch0;
	public GameObject[] epoch1;
	public GameObject[] epoch2;
	public GameObject[] epoch3;
	public GameObject[] epoch4;
	public GameObject[] epoch5;
	public GameObject[] epoch6;
	public GameObject[] epochgeneral;


	public GameObject HowToPlay1;
	public GameObject HowToPlayGreen;
	public GameObject HowToPlayRed;
	public GameObject HowToPlayBlue;
	public GameObject HowToPlayYellow;
	public GameObject HowToPlayBeige;
	public GameObject HowToPlayPink;
	public GameObject HowToPlayReverse;
	public GameObject HowToPlaySurprise;
	public GameObject HowToShoot;
	public GameObject TutorialComplete;
	public GameObject DeadScreen;
	public GameObject Spawners;
	public GameObject Player;

	public Image TutorialBar;

	public bool TutorialCompleted;


	public Transform spawnPoints;    // An array of the spawn points this enemy can spawn from.
	public float spawnTime = 2f;  // time after which object spawns. frå 2 till 0,8.
	public int ChallengeTimer = 0;
	//public int Count;

	void Start ()
	{
		HowToPlay1.SetActive (true);
		PlayerPrefs.SetInt ("TutorialCompleted", 1);

		Invoke ("StartSpawning", 2f);

		ChallengeTimer = 0;
		spawnTime = 2.6f;

		TutorialCompleted = false;
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.

		//InvokeRepeating ("IncreaseSpawnRate", 0f, 1f);
	}

	void Update(){


		TutorialBar.fillAmount = ChallengeTimer / 30f;


		if (TutorialCompleted == true && (ChallengeTimer > 26)) {

			TutorialComplete.SetActive (true);

			HowToShoot.SetActive (false);
			Spawners.SetActive (false);
			Player.GetComponent<BoxCollider2D> ().enabled = false;

			Invoke ("DeadScreenFunction", 2f);

		}


	}


	void Spawn ()
	{

		ChallengeTimer += 1;

		//GameObject thePlayer = GameObject.Find ("Player");
		//PlayerMovement playerScript = thePlayer.GetComponent<PlayerMovement> ();


		if (ChallengeTimer <= 3) {

			HowToPlayGreen.SetActive (true);
			HowToPlay1.SetActive (false);
			
			//int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			int prefeb_num = Random.Range (0, epochStart.Length);
			Instantiate (epochStart [prefeb_num], spawnPoints.position, spawnPoints.rotation);
			ScheduleNextSpawn ();
			}

		if (ChallengeTimer > 3 && ChallengeTimer <= 6) {
		

			//int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			int prefeb_num = Random.Range (0, epoch0.Length);
			Instantiate (epoch0 [prefeb_num], spawnPoints.position, spawnPoints.rotation);
			ScheduleNextSpawn ();

			if (ChallengeTimer > 4) {
				HowToPlayRed.SetActive (true);
				HowToPlayGreen.SetActive (false);
			}

		}
		if (ChallengeTimer > 6 && ChallengeTimer <= 9) {
			
			//int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			int prefeb_num = Random.Range (0, epoch1.Length);
			Instantiate (epoch1 [prefeb_num], spawnPoints.position, spawnPoints.rotation);
			ScheduleNextSpawn ();

			if (ChallengeTimer > 7) {
				HowToPlayBlue.SetActive (true);
				HowToPlayRed.SetActive (false);
			}


			}

		if (ChallengeTimer > 9 && ChallengeTimer <= 12) {
			//int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			int prefeb_num = Random.Range (0, epoch2.Length);
			Instantiate (epoch2 [prefeb_num], spawnPoints.position, spawnPoints.rotation);
			ScheduleNextSpawn ();

			if (ChallengeTimer > 10) {
				HowToPlayYellow.SetActive (true);
				HowToPlayBlue.SetActive (false);
			}


			}

		if (ChallengeTimer > 12 && ChallengeTimer <= 15) {
			//int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			int prefeb_num = Random.Range (0, epoch3.Length);
			Instantiate (epoch3 [prefeb_num], spawnPoints.position, spawnPoints.rotation);
			ScheduleNextSpawn ();

			if (ChallengeTimer > 13) {
				HowToPlayBeige.SetActive (true);
				HowToPlayYellow.SetActive (false);
			}


		}
		if (ChallengeTimer > 15 && ChallengeTimer <= 18) {
			//int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			int prefeb_num = Random.Range (0, epoch4.Length);
			Instantiate (epoch4 [prefeb_num], spawnPoints.position, spawnPoints.rotation);
			ScheduleNextSpawn ();

			if (ChallengeTimer > 16) {
				HowToPlayPink.SetActive (true);
				HowToPlayBeige.SetActive (false);
			}

							}
		if (ChallengeTimer == 19) {
			//int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			int prefeb_num = Random.Range (0, epoch5.Length);
			Instantiate (epoch5 [prefeb_num], spawnPoints.position, spawnPoints.rotation);
			ScheduleNextSpawn ();

		}



		if (ChallengeTimer > 19 && ChallengeTimer < 23) {
			//int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			int prefeb_num = Random.Range (0, epochgeneral.Length);
			Instantiate (epochgeneral [prefeb_num], spawnPoints.position, spawnPoints.rotation);
			ScheduleNextSpawn ();
			HowToPlayReverse.SetActive (true);
			HowToPlayPink.SetActive (false);

		}
			

		if (ChallengeTimer == 23) {
			//int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			int prefeb_num = Random.Range (0, epoch6.Length);
			Instantiate (epoch6 [prefeb_num], spawnPoints.position, spawnPoints.rotation);
			ScheduleNextSpawn ();

			HowToPlayReverse.SetActive (false);
			HowToPlaySurprise.SetActive (true);
		}
			

		if (ChallengeTimer > 23) {
			//int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			int prefeb_num = Random.Range (0, epochgeneral.Length);
			Instantiate (epochgeneral [prefeb_num], spawnPoints.position, spawnPoints.rotation);
			ScheduleNextSpawn ();



		}

		if (ChallengeTimer == 24) {

			HowToPlaySurprise.SetActive (false);



		}

		if (ChallengeTimer == 25) {
			HowToShoot.SetActive (true);

		}


		if (ChallengeTimer == 28) {
			HowToShoot.SetActive (false);
		}


	}

	void ScheduleNextSpawn ()
	{

		float spawnInSeconds;
		spawnInSeconds = spawnTime;
		Invoke ("Spawn", spawnInSeconds);

	}

	void StartSpawning ()
	{
		Invoke ("Spawn", spawnTime);
	}


	void DeadScreenFunction ()
	{
		TutorialComplete.SetActive (false);
		DeadScreen.SetActive (true);

	}


}