using UnityEngine;
using GoogleMobileAds.Api;

	public class BannerScript : MonoBehaviour {
	private BannerView bannerView;

	void Start()
	{

		//adUnitId - the AdMob ad unit ID from which the BannerView should load ads.
		//adSize - the AdMob ad size you'd like to use
		//AdPosition - the position of the banner


		this.RequestBanner();

		// detta är mina unika app-id's som getts på AdMob - en för android en för iOS

		#if UNITY_ANDROID
		string appId = "ca-app-pub-3496704489635599~6744683001"; 
		#elif UNITY_IPHONE
		string appId = "ca-app-pub-3496704489635599~1979441488";
		#else
		string appId = "unexpected_platform";
		#endif


		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize(appId);
		}


		private void RequestBanner(){
	



		if ((!PlayerPrefs.HasKey ("AdFree"))  && (PlayerPrefs.GetFloat ("Level") > 9)) { //större än 9 sedan



		#if UNITY_ANDROID
			string adUnitId = "ca-app-pub-3496704489635599/2130774289";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3496704489635599/2482483299";
		#else
		string adUnitId = "unexpected_platform";
		#endif

			AdSize adSize = new AdSize (300, 50);
			//BannerView bannerView = new BannerView(adUnitId, adSize, AdPosition.Bottom);

			// Create a 320x50 banner at the top of the screen.
			//bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

			bannerView = new BannerView (adUnitId, adSize, AdPosition.Bottom);


			// NÄR TESTANDET ÄR KLART: 1. ÄNDRA adUnitId till mina banner-ad-enheter - 2. Ta bort AdTestDevice 3. Lägga till gamla AdRequest
			//MINA AD-ENHETER SOM DE STÅR PÅ AdMob:
			// iOS banner-enhet: ca-app-pub-3496704489635599/2482483299
			// android benner-enhet: ca-app-pub-3496704489635599/2130774289

			// TEST ID FÖR ANDROID: ca-app-pub-3940256099942544/6300978111
			// TEST ID FÖR IOS: ca-app-pub-3940256099942544/2934735716

			AdRequest request = new AdRequest.Builder().Build(); // <<<<<När det är färdigtestat, ha med denna


			// TA BORT ALLA DESSA NÄR DET ÄR FÄRDIGTESTAT:
			//AdRequest request = new AdRequest.Builder ()
			//.AddTestDevice (AdRequest.TestDeviceSimulator)       // Simulator.
			//.AddTestDevice (SystemInfo.deviceUniqueIdentifier)  // My test device.
			//.Build ();


			// Load the banner with the request.
			bannerView.LoadAd (request);
		}


		}

	void OnDestroy(){
		//if ((!PlayerPrefs.HasKey ("AdFree"))  && (PlayerPrefs.GetFloat ("Level") > 4))  {
			bannerView.Destroy ();

			Debug.Log ("Banner was destroyed.");
	}
}