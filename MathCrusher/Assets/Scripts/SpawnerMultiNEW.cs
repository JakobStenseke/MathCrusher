using UnityEngine;

public class SpawnerMultiNEW : MonoBehaviour
{
	public GameObject[] prefeb;                // The enemy prefab to be spawned.
	public Transform[] spawnPoints;    // An array of the spawn points this enemy can spawn from.
	public float spawnRate = 2f;    // How long between each spawn.
	public float acceleration = 0.2f;
	public float maxSpawnRate = 0.5f;



	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnRate, spawnRate);
	}


	void Spawn ()
	{
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		int prefeb_num = Random.Range (0, prefeb.Length);

		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (prefeb [prefeb_num], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		Invoke ("IncreaseSpawnRate", 0.1f);
	}
	void IncreaseSpawnRate ()
	{

		spawnRate -= acceleration;

		if (spawnRate < maxSpawnRate)
			spawnRate = maxSpawnRate;
	}
}