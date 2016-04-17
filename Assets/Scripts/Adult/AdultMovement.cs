using UnityEngine;
using System.Collections;

public class AdultMovement : MonoBehaviour {
	public float MovementSpeed = 5f;
	public bool IsVulnerable = false;
	public float VulnerabilityDistance = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hitInfo;
		if (Physics.Raycast(transform.position, Vector3.down, out hitInfo)) {
			IsVulnerable = hitInfo.distance < VulnerabilityDistance;
		}
	}

	public bool MoveTowardsTarget (Vector3? target) {
		if (!target.HasValue) {
			return false;
		}

		transform.position = Vector3.MoveTowards (transform.position, target.Value, MovementSpeed * Time.deltaTime);

		return (transform.position - target.Value).magnitude > Vector3.kEpsilon;
	}
}
