using UnityEngine;
using System.Collections;

public class NymphMovement : MonoBehaviour {

	public float MaximumSpeed = 20.0F;

	private Insect _insect;

	// Use this for initialization
	void Start () {
		_insect = GetComponent<Insect> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool JumpToTarget(Vector3 target) {
		transform.position = Vector3.MoveTowards(transform.position, target, MaximumSpeed * Time.deltaTime);
		return Vector3.Distance (transform.position, target) < Vector3.kEpsilon;
	}

	public void OnCollisionEnter (Collision collision) {
		// If we hit another insect...
		var otherInsect = collision.gameObject.GetComponent<Insect> ();
		if (otherInsect != null) {
			// And it's an adult...
			if (otherInsect.Stage == Stage.Adult) {
				_insect.Strength += 1; 
				Debug.Log (_insect.Strength);
				// We eat them!!!!!!!!!!! >:)
			}
		}
	}
}
