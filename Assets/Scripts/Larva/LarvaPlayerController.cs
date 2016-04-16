using UnityEngine;
using System.Collections;

public class LarvaPlayerController : MonoBehaviour {

	public float MovementSpeed;
	public Transform lookDirection;
	private Vector3 direction;
	private LarvaMovement _mvmt;

	// Use this for initialization
	void Start () {
		_mvmt = GetComponent<LarvaMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		direction = lookDirection.position;
		_mvmt.MoveInDirection (direction, MovementSpeed/10000f);
	}
}
