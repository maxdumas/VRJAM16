using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static Vector3? getClosest (Vector3 location, IEnumerable<Vector3> targets) {
		float minDistance = float.MaxValue;
		Vector3? minTarget = null;
		foreach (Vector3 target in targets) {
			var d = Vector3.Distance(location, target);
			if (d < minDistance) {
				minDistance = d;
				minTarget = target;
			}
		}
		return minTarget;
	}
}
