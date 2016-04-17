using UnityEngine;
using System.Collections;

public class LarvaMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 startPos = new Vector3(this.transform.position.x, 0, this.transform.position.z);
		this.transform.position = startPos;
		//gameObject.transform.position.y = 0;
	}

	public void LookInDirection (Vector3 direction, float turnSpeed) {
		transform.Rotate (direction * turnSpeed);
	}
	
	public void MoveInDirection(Vector3 direction, float speed) {
		transform.Translate (direction * speed);
	}
}
