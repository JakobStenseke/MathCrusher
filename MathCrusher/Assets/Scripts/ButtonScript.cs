using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {



	public Button SoundOn;
	public Button SoundOff;

	public Button SpeedLow;
	public Button SpeedMedium;
	public Button SpeedHigh;

	public Button ResetAll;

	public Button Skin0;
	public Button Skin1;
	public Button Skin2;
	public Button Skin3;
	public Button Skin4;
	public Button Skin5;
	public Button Skin6;
	public Button Skin7;


	public GameObject AchievementsButton;
	public GameObject ReachLevel10Button;

	public GameObject StatisticsButton;
	public GameObject ReachLevel5Button;

	public GameObject BlockerSkin1;
	public GameObject BlockerSkin2;
	public GameObject BlockerSkin3;
	public GameObject BlockerSkin4;
	public GameObject BlockerSkin5;
	public GameObject BlockerSkin6;
	public GameObject BlockerSkin7;

	public GameObject SoundOnshow;
	public GameObject SoundOffshow;
	public GameObject LowOffshow;
	public GameObject MediumOffshow;
	public GameObject HighOffshow;

	public GameObject SkinSelector;



	void Start()
		{



		Button btn = SoundOn.GetComponent<Button>();
		btn.onClick.AddListener(SetSoundOn);

		Button btn2 = SoundOff.GetComponent<Button>();
		btn2.onClick.AddListener(SetSoundOff);


		Button lowBtn = SpeedLow.GetComponent<Button>();
		lowBtn.onClick.AddListener(SetSpeedLow);

		Button medBtn = SpeedMedium.GetComponent<Button>();
		medBtn.onClick.AddListener(SetSpeedMedium);

		Button hBtn = SpeedHigh.GetComponent<Button>();
		hBtn.onClick.AddListener(SetSpeedHigh);

		Button resetBtn = ResetAll.GetComponent<Button>();
		resetBtn.onClick.AddListener(ResetFunction);


		Button s0 = Skin0.GetComponent<Button>();
		s0.onClick.AddListener(SetSkin0);

		if (PlayerPrefs.GetFloat ("Level") > 4) {
			Button s1 = Skin1.GetComponent<Button> ();
			s1.onClick.AddListener (SetSkin1);
			BlockerSkin1.SetActive (false);
		}
		if (PlayerPrefs.GetFloat ("Level") > 9) {
			Button s2 = Skin2.GetComponent<Button> ();
			s2.onClick.AddListener (SetSkin2);
			BlockerSkin2.SetActive (false);
		}

		if (PlayerPrefs.GetFloat ("Level") > 14) {
			Button s3 = Skin3.GetComponent<Button> ();
			s3.onClick.AddListener (SetSkin3);
			BlockerSkin3.SetActive (false);
		}
		if (PlayerPrefs.GetFloat ("Level") > 19) {
			Button s4 = Skin4.GetComponent<Button> ();
			s4.onClick.AddListener (SetSkin4);
			BlockerSkin4.SetActive (false);
		}
		if (PlayerPrefs.GetFloat ("Level") > 24) {
			Button s5 = Skin5.GetComponent<Button> ();
			s5.onClick.AddListener (SetSkin5);
			BlockerSkin5.SetActive (false);
		}
		if (PlayerPrefs.GetFloat ("Level") > 34) {
		Button s6 = Skin6.GetComponent<Button> ();
		s6.onClick.AddListener (SetSkin6);
			BlockerSkin6.SetActive (false);
		}
		if (PlayerPrefs.GetFloat ("Level") > 49) {
			Button s7 = Skin7.GetComponent<Button> ();
			s7.onClick.AddListener (SetSkin7);
			BlockerSkin7.SetActive (false);
		}




		//PlayerPrefs.DeleteAll();

		if (!PlayerPrefs.HasKey ("Speed")) {
			PlayerPrefs.SetFloat ("Speed", 1.8f);
		}

		if (!PlayerPrefs.HasKey ("SpawnRate")) {
			PlayerPrefs.SetFloat ("SpawnRate", 2.6f);
		}


		if (!PlayerPrefs.HasKey ("Sound")) {
			PlayerPrefs.SetInt ("Sound", 1);

		}

		if (!PlayerPrefs.HasKey ("Skin")) {
			PlayerPrefs.SetInt ("Skin", 0);
		}



		// AKTIVERINGEN AV LJUS PÅ KNAPPARNA:
		if (PlayerPrefs.GetInt ("Sound") == 1) {

			SoundOnshow.SetActive (false);
			SoundOffshow.SetActive (true);

		}

		if (PlayerPrefs.GetInt ("Sound") == 0) {

			SoundOnshow.SetActive (true);
			SoundOffshow.SetActive (false);
		}

		if (PlayerPrefs.GetFloat ("Speed") == 1.8f) {

			LowOffshow.SetActive (false);
			MediumOffshow.SetActive (true);
			HighOffshow.SetActive (true);
		}

		if (PlayerPrefs.GetFloat ("Speed") == 2.5f) {

			LowOffshow.SetActive (true);
			MediumOffshow.SetActive (false);
			HighOffshow.SetActive (true);
		}

		if (PlayerPrefs.GetFloat ("Speed") == 4f) {

			LowOffshow.SetActive (true);
			MediumOffshow.SetActive (true);
			HighOffshow.SetActive (false);
		}


		//FÅ SELECTOR I RÄTT PLATS
		if (PlayerPrefs.GetInt ("Skin") == 0) {
			SkinSelector.transform.position = Skin0.transform.position;
		}
		if (PlayerPrefs.GetInt ("Skin") == 1) {
			SkinSelector.transform.position = Skin1.transform.position;
		}
		if (PlayerPrefs.GetInt ("Skin") == 2) {
			SkinSelector.transform.position = Skin2.transform.position;
		}
		if (PlayerPrefs.GetInt ("Skin") == 3) {
			SkinSelector.transform.position = Skin3.transform.position;
		}
		if (PlayerPrefs.GetInt ("Skin") == 4) {
			SkinSelector.transform.position = Skin4.transform.position;
		}
		if (PlayerPrefs.GetInt ("Skin") == 5) {
			SkinSelector.transform.position = Skin5.transform.position;
		}
		if (PlayerPrefs.GetInt ("Skin") == 6) {
			SkinSelector.transform.position = Skin6.transform.position;
		}
		if (PlayerPrefs.GetInt ("Skin") == 7) {
			SkinSelector.transform.position = Skin7.transform.position;
		}

		if (PlayerPrefs.GetFloat ("Level") > 9) { //ändra till 9 sedan

			AchievementsButton.SetActive (true);
			ReachLevel10Button.SetActive (false);

		}


		if (PlayerPrefs.GetFloat ("Level") > 4) { // ändra till 4 sedan

			StatisticsButton.SetActive (true);
			ReachLevel5Button.SetActive (false);

		}




	}




	void SetSoundOn()
	{
		PlayerPrefs.DeleteKey("Sound");
		PlayerPrefs.SetInt ("Sound", 1);
	}

	void SetSoundOff()
	{
		PlayerPrefs.DeleteKey("Sound");
		PlayerPrefs.SetInt ("Sound", 0);
	}


	void SetSpeedLow()
	{

		PlayerPrefs.DeleteKey("Speed");
		PlayerPrefs.DeleteKey("SpawnRate");
		PlayerPrefs.SetFloat ("Speed", 1.8f);
		PlayerPrefs.SetFloat ("SpawnRate", 2.6f);
	}

	void SetSpeedMedium()
	{

		PlayerPrefs.DeleteKey("Speed");
		PlayerPrefs.DeleteKey("SpawnRate");
		PlayerPrefs.SetFloat ("Speed", 2.5f);
		PlayerPrefs.SetFloat ("SpawnRate", 2f);
	}

	void SetSpeedHigh()
	{

		PlayerPrefs.DeleteKey("Speed");
		PlayerPrefs.DeleteKey("SpawnRate");
		PlayerPrefs.SetFloat ("Speed", 4);
		PlayerPrefs.SetFloat ("SpawnRate", 1.5f);
	}

	void ResetFunction()
	{
		PlayerPrefs.DeleteKey ("TotalExperience");
		PlayerPrefs.DeleteKey ("Highscore");
		PlayerPrefs.DeleteKey ("Level");


		PlayerPrefs.DeleteKey ("TotalGreen");
		PlayerPrefs.DeleteKey ("TotalRed");
		PlayerPrefs.DeleteKey ("TotalBlue");
		PlayerPrefs.DeleteKey ("TotalOrange");
		PlayerPrefs.DeleteKey ("TotalBigger");
		PlayerPrefs.DeleteKey ("TotalSmaller");
		PlayerPrefs.DeleteKey ("TotalSurprise");
		PlayerPrefs.DeleteKey ("TotalReverse");
		PlayerPrefs.DeleteKey ("TotalGiga");
		PlayerPrefs.DeleteKey ("TutorialCompleted");
		PlayerPrefs.DeleteKey ("Skin");

		//PlayerPrefs.DeleteAll(); // När allt är färdigtestat -- Delete all förutom AdFree
		SceneManager.LoadScene("Menu");



	}

	void SetSkin0()
	{
		PlayerPrefs.DeleteKey("Skin");
		PlayerPrefs.SetInt ("Skin", 0);
		SkinSelector.transform.position = Skin0.transform.position;
	}
	void SetSkin1()
	{
		PlayerPrefs.DeleteKey("Skin");
		PlayerPrefs.SetInt ("Skin", 1);
		SkinSelector.transform.position = Skin1.transform.position;
	}
	void SetSkin2()
	{
		PlayerPrefs.DeleteKey("Skin");
		PlayerPrefs.SetInt ("Skin", 2);
		SkinSelector.transform.position = Skin2.transform.position;
	}
	void SetSkin3()
	{
		PlayerPrefs.DeleteKey("Skin");
		PlayerPrefs.SetInt ("Skin", 3);
		SkinSelector.transform.position = Skin3.transform.position;
	}
	void SetSkin4()
	{
		PlayerPrefs.DeleteKey("Skin");
		PlayerPrefs.SetInt ("Skin", 4);
		SkinSelector.transform.position = Skin4.transform.position;
	}
	void SetSkin5()
	{
		PlayerPrefs.DeleteKey("Skin");
		PlayerPrefs.SetInt ("Skin", 5);
		SkinSelector.transform.position = Skin5.transform.position;
	}
	void SetSkin6()
	{
		PlayerPrefs.DeleteKey("Skin");
		PlayerPrefs.SetInt ("Skin", 6);
		SkinSelector.transform.position = Skin6.transform.position;
	}
	void SetSkin7()
	{
		PlayerPrefs.DeleteKey("Skin");
		PlayerPrefs.SetInt ("Skin", 7);
		SkinSelector.transform.position = Skin7.transform.position;
	}



	}
