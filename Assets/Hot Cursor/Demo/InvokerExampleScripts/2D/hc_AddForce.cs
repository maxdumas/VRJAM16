using UnityEngine;
using System.Collections;

public class hc_AddForce : MonoBehaviour {

	public void AddForce()
	{
		GetComponent<Rigidbody2D>().AddForce(Vector2.right * 5, ForceMode2D.Force);
	}
	

}
