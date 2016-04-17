using UnityEngine;
using System.Collections;

public class NymphReticle : MonoBehaviour {
	public Renderer ReticleSpawn;

	public float DefaultProjectionDistance = 5f;
	public float ProjectionThreshold = 20f;
	public bool TargetIsValid;

	private Color _defaultColor;
	public Color InvalidTargetColor;

	
	// Use this for initialization
	void Start () {
		_defaultColor = ReticleSpawn.material.color;
	}

	// Update is called once per frame
	void Update () {
		if (TargetIsValid) {
			ReticleSpawn.material.color = _defaultColor;
		} else {
			ReticleSpawn.material.color = InvalidTargetColor;
		}

		ReticleSpawn.transform.position = FindReticlePosition ();
		ReticleSpawn.transform.LookAt (ReticleSpawn.transform.position);
	}

	Vector3 FindReticlePosition () {
		Vector3 fwd = transform.forward;
		RaycastHit hitInfo = new RaycastHit();
		Vector3 showPos;
		
		Debug.DrawRay(ReticleSpawn.transform.position, fwd, Color.green);
		if (Physics.Raycast(transform.position, fwd, out hitInfo) && hitInfo.distance < ProjectionThreshold) {
			TargetIsValid = true;
			return hitInfo.point;
		} else {
			TargetIsValid = false;
			return transform.position + fwd * DefaultProjectionDistance;
		}
	}
}
