using UnityEngine;
using System.Collections;

public class StarField : MonoBehaviour {
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Rotate(0, .15f, 0);
	}
}
