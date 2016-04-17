using UnityEngine;
using System.Collections;

public class VRToggle : MonoBehaviour {
 
  public GameObject[] cardboardObjects;
  public GameObject[] monoObjects;

public float lookTime;
 
  // Turn on or off VR mode
  void ActivateVRMode(bool goToVR) {
    foreach (GameObject cardboardThing in cardboardObjects) {
        cardboardThing.SetActive(goToVR);
    }
    foreach (GameObject monoThing in monoObjects) {
        monoThing.SetActive(!goToVR);
    }
    Cardboard.SDK.VRModeEnabled = goToVR;
 
    // Tell the game over screen to redisplay itself if necessary
    //gameObject.GetComponent<GameController>().RefreshGameOver();
  }
 
  public void Switch() {
	if (lookTime >= 1.0f) {
		ActivateVRMode(!Cardboard.SDK.VRModeEnabled);
			lookTime = 0.0f;
	}
  }
 
  void Update () {
	lookTime += Time.deltaTime;

	if (Cardboard.SDK.BackButtonPressed) {
			Application.Quit();
		//Application.LoadLevel(0);
		//Switch();
    }
		if (Input.deviceOrientation == DeviceOrientation.LandscapeRight) {
			Switch();
			return;
		}
		#if UNITY_EDITOR
		if (Input.GetKeyDown (KeyCode.CapsLock)) {
			Switch();
			return;
		}
		#endif

  }
 
  void Start() {
    ActivateVRMode(false);
	lookTime = 1.0f;
  }
}