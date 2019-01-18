using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour {

	void Awake () {
		QualitySettings.vSyncCount = 1;  // VSync must be disabled
		Application.targetFrameRate = 45;
	}
}
