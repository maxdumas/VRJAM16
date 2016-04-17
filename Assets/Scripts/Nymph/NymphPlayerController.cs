using UnityEngine;
using System.Collections;

public class NymphPlayerController : MonoBehaviour {
		
	public NymphReticle reticle;
		
	public float speed = 1.0F;
	public float startTime;
	public float journeyLength;

	void Start () {
	}
	
	IEnumerator Movement(Vector3 showPos) {
		startTime = Time.time;
		journeyLength = Vector3.Distance(transform.position, showPos);
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(transform.position, showPos, 0.5f);
		
		if (!transform.position.Equals(showPos)) {
			yield return null;
		}
	}

	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			StartCoroutine(Movement(reticle.transform.position));
		}
	}
}
