using UnityEngine;
using System.Linq;
using System.Collections;

public class AdultAIController : Controller {
	public float MaxMovementRadius = 5f;

	private Collider _mediumAltitudeZone;
	private Vector3? _target;
	private bool _acquiringTarget = false;
	private PositionState _nextState;

	private AdultMovement _mvmt;
	private Insect _insect;

	private Animator _animC;
	
	// Use this for initialization
	void Start () {
		_mvmt = GetComponent<AdultMovement> ();
		_insect = GetComponent<Insect> ();
		_animC = GetComponent<Animator> ();
		_mediumAltitudeZone = GameObject.FindGameObjectWithTag ("MediumAltitudeZone").GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_target == null) {
			if(!_acquiringTarget) {
				StartCoroutine(AcquireTargetCoroutine());
			}
		} else if (!_mvmt.MoveTowardsTarget (_target)) {
			_target = null;
		}
	}

	private IEnumerator AcquireTargetCoroutine() {
		transform.rotation.SetLookRotation (Vector3.up);
		_acquiringTarget = true;
		_animC.SetTrigger("SoftFly");
		yield return new WaitForSeconds(Random.value * 2f);
		_target = AcquireTarget ();
		transform.LookAt (_target.Value);
		_acquiringTarget = false;
		_animC.SetTrigger("DashFly");
	}

	private Vector3 AcquireTarget () {
		switch (_nextState) {
		case PositionState.MURDER:
			Vector3? closestLarva = getClosest(this.transform.position, GameObject.FindGameObjectsWithTag("Larva").Select(go => go.transform.position));
			if (closestLarva.HasValue) {
				var cv = (closestLarva.Value - this.transform.position);
				if (cv.magnitude > MaxMovementRadius) {
					return transform.position + cv.normalized * MaxMovementRadius;
				} else {
					_nextState = PositionState.IDLE;
					return closestLarva.Value;
				}
			}
			_nextState = PositionState.IDLE;
			return AcquireTarget();
		case PositionState.IDLE:
			if (Random.value < 0.1f) {
				_nextState = PositionState.ATTEMPT_ESCAPE;
			} else {
				_nextState = PositionState.MURDER;
			}
			if (_mediumAltitudeZone.bounds.Contains(transform.position)) {
				return transform.position + Random.onUnitSphere * MaxMovementRadius;
			} else {
				return _mediumAltitudeZone.ClosestPointOnBounds(transform.position);
			}
		case PositionState.ATTEMPT_ESCAPE:
			_animC.SetTrigger("HardFly");
			_nextState = PositionState.IDLE;
			return GameObject.FindGameObjectWithTag("Exit").transform.position;

		}
		throw new UnityException ("SHIT IS FUCKEC");
	}

	public void OnTriggerEnter (Collider other) {
		// If we hit another insect...
		var otherInsect = other.gameObject.GetComponent<Insect> ();
		if (otherInsect != null) {
			// And it's an adult...
			if (otherInsect.Stage == Stage.Nymph) {
				PoolMaster.PlayAudio("Explosion");
				PoolMaster.Spawn ("Explosion", "bugExplosion", transform.position);
				PoolMaster.Spawn ("Bugs", "food", transform.position + Vector3.up);
				PoolMaster.Spawn ("Bugs", "food", transform.position + Vector3.forward);
				PoolMaster.Spawn ("Bugs", "food", transform.position + Vector3.back);
				PoolMaster.Spawn ("Bugs", "food", transform.position + Vector3.down);
				PoolMaster.Despawn(this.gameObject); // We are eaten!
			} else if (otherInsect.Stage == Stage.Larva) {
				_insect.Strength += 1;
			}
		}
	}

	private enum PositionState {
		IDLE, ATTEMPT_ESCAPE, MURDER
	}
}
