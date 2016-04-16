using UnityEngine;
using System.Collections;

public class AdultMovement : MonoBehaviour {
	public float MovementSpeed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool MoveTowardsTarget (Vector3? target) {
		if (!target.HasValue) {
			return false;
		}
		var cv = target.Value - this.transform.position;
		var direction = cv.normalized;
		var distance = cv.magnitude;
		if (distance > MovementSpeed) {
			transform.position += direction * MovementSpeed;
		} else {
			transform.position = Vector3.Lerp (transform.position, target.Value, 0.5f);
		}

		return (transform.position - target.Value).magnitude > Vector3.kEpsilon;
	}
}
