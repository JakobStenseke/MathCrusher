using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeActivateScript : MonoBehaviour {

	//public GameObject Button;
	public GameObject Image;

	// Use this for initialization
	void Start () {
	//	Invoke ("DeActivateImage", 1f);

	//	Button btn = Button.GetComponent<Button>();
	//	btn.onClick.AddListener(DeActivate);
		
	}
	
	// Update is called once per frame
	public void DeActivate () {
		Invoke ("DeActivateImage", 1f);
	}

	public void DeActivateImage () {
		Image.SetActive (false);
	}
}
