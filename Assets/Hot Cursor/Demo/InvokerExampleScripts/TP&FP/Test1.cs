using UnityEngine;
using System.Collections;

public class Test1 : MonoBehaviour {

	public void A()
	{
		GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
	}
}
