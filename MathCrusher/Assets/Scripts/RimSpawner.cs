using UnityEngine;
using UnityEngine.UI;

public class RimSpawner : MonoBehaviour
{
	public GameObject[] epoch0;
	public Transform[] spawnPoints;    // An array of the spawn points this enemy can spawn from.
	public float spawnTime = 0.5f;  // time after which object spawns. frå 2 till 0,8.
	public int BlockType = 0; // to spawn in right order
	public int DestroyRims = 0;

	public GameObject StartRims;

	public Button SpeedLow;
	public Button SpeedMedium;
	public Button SpeedHigh;

	void Start () {


		Button lowBtn = SpeedLow.GetComponent<Button>();
		lowBtn.onClick.AddListener(SetSpeedLow);

		Button medBtn = SpeedMedium.GetComponent<Button>();
		medBtn.onClick.AddListener(SetSpeedMedium);

		Button hBtn = SpeedHigh.GetComponent<Button>();
		hBtn.onClick.AddListener(SetSpeedHigh);


		spawnTime = PlayerPrefs.GetFloat ("SpawnRate") / 5;
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		Invoke ("Spawn", spawnTime);
		InvokeRepeating ("IncreaseSpawnRate", 0f, 1f);
	}


	void Spawn ()
	{

		BlockType += 1;
	
		if (BlockType == 1) {

			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			int prefeb_num = Random.Range (0, 1);
			Instantiate (epoch0 [prefeb_num], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			ScheduleNextSpawn ();

		}

		if (BlockType == 2) {

			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			int prefeb_num = Random.Range (1, 2);
			Instantiate (epoch0 [prefeb_num], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			ScheduleNextSpawn ();

		}

		if (BlockType == 3) {

			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			int prefeb_num = Random.Range (2, 3);
			Instantiate (epoch0 [prefeb_num], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			ScheduleNextSpawn ();

		}

		if (BlockType == 4) {

			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			int prefeb_num = Random.Range (3, 4);
			Instantiate (epoch0 [prefeb_num], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			ScheduleNextSpawn ();

		}

		if (BlockType == 5) {

			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			int prefeb_num = Random.Range (4, 5);
			Instantiate (epoch0 [prefeb_num], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			ScheduleNextSpawn ();

		}
		if (BlockType == 6) {

			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			int prefeb_num = Random.Range (5, 6);
			Instantiate (epoch0 [prefeb_num], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			ScheduleNextSpawn ();

		}

		if (BlockType == 7) {

			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			int prefeb_num = Random.Range (6, 7);
			Instantiate (epoch0 [prefeb_num], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			ScheduleNextSpawn ();
			BlockType = 0;

			DestroyRims += 1;

		}

		if (DestroyRims == 3) {
			Destroy(StartRims);
		}

	}
	void ScheduleNextSpawn ()
	{

		float spawnInSeconds;
		spawnInSeconds = spawnTime;
		Invoke ("Spawn", spawnInSeconds);

	}
	void IncreaseSpawnRate()
	{
		if (spawnTime > 0.01f)
			spawnTime -= 0.0f;

		if (spawnTime == 0.01f)
			CancelInvoke ("IncreaseSpawnRate");
	}

	void SetSpeedLow()
	{

		spawnTime = 2.6f / 5;
	}

	void SetSpeedMedium()
	{

		spawnTime = 1.8f / 5;
	}

	void SetSpeedHigh()
	{

		spawnTime = 1.2f / 5;
	}


}