using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdvertisementScript : MonoBehaviour

{
	public Button Button1;

	public void Start(){

		Button btn = Button1.GetComponent<Button> ();

		GameObject thePlayer = GameObject.Find ("Player");
		PlayerMovement playerScript = thePlayer.GetComponent<PlayerMovement> ();

		if ((!PlayerPrefs.HasKey ("AdFree")) && (playerScript.NewExperience > 100) && (PlayerPrefs.GetFloat ("Level") > 5)){ //större än 4 sedan

			btn.onClick.AddListener (ShowRewardedAd);

		}
		else {
			btn.onClick.AddListener (BackToMenu);
		}

	}
	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("video"))
			//("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("video", options);
			//("rewardedVideo"))
		}
		Invoke ("BackToMenu", 0.1f);
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log("The ad was successfully shown.");
			//
			// YOUR CODE TO REWARD THE GAMER
			// Give coins etc.
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}

	public void BackToMenu (){

		SceneManager.LoadScene ("Menu");
	}
}