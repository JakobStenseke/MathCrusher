using UnityEngine;

public class RimSpawnerInGame : MonoBehaviour
{
	public GameObject[] epoch0;
	public Transform[] spawnPoints;    // An array of the spawn points this enemy can spawn from.
	public float spawnTime = 0.5f;  // time after which object spawns. frå 2 till 0,8.
	public int BlockType = 0; // to spawn in right order
	public int DestroyRims = 0;
	public float WhiteIsNext = 0;

	public GameObject StartRims;


	void Start () {



		spawnTime = PlayerPrefs.GetFloat ("SpawnRate") / 5;
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		Invoke ("Spawn", spawnTime);
		InvokeRepeating ("IncreaseSpawnRate", 0f, 1f);
	}


	void Spawn ()
	{
		if (DestroyRims == 10) {
			WhiteIsNext = 1;

		}

		BlockType += 1;

		if (WhiteIsNext == 0) {


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
		}

		if (WhiteIsNext == 1) {


				//BlockType = 0;

				if (BlockType >= 0 && BlockType < 50) {
					int spawnPointIndex = Random.Range (0, spawnPoints.Length);
					int prefeb_num = Random.Range (0, 1);
					Instantiate (epoch0 [prefeb_num], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
					ScheduleNextSpawn ();
				}

				if (BlockType >= 50 && BlockType < 100) {
					int spawnPointIndex = Random.Range (0, spawnPoints.Length);
					int prefeb_num = Random.Range (1, 2);
					Instantiate (epoch0 [prefeb_num], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
					ScheduleNextSpawn ();
				}
				if (BlockType >= 100 && BlockType < 150) {
					int spawnPointIndex = Random.Range (0, spawnPoints.Length);
					int prefeb_num = Random.Range (2, 3);
					Instantiate (epoch0 [prefeb_num], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
					ScheduleNextSpawn ();
				}
				if (BlockType >= 150 && BlockType < 200) {
					int spawnPointIndex = Random.Range (0, spawnPoints.Length);
					int prefeb_num = Random.Range (3, 4);
					Instantiate (epoch0 [prefeb_num], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
					ScheduleNextSpawn ();
				}
				if (BlockType >= 200 && BlockType < 250) {
					int spawnPointIndex = Random.Range (0, spawnPoints.Length);
					int prefeb_num = Random.Range (4, 5);
					Instantiate (epoch0 [prefeb_num], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
					ScheduleNextSpawn ();
				}
				if (BlockType >= 250 && BlockType < 300) {
					int spawnPointIndex = Random.Range (0, spawnPoints.Length);
					int prefeb_num = Random.Range (5, 6);
					Instantiate (epoch0 [prefeb_num], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
					ScheduleNextSpawn ();
				}
				if (BlockType >= 300 && BlockType < 350) {
					int spawnPointIndex = Random.Range (0, spawnPoints.Length);
					int prefeb_num = Random.Range (6, 7);
					Instantiate (epoch0 [prefeb_num], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
					ScheduleNextSpawn ();
				}

				if (BlockType >= 349) {

					BlockType = 0;
					DestroyRims = 0;
					WhiteIsNext = 0;
					//ScheduleNextSpawn ();

				}
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