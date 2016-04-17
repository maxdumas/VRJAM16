using UnityEngine;
using System.Collections;

public class NymphPlayerController : MonoBehaviour {
		
	public Reticle reticle;

	private NymphMovement _mvmt;
	private bool _isMoving;

	void Start () {
		_mvmt = GetComponent<NymphMovement> ();
	}

	void Update () {
		if (_isMoving) {
			_isMoving = !_mvmt.JumpToTarget(reticle.ReticleSpawn.transform.position);
		} else if (Input.GetButtonDown ("Fire1") && reticle.TargetIsValid) {
			_isMoving = true;
		}
	}
}
