using UnityEngine;
using System.Collections;

public class RandomColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<MeshRenderer> ().material.color = Color.blue;
		gameObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.2f,1.0f),Random.Range(0.2f,1.0f),Random.Range(0.2f,1.0f));
	
	}
	

}
