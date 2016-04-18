using UnityEngine;
using System.Collections;

public class NymphPlayerController : MonoBehaviour {
		
	public Reticle reticle;

	private NymphMovement _mvmt;
	private Vector3? _target;

	void Start () {
		_mvmt = GetComponent<NymphMovement> ();
	}

	void Update () {
		if (_target != null && _mvmt.JumpToTarget(_target.Value)) {
			_target = null;
		} else if (Input.GetButtonDown ("Fire1") && reticle.TargetIsValid) {
			_target = reticle.ReticleSpawn.transform.position;
		}
	}
}
