using UnityEngine;

public class SpawnOnce : MonoBehaviour
{
	public GameObject[] prefeb;// prefab to be spawned.
	public Transform[] spawnPoints;    // An array of the spawn points this enemy can spawn from.
	public float spawnTime = 0;  // time after which object spawns. frå 2 till 0,8.

	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		Invoke ("Spawn", spawnTime);
	}


	void Spawn ()
	{

		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		int prefeb_num = Random.Range (0, prefeb.Length);

		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (prefeb [prefeb_num], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);



		}
}