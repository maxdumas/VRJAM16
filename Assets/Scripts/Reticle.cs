using UnityEngine;
using System.Collections;

public class Reticle : MonoBehaviour {
	public Renderer ReticleSpawn;

	public Vector3 Target;
	public float DefaultProjectionDistance = 5f;
	public float ProjectionThreshold = 20f;
	public bool TargetIsValid;

	private Color _defaultColor;
	public Color InvalidTargetColor;

	
	// Use this for initialization
	void Start () {
		if (ReticleSpawn != null) {
			_defaultColor = ReticleSpawn.material.color;
		}
	}

	// Update is called once per frame
	void Update () {
		if (ReticleSpawn != null) {
			if (TargetIsValid) {
				ReticleSpawn.material.color = _defaultColor;
			} else {
				ReticleSpawn.material.color = InvalidTargetColor;
			}

			Target = ReticleSpawn.transform.position = GetTarget ();
			ReticleSpawn.transform.LookAt (ReticleSpawn.transform.position);
		} else {
			Target = GetTarget();
		}
	}

	public bool IsTargetValid (Vector3 direction) {
		RaycastHit hitInfo = new RaycastHit();
		
		return Physics.Raycast (transform.position, direction, out hitInfo) && hitInfo.distance < ProjectionThreshold;
	}

	private Vector3 GetTarget () {
		RaycastHit hitInfo = new RaycastHit();
		
		if (Physics.Raycast(transform.position, transform.forward, out hitInfo) && hitInfo.distance < ProjectionThreshold) {
			TargetIsValid = true;
			return hitInfo.point;
		} else {
			TargetIsValid = false;
			return transform.position + transform.forward * DefaultProjectionDistance;
		}
	}
}
