using UnityEngine;
using System.Collections;

public class NymphMovement : MonoBehaviour {

	public float MaximumSpeed = 20.0F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool JumpToTarget(Vector3 target) {
		transform.position = Vector3.MoveTowards(transform.position, target, MaximumSpeed * Time.deltaTime);
		return Vector3.Distance (transform.position, target) < Vector3.kEpsilon;
	}
}
