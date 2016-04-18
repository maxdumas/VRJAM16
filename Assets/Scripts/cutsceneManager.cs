using UnityEngine;
using System.Collections;

public class cutsceneManager : MonoBehaviour {
	
	public GameObject cutSceneCamera;
	public GameObject[] cutscenes;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void callCutscene (int scene) {
		//turn off all scenes
		for (int i = 0; i < cutscenes.Length; i++) {
			cutscenes [i].SetActive (false);
		}
		//turn on requested scene
		cutSceneCamera.SetActive (true);
		cutscenes [scene].SetActive (true);
		var sceneDelayer = cutscenes [scene].GetComponent<continueDelayer> ();
		if (sceneDelayer != null) {
			sceneDelayer.isActive = true;
		}

		if (scene == 0) {
			cutSceneCamera.SetActive (false);
			//turn off audio
			GetComponent<AudioSource> ().Pause ();
		} else {
			//play
			GetComponent<AudioSource> ().Play();
		}
	}
}
