using UnityEngine;
using System.Collections;

public class NymphPlayerController : MonoBehaviour {

	public Transform ReticleSpawn;
	public GameObject reticle;
	//public GameObject player;

	public GameObject player;
	//public Transform endMarker;

	public float speed = 1.0F;
	public float startTime;
	public float journeyLength;

	public float wF = 5f;

	public bool moving = false;

	// Use this for initialization
	void Start () {
		moving = false;
	}

	IEnumerator Movement(Vector3 showPos) {
		startTime = Time.time;
		journeyLength = Vector3.Distance(player.transform.position, showPos);
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		player.transform.position = Vector3.Lerp(player.transform.position, showPos, 0.5f);

		if (!player.transform.position.Equals(showPos)) {
			yield return null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 fwd = ReticleSpawn.transform.TransformDirection(Vector3.forward);
		RaycastHit hitInfo = new RaycastHit();
		Vector3 showPos;
		
		if (Physics.Raycast(transform.position, fwd, out hitInfo)) {
			showPos = hitInfo.point;
			reticle.transform.LookAt(showPos);
		}

		else {
			showPos = transform.position + fwd * wF;
			reticle.transform.LookAt(showPos);
		}
		reticle.transform.position = showPos;
		//reticle.transform.LookAt(showPos);
		//reticle.transform.LookAt(hitInfo.normal);

		//Debug.DrawRay(ReticleSpawn.transform.position, fwd, Color.green);
		Debug.DrawRay(ReticleSpawn.transform.position, fwd, Color.green);

		if (Input.GetButtonDown ("Fire1")) {
			moving = true;
			StartCoroutine(Movement(showPos));
		}


	}
}
