using UnityEngine;
using System.Collections;

public class LarvaPlayerController : MonoBehaviour {

	public float MovementSpeed;
	public Transform lookDirection;
	private Vector3 direction;
	private LarvaMovement _mvmt;
	private Insect _insect;

	// Use this for initialization
	void Start () {
		_mvmt = GetComponent<LarvaMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		direction = lookDirection.position;
		_mvmt.MoveInDirection (direction, MovementSpeed/10000f);
	}

	public void OnCollisionEnter (Collision collision) {
		// If we hit another insect...
		var otherInsect = collision.gameObject.GetComponent<Insect> ();
		if (otherInsect != null) {
			// And it's an adult...
			if (otherInsect.Stage == Stage.Adult) {
				_insect.IsAlive = false;
			}
			return;
		}
		
		// If we hit food...
		var food = collision.gameObject.GetComponent<Food> ();
		if (food != null) {
			_insect.Strength += food.StrengthContent; // We get its strength!
		}
	}
}
