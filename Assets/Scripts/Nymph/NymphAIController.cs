using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public class NymphAIController : Controller {
	private NymphReticle _reticle;
	private Vector3? _target;
	private bool _acquiringTarget;
	private NymphMovement _mvmt;

	private Animator _animC;
	private Vector3? _jumpingOffPoint = null;


	// Use this for initialization
	void Start () {
		_reticle = GetComponent<NymphReticle> ();
		_mvmt = GetComponent<NymphMovement> ();
	}

	private IEnumerator AcquireTargetCoroutine() {
		_acquiringTarget = true;
		yield return new WaitForSeconds(0.5f);
		_target = AcquireTarget ();
		if (_target.HasValue) {
			transform.LookAt (_target.Value);
		}
		_acquiringTarget = false;
	}
	
	// Update is called once per frame
	Vector3? AcquireTarget () {
		var allAdults = GameObject.FindGameObjectsWithTag ("Adult")
			.Select (go => go.GetComponent<AdultMovement> ())
			.Where (a => a.IsVulnerable && Vector3.Distance(a.transform.position, transform.position) < _reticle.ProjectionThreshold);
		var closestAdult = getClosest (transform.position, allAdults.Select (a => a.transform.position));
		if (closestAdult.HasValue && _reticle.IsTargetValid(closestAdult.Value - transform.position)) { 
			Debug.Log ("Gonna try to get that adult there");
			_jumpingOffPoint = transform.position;
			return closestAdult.Value;
		} 

		transform.rotation = Quaternion.AngleAxis(Random.value * 360f, transform.up);
		if (_reticle.TargetIsValid) {
			Debug.Log ("Just gonna move forward I expect");
			return _reticle.Target;
		}

		Debug.Log ("No valid target could be found");
		return null;
	}

	void Update () {
		if (_target == null) {
			if (!_acquiringTarget) {
				Debug.Log ("Gonna try to get a new target");
				// If we jumped off from somewhere previously, next we want to return to from where we off-jamped!
				if (_jumpingOffPoint != null) {
					_target = _jumpingOffPoint;
					_jumpingOffPoint = null;
				} else {
					StartCoroutine (AcquireTargetCoroutine ());
				}
			}
		} else if (_mvmt.JumpToTarget (_target.Value)) {
			Debug.Log ("We're done movin'!");
			_target = null;
		}
	}
}
