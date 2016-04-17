using UnityEngine;
using System.Collections;

public class CameraToggle : MonoBehaviour {

	public GameObject playerCam;
	public GameObject cutsceneCam;
	public bool cutscene;


	void Start () {
		cutscene = true;
		playerCam.SetActive (false);
		cutsceneCam.SetActive (true);
	}

	public void ToggleCam() {
		playerCam.SetActive(cutscene);
		cutsceneCam.SetActive(!cutscene);
		cutscene = !cutscene;
	}
}
