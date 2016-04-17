using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class LarvaAIController : Controller {

	public float DangerDistance;
	public float MovementSpeed;
	public float DefaultSpeed;

	private LarvaMovement _mvmt;
	private Insect _insect;

	private Animator _animC;
	
	private bool almostMoving;
	private bool almostIdling;


	// Use this for initialization
	void Start () {
		_mvmt = GetComponent<LarvaMovement> ();
		_insect = GetComponent<Insect> ();
		_animC = GetComponent<Animator> ();
		DefaultSpeed = Random.Range (0.01f, 0.2f);
		MovementSpeed = DefaultSpeed;
		almostMoving = false;
		almostIdling = false;

	}

	// Update is called once per frame
	void FixedUpdate () {
		var allFood = GameObject.FindGameObjectsWithTag ("Food").Select(go => go.GetComponent<Food>());
		var allAdults = GameObject.FindGameObjectsWithTag ("Adult").Select(go => go.GetComponent<Insect>());
		Vector3 direction = getMovementDir (allFood, allAdults);
		_mvmt.MoveInDirection (direction, MovementSpeed);
		_mvmt.LookInDirection (direction, MovementSpeed);

	}

	Vector3 getMovementDir (IEnumerable<Food> food, IEnumerable<Insect> adults) {
		var closestAdult = getClosest (this.transform.position, adults.Select(a => a.transform.position));
		if (closestAdult.HasValue) {
			var connectorVector = closestAdult.Value - this.transform.position;
			// If the closest adult is close enough that it is dangerous, move away from them
			if (connectorVector.magnitude <= DangerDistance) {
				// Reset the y component of the direction to prevent larva from leaving the floor
				if (almostMoving == true) {
					_animC.SetTrigger("Moving");
					almostMoving = false;
					almostIdling = true;
				}
				MovementSpeed = DefaultSpeed * 1.8f;
				return Vector3.Scale(connectorVector, new Vector3 (-1f, 0f, -1f)).normalized;
			} 
				else if (almostIdling == true) {
					_animC.SetTrigger("Idling");
					almostIdling = false;
				}

		}
		var closestFood = getClosest (this.transform.position, food.Select (f => f.transform.position));
		if (closestFood.HasValue) {
			// Move towards the closest food
			_animC.SetTrigger ("Moving");
			MovementSpeed = DefaultSpeed * 1.3f;
			return (closestFood.Value - this.transform.position).normalized;

		} else {
			MovementSpeed = DefaultSpeed;
			almostMoving = true;
			return Vector3.zero;
			//_animC.SetTrigger("Idling");
		}
	}

	public void OnCollisionEnter (Collision collision) {
		// If we hit another insect...
		var otherInsect = collision.gameObject.GetComponent<Insect> ();
		if (otherInsect != null) {
			// And it's an adult...
			if (otherInsect.Stage == Stage.Adult) {
				PoolMaster.Spawn ("Explosion", "bugExplosion", this.transform.position);
				PoolMaster.Despawn(this.gameObject); // We are eaten!
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
