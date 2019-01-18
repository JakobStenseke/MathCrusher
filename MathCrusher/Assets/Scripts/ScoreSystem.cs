using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {


	public Text highscoreText;

	public Text CurrentLevelText;
	public int CurrentLevel;
	public float TotalExperiencePublic;
	public Image ProgressBar;

	public Text Matematiker;

	public Text TotalGreenText;
	public Text TotalRedText;
	public Text TotalBlueText;
	public Text TotalOrangeText;
	public Text TotalBiggerText;
	public Text TotalSmallerText;
	public Text TotalSurpriseText;
	public Text TotalReverseText;
	public Text TotalGigaText;


	public Image Fill1; //achivement 1
	//public Image Fill2;
	public Image Fill3;
	//public Image Fill4;
	public Image Fill5;
	public Image Fill6;
	//public Image Fill7;
	public Image Fill8;
	//public Image Fill9;
	public Image Fill10;
	public Image Fill11;
	public Image Fill12;
	//public Image Fill13;
	public Image Fill14;
	//public Image Fill15;

	// Use this for initialization
	void Start () { 

		//PlayerPrefs.DeleteAll();

		float totalexp = PlayerPrefs.GetFloat ("TotalExperience");

		//float totalexp = 2000f;

		TotalExperiencePublic = PlayerPrefs.GetFloat ("TotalExperience");

		CurrentLevel = (int)(0.1f * Mathf.Sqrt (totalexp));
		//if (TotalExperiencePublic > 400) {
		CurrentLevelText.text = "LEVEL" + " " + (CurrentLevel + 1).ToString (); // Medvetet ett över

		PlayerPrefs.SetFloat ("Level", CurrentLevel + 1);
	//	}

		float XPnextlevel = 100 * (CurrentLevel + 1) * (CurrentLevel + 1); // xp from current level to next level
		float differenceXP = XPnextlevel - totalexp;					   // xp to next level minus total experience, dvs. det som behövs
		float totaldifference = XPnextlevel - (100 * CurrentLevel * CurrentLevel); // xp to next level minus xp for current level

		float progress = totaldifference - differenceXP;
		float progressleft = progress / totaldifference;


		ProgressBar.fillAmount = progressleft;

		// Tänka igenom det här.
		// Säg att jag har 3100 EXP, det ger lvl 5, och borde ge 0.5454 till progressbar, då det är 600/1100, dvs. 54% progress till lvl 6
		// XPnextlevel borde vara 100 * (5+1)*(5+1), vilket ger 100 * 36 = 3600.
		// difference exp ger 3600 minus 3100, vilket ger 500 -- det är 500 kvar till level 6
		// total difference är 3600 - (100 * 5 * 5), vilket är 3600 - 2500, vilket ger 1100. Det current level behöver för att levla.
		// nu delar to next difference exp, dvs. 500 på 1100, MEN den borde dela på 600
		// lösning - total difference MINUS difference XP (vilket ger 600), och sedan difference delat på total difference.
		// nu funkar det!


		if ((PlayerPrefs.GetFloat ("Highscore") < 10000)) {

			highscoreText.text = "" + ((int)PlayerPrefs.GetFloat ("Highscore")).ToString ();
		} 
		if ((PlayerPrefs.GetFloat ("Highscore") > 10000)) {
			highscoreText.text = "" + ((int)PlayerPrefs.GetFloat ("Highscore")).ToString ("### ### ###");
		}
		if ((PlayerPrefs.GetFloat ("Highscore") > 1000000000)) {
			highscoreText.text = (PlayerPrefs.GetFloat ("Highscore") / 1000000000).ToString ("0.###") + "B";
		}
		if ((PlayerPrefs.GetFloat ("Highscore") > 1000000000000)) {
			highscoreText.text = (PlayerPrefs.GetFloat ("Highscore") / 1000000000000).ToString ("0.###") + "T";
		}
		if ((PlayerPrefs.GetFloat ("Highscore") > 1000000000000000)) {
			highscoreText.text = (PlayerPrefs.GetFloat ("Highscore") / 1000000000000000).ToString ("0.###") + "QUAD";
		}
		if ((PlayerPrefs.GetFloat ("Highscore") > 1000000000000000000)) {
			highscoreText.text = (PlayerPrefs.GetFloat ("Highscore") / 1000000000000000000).ToString ("0.###") + "QUINT";
		}







		if (CurrentLevel <= 3) {

			Matematiker.text = "NOVICE".ToString ();
		}

		if (CurrentLevel >= 4) {
			Matematiker.text = "NUMBER CRUSHER".ToString ();
		}


		if (CurrentLevel > 9) {
			Matematiker.text = "HIGH SCHOOL NERD".ToString ();
		}

		if (CurrentLevel > 14) {
			Matematiker.text = "ENGINEER".ToString ();
		}


		if (CurrentLevel > 19) {

			Matematiker.text = "EINSTEIN".ToString ();
		}

		if (CurrentLevel > 29) {

			Matematiker.text = "PYTHAGORAS".ToString ();
		}

		if (CurrentLevel > 39) {

			Matematiker.text = "EUCLID".ToString ();
		}


		if (CurrentLevel > 49) {

			Matematiker.text = "EULER".ToString ();
		}

		if (CurrentLevel > 59) {

			Matematiker.text = "RIENMANN".ToString ();
		}
		if (CurrentLevel > 69) {

			Matematiker.text = "GAUSS".ToString ();
		}
		if (CurrentLevel > 79) {

			Matematiker.text = "ARCHIMEDES".ToString ();
		}
		if (CurrentLevel > 89) {

			Matematiker.text = "NEWTON".ToString ();
		}
		if (CurrentLevel > 99) {

			Matematiker.text = "GOD".ToString ();
		}


			

			TotalGreenText.text = (PlayerPrefs.GetInt ("TotalGreen")).ToString ();
			TotalRedText.text = ((int)PlayerPrefs.GetInt ("TotalRed")).ToString ();
			TotalBlueText.text = ((int)PlayerPrefs.GetInt ("TotalBlue")).ToString ();
			TotalOrangeText.text = ((int)PlayerPrefs.GetInt ("TotalOrange")).ToString ();
			TotalBiggerText.text = ((int)PlayerPrefs.GetInt ("TotalBigger")).ToString ();
			TotalSmallerText.text = ((int)PlayerPrefs.GetInt ("TotalSmaller")).ToString ();
			TotalSurpriseText.text = ((int)PlayerPrefs.GetInt ("TotalSurprise")).ToString ();
			TotalReverseText.text = ((int)PlayerPrefs.GetInt ("TotalReverse")).ToString ();
			TotalGigaText.text = ((int)PlayerPrefs.GetInt ("TotalGiga")).ToString ();


		Fill1.fillAmount = ((PlayerPrefs.GetInt ("TotalGreen") / 10000f));
		//Fill2.fillAmount = ((PlayerPrefs.GetInt ("TotalRed") / 25000f));
		Fill3.fillAmount = ((PlayerPrefs.GetInt ("TotalBlue") / 10000f));
		//Fill4.fillAmount = ((PlayerPrefs.GetInt ("TotalOrange") / 10000f));
		Fill5.fillAmount = ((PlayerPrefs.GetInt ("TotalSurprise") / 250000f));
		Fill6.fillAmount = ((CurrentLevel + 1) / 10f);
		//Fill7.fillAmount = ((CurrentLevel + 1) / 25f);
		Fill8.fillAmount = ((CurrentLevel + 1) / 50f);
		//Fill9.fillAmount = ((CurrentLevel + 1) / 75f);
		Fill10.fillAmount = ((CurrentLevel + 1) / 100f);
		Fill11.fillAmount = ((PlayerPrefs.GetFloat ("Highscore")) / 1000000f);
		Fill12.fillAmount = ((PlayerPrefs.GetFloat ("Highscore")) / 1000000000f);
		//Fill13.fillAmount = ((PlayerPrefs.GetFloat ("Highscore")) / 100000000000f);
		Fill14.fillAmount = ((PlayerPrefs.GetFloat ("Highscore")) / 1000000000000f);
		//Fill15.fillAmount = ((PlayerPrefs.GetFloat ("Highscore")) / 1000000000000000f);


	}


}