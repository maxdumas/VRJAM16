using UnityEngine;
using System.Collections;

public class AdultAIController : Controller {

	private Vector3? _target;

	private AdultMovement _mvmt;
	private Insect _insect;
	
	// Use this for initialization
	void Start () {
		_mvmt = GetComponent<AdultMovement> ();
		_insect = GetComponent<Insect> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_target == null) {
			_target = AcquireTarget();
		} else if (!_mvmt.MoveTowardsTarget (_target)) {
			_target = null;
		}
	}

	private Vector3 AcquireTarget () {
		return Vector3.zero;
	}

	public void OnCollisionEnter (Collision collision) {
		// If we hit another insect...
		var otherInsect = collision.gameObject.GetComponent<Insect> ();
		if (otherInsect != null) {
			// And it's an adult...
			if (otherInsect.Stage == Stage.Nymph) {
				PoolMaster.Despawn(this.gameObject); // We are eaten!
			} else if (otherInsect.Stage == Stage.Larva) {
				_insect.Strength += 1;
			}
		}
	}
}
