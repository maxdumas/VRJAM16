using UnityEngine;
using System.Collections;

public class RandomRotate : MonoBehaviour {

	private Quaternion randRot;
	private float minScale = 0.5f;
	private float maxScale = 1.8f;


	void Awake () {
		//rotVal = gameObject.transform.rotation.y;
		//rotVal = Random.Range (0f, 360f);
		randRot = Quaternion.Euler (0, Random.Range (0, 360), 0);
		transform.rotation = randRot;
		transform.localScale = Vector3.one * Random.Range(minScale, maxScale);

	}
	

}
