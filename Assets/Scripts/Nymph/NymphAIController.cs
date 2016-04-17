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


	// Use this for initialization
	void Start () {
		_reticle = GetComponent<NymphReticle> ();
		_mvmt = GetComponent<NymphMovement> ();
	}

	private IEnumerator AcquireTargetCoroutine() {
		_acquiringTarget = true;
		yield return new WaitForSeconds(Random.value * 2f);
		_target = AcquireTarget ();
		transform.LookAt (_target.Value);
		_acquiringTarget = false;
	}
	
	// Update is called once per frame
	Vector3? AcquireTarget () {
		var allAdults = GameObject.FindGameObjectsWithTag ("Adult")
			.Select (go => go.GetComponent<AdultMovement> ())
			.Where (a => a.IsVulnerable && Vector3.Distance(a.transform.position, transform.position) < _reticle.ProjectionThreshold);
		var closestAdult = getClosest (transform.position, allAdults.Select (a => a.transform.position));
		if (closestAdult.HasValue) {
			return closestAdult.Value;
		} else if (_reticle.IsTargetValid (transform.forward)) {
			return _reticle.ReticleSpawn.transform.position;
		} else {
			return null;
		}
	}

	void Update () {
		if (_target == null) {
			if (!_acquiringTarget) {
				StartCoroutine (AcquireTargetCoroutine ());
			}
		} else if (!_mvmt.JumpToTarget (_target.Value)) {
			_target = null;
		}
	}
}
