using UnityEngine;
using System.Collections;

public class AdultPlayerController : Controller {

	public Reticle reticle;
	
	private AdultMovement _mvmt;
	private Vector3? _target;
	
	void Start () {
		_mvmt = GetComponent<AdultMovement> ();
	}
	
	void Update () {
		if (_target == null && Input.GetButtonDown ("Fire1")) {
			_target = reticle.ReticleSpawn.transform.position;
		} else if (!_mvmt.MoveTowardsTarget (_target.Value)) {
			_target = null;
		}
	}
}
