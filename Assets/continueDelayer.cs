using UnityEngine;
using System.Collections;

public class continueDelayer : MonoBehaviour {
	
	public GameObject initialScreen;
	public GameObject continueScreen;

	public bool isActive;
	public float delayLength;
	float timePassed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			timePassed += Time.deltaTime;
		}

		if (timePassed >= delayLength) {
			isActive = false;
			timePassed = 0f;
			initialScreen.SetActive(false);
			continueScreen.SetActive(true);
		}
	}

	public void exitReset () {
		initialScreen.SetActive(true);
		continueScreen.SetActive(false);
	}
}
