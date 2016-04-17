using UnityEngine;
using System.Collections;

public class NymphPlayerController : MonoBehaviour {
		
	public NymphReticle reticle;
		
	public float MaximumSpeed = 50.0F;

	void Start () {
	}
	
	IEnumerator Movement(Vector3 destination) {
		while(!transform.position.Equals(destination)) {
			transform.position = Vector3.MoveTowards(transform.position, destination, MaximumSpeed * Time.deltaTime);
			yield return null;
		}
	}

	void Update () {
		if (Input.GetButtonDown ("Fire1") && reticle.TargetIsValid) {
			StartCoroutine(Movement(reticle.ReticleSpawn.transform.position));
		}
	}
}
