using UnityEngine;
using System.Collections;

public class Test2 : MonoBehaviour {

	public void B()
	{
		GetComponent<Rigidbody>().AddForce(new Vector3(0,5,0) , ForceMode.Impulse);
	}
}
