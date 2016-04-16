using UnityEngine;
using System.Collections;

public class hc_ToggleRenderer : MonoBehaviour {


	public void ToggleRenderer()
	{
		GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
	}


}
