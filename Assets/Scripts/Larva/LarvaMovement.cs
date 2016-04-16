using UnityEngine;
using System.Collections;

public class LarvaMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void LookInDirection (Vector3 direction, float turnSpeed) {
		transform.Rotate (direction * turnSpeed);
	}
	
	public void MoveInDirection(Vector3 direction, float speed) {
		transform.Translate (direction * speed);
	}
}
