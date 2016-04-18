using UnityEngine;
using System.Collections;

public class RestartLevelButton : MonoBehaviour {
	void Update () {
		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (0.5F, 0.5F, 0));
		RaycastHit hit;
		
		if (GetComponent<Collider>().Raycast (ray, out hit, 10.0f)) {
			if (Input.anyKey) {
				//DO STUFF!
				Application.LoadLevel(Application.loadedLevelName);
			}
		}
	}
}
