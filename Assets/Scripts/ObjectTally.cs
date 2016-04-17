using UnityEngine;
using System.Collections;

public class ObjectTally : MonoBehaviour {

	private Object[] tally;
	private TextMesh tm;

	// Use this for initialization
	void Start () {
		tm = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		tm = GetComponent<TextMesh> ();
		tally = GameObject.FindObjectsOfType (typeof(MonoBehaviour));
		tm.text = "Count: " + tally.Length;
	}
}
