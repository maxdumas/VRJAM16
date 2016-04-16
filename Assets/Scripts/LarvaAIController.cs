using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class LarvaAIController : Controller {

	public float DangerDistance;
	public float MovementSpeed;

	private LarvaMovement _mvmt;
	private Insect _insect;

	// Use this for initialization
	void Start () {
		_mvmt = GetComponent<LarvaMovement> ();
		_insect = GetComponent<Insect> ();
	}

	// Update is called once per frame
	void Update () {
		var allFood = GameObject.FindGameObjectsWithTag ("Food").Select(go => go.GetComponent<Food>());
		var allAdults = GameObject.FindGameObjectsWithTag ("Adult").Select(go => go.GetComponent<Insect>());
		Vector3 direction = getMovementDir (allFood, allAdults);
		_mvmt.MoveInDirection (direction, MovementSpeed);
		_mvmt.LookInDirection (direction, MovementSpeed);
	}

	Vector3 getMovementDir (IEnumerable<Food> food, IEnumerable<Insect> adults) {
		var closestAdult = getClosest (this.transform.position, adults.Select(a => a.transform.position));
		//Debug.Log (closestAdult);
		if (closestAdult.HasValue) {
			var connectorVector = closestAdult.Value - this.transform.position;
			// If the closest adult is close enough that it is dangerous, move away from them
			if (connectorVector.magnitude <= DangerDistance) {
				//Debug.Log ("LOL");
				return (connectorVector * -1).normalized;
			} 
		}
		var closestFood = getClosest (this.transform.position, food.Select (f => f.transform.position));
		if (closestFood.HasValue) {
			// Move towards the closest food
			return (closestFood.Value - this.transform.position).normalized;
		} else {
			return Vector3.zero;
		}
	}

	public void OnCollisionEnter (Collision collision) {
		// If we hit another insect...
		var otherInsect = collision.gameObject.GetComponent<Insect> ();
		if (otherInsect != null) {
			// And it's an adult...
			if (otherInsect.Stage == Stage.Adult) {
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
