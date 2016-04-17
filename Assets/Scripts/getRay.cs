using UnityEngine;
using System.Collections;

public class getRay : MonoBehaviour {

	public cutsceneManager csManager;
	public int nextScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (0.5F, 0.5F, 0));
		RaycastHit hit;
		
		if (GetComponent<Collider>().Raycast (ray, out hit, 10.0f)) {
			if (Input.anyKey) {
				//DO STUFF!
				csManager.callCutscene(nextScene);
			}
		}
	}
}
