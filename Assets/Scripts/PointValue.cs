using UnityEngine;
using System.Collections;

public class PointValue : MonoBehaviour {


	public float points = 100f;

	public float multiplier = 2f;

	void OnTriggerEnter(Collider other) {

		if (other.tag == "PointAffect") {
			//multiplier = other.GetComponent<PointMultiplier> ().multiplier;
			points *= multiplier;
			Debug.Log (gameObject.name + " registered " + other.name + " entering, and made its points " + points);

		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "PointAffect") {
			gameObject.GetComponent<PointValue> ().points /= multiplier;
			Debug.Log (gameObject.name + " registered " + other.name + " exiting, and returned its points to " + points);

		} 
	}
}
	
