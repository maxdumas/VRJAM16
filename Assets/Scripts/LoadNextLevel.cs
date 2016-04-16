using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour {

	public GameObject loading;
	public GameObject pressKey;

	void Start () {
		loading.SetActive (false);
		pressKey.SetActive (true);

	}

	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
		//	AsyncOperation async = Application.LoadLevel(1);	
			//Handheld.Vibrate ();
			loading.SetActive (true);
			pressKey.SetActive (false);
			//SceneManager.LoadScene(1);
			}
	}
}
