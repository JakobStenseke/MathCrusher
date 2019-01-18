﻿using System.Collections; using System.Collections.Generic; using UnityEngine; using ScottGarland;  public class Spawner2 : MonoBehaviour {  	public GameObject Skeleton; 	public Transform[] spawnPoints; 	public float maxSpawnRateInSeconds = 10f;  	// Use this for initialization 	void Start ()   	{ 		Invoke ("SpawnSkeleton", maxSpawnRateInSeconds);  		// Increase spawn rate every 10 seconds 		InvokeRepeating ("IncreaseSpawnRate", 0f, 10f);  	}  	// Update is called once per frame 	void Update () {  	} 	// Function to wpawn an emeny 	void SpawnSkeleton() 	{ 		// Find a random index between zero and one less than the number of spawn points. 		int spawnPointIndex = Random.Range (0, spawnPoints.Length);  		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation. 		Instantiate (Skeleton, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);  		//Shedule when to spawn next enemy 		ScheduleNextSkeletonSpawn (); 	}  	void ScheduleNextSkeletonSpawn() 	{ 		float spawnInNSeconds;  		if (maxSpawnRateInSeconds > 1f) { 			//pick a number between 1 and maxSpawnRateInSeconds 			spawnInNSeconds = Random.Range (1f, maxSpawnRateInSeconds); 		}   else 			spawnInNSeconds = 1f;  		Invoke ("SpawnSkeleton", spawnInNSeconds); 	}  	// Function to increase the difficulty of the game 	void IncreaseSpawnRate() 	{ 		if (maxSpawnRateInSeconds > 0.5f) 			maxSpawnRateInSeconds--;  		if(maxSpawnRateInSeconds == 0.5f) 			CancelInvoke ("IncreaseSpawnRate"); 	} }     