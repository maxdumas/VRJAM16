using UnityEngine;
using System.Linq;
using System.Collections;

public class AdultAIController : Controller {
	public float MaxMovementRadius = 5f;

	private Vector3? _target;
	private bool _acquiringTarget = false;

	private AdultMovement _mvmt;
	private Insect _insect;

	private Animator _animC;
	
	// Use this for initialization
	void Start () {
		_mvmt = GetComponent<AdultMovement> ();
		_insect = GetComponent<Insect> ();
		_animC = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_target == null) {
			if(!_acquiringTarget) {
				StartCoroutine(AcquireTargetCoroutine());
				_acquiringTarget = true;
				_animC.SetTrigger("SoftFly");
			}
		} else if (!_mvmt.MoveTowardsTarget (_target)) {
			_target = null;
		}
	}

	private IEnumerator AcquireTargetCoroutine() {
		yield return new WaitForSeconds(Random.value * 2f);
		_target = AcquireTarget ();
		_acquiringTarget = false;
		_animC.SetTrigger("DashFly");
	}

	private Vector3 AcquireTarget () {
		float x = Random.value;
		if (x < 0.33f) { // Derp
			return Random.onUnitSphere * MaxMovementRadius;
		} else if (x < 0.66f) { // Murder
			Vector3? closestLarva = getClosest(this.transform.position, GameObject.FindGameObjectsWithTag("Larva").Select(go => go.transform.position));
			if (closestLarva.HasValue) {
				var cv = (closestLarva.Value - this.transform.position);
				if (cv.magnitude > MaxMovementRadius) {
					return cv.normalized * MaxMovementRadius;
				} else {
					return cv;
				}
			} else {
				return Random.onUnitSphere * MaxMovementRadius;
			}
		} else {
			// Attempt freedom
			_animC.SetTrigger("HardFly");
			return GameObject.FindGameObjectWithTag("Exit").transform.position;

		}
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
