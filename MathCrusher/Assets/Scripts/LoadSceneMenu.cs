using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneMenu : MonoBehaviour {


	void Start(){
		
		//PlayerPrefs.SetInt ("TutorialCompleted", 1);

	}

	public void LoadScene()
	{

		if (!PlayerPrefs.HasKey ("TutorialCompleted")) {
		SceneManager.LoadScene ("Tutorial");

		}

		if (PlayerPrefs.GetInt ("TutorialCompleted") > 0){
			SceneManager.LoadScene ("MainScene");

		}

	}
}
