using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {
	public Material material1;
	public Material material2;
	public float duration = 0.2F;

	void Start() {
		GetComponent<Renderer>().material = material1;
	}
	/*
	void Update() {
		float lerp = Mathf.PingPong(Time.time, duration) / duration;
		renderer.material.Lerp(material1, material2, lerp);
	}
	*/

	public void ColorSwap() {
		float lerp = Mathf.PingPong(Time.time, duration) / duration;
		GetComponent<Renderer>().material.Lerp(material1, material2, lerp);
	}
}