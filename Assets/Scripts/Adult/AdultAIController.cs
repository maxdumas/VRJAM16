using UnityEngine;
using System.Collections;

public class AdultAIController : Controller {

	private Vector3 _target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (_target == null) {
			_target = AcquireTarget;
		} else {

		}
	}

	private Vector3 AcquireTarget () {
		return Vector3.zero;
	}
}
