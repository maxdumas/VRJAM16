using UnityEngine;
using System.Collections;

public class NymphReticle : MonoBehaviour {
	public Renderer ReticleSpawn;

	public float DefaultProjectionDistance = 5f;
	public float ProjectionThreshold = 50f;

	private Color _defaultColor;
	public Color InvalidTargetColor;

	
	// Use this for initialization
	void Start () {
		_defaultColor = ReticleSpawn.material.color;
	}

	// Update is called once per frame
	void Update () {
		ReticleSpawn.transform.position = FindReticlePosition ();
		ReticleSpawn.transform.LookAt (ReticleSpawn.transform.position);
	}

	Vector3 FindReticlePosition () {
		Vector3 fwd = transform.forward;
		RaycastHit hitInfo = new RaycastHit();
		Vector3 showPos;
		
		Debug.DrawRay(ReticleSpawn.transform.position, fwd, Color.green);
		if (Physics.Raycast(transform.position, fwd, out hitInfo) && hitInfo.distance < ProjectionThreshold) {
			ReticleSpawn.material.color = _defaultColor;
			return hitInfo.point;
		} else {
			ReticleSpawn.material.color = InvalidTargetColor;
			return transform.position + fwd * DefaultProjectionDistance;
		}
	}
}
