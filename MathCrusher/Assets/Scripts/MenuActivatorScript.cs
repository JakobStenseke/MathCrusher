using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuActivatorScript : MonoBehaviour {

	public GameObject HowTo;
	public GameObject HowToQuestionMark;
	public GameObject Settings;
	public GameObject Achievements;
	public GameObject Skins;
	public GameObject Statistics;
	public GameObject NoAds;
	public GameObject NoAdsText;


	// Use this for initialization
	void Start () {

		Invoke ("HowToActivate", 0.1f);
		Invoke ("SettingsActivate", 0.2f);
		Invoke ("AchievementsActivate", 0.3f);
		Invoke ("SkinsActivate", 0.4f);
		Invoke ("StatisticsActivate", 0.5f);
		Invoke ("NoAdsActivate", 0.6f);


		
	}
	
	// Update is called once per frame
	void HowToActivate () {

		HowTo.SetActive (true);
		HowToQuestionMark.SetActive (true);
		
	}

	void SettingsActivate () {

		Settings.SetActive (true);
		//HowToQuestionMark.SetActive (true);

	}

	void AchievementsActivate () {

		Achievements.SetActive (true);
		//HowToQuestionMark.SetActive (true);

	}

	void SkinsActivate () {

		Skins.SetActive (true);
		//HowToQuestionMark.SetActive (true);

	}
	void StatisticsActivate () {

		Statistics.SetActive (true);
		//HowToQuestionMark.SetActive (true);

	}

	void NoAdsActivate () {

		NoAds.SetActive (true);
		NoAdsText.SetActive (true);

	}
}
