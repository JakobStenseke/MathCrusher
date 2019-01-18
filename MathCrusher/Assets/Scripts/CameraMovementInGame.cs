using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraMovementInGame : MonoBehaviour {

	public float startSpeed = 5f;
	public float acceleration = 3.0f;
	public float maxSpeed = 60.0f;
	public bool TutorialMode;


	void Start () {


			Scene scene = SceneManager.GetActiveScene();
			if (scene.name == "Tutorial") {
				TutorialMode = true;
				startSpeed = 1.8f;
			} else {
				TutorialMode = false;
				startSpeed = PlayerPrefs.GetFloat ("Speed");
			}


	}

	void Update () {



		transform.Translate (0, startSpeed * Time.deltaTime, 0);

		startSpeed += acceleration;

		if (startSpeed > maxSpeed)
			startSpeed = maxSpeed;

	}


}
