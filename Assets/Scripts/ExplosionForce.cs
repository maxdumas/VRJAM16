using UnityEngine;
using System.Collections;

public class ExplosionForce : MonoBehaviour {
	
	private Rigidbody m_Rigidbody;

	public float explosionForce;
	public Transform explosionObject;
	public Vector3 explosionPosition;
	public Vector3 forceDirection;
	public float explosionRadius;
	// Use this for initialization
	void Start () {
		m_Rigidbody = GetComponent<Rigidbody>();
		//explosionPosition = explosionObject.position;
		//m_Rigidbody.AddExplosionForce (explosionForce, explosionPosition, explosionRadius);
		//ConstantForce += strength;
		explosionForce = Random.Range (1, 5);
		explosionRadius = Random.Range (1, 8);
		//forceDirection = Random.Range (0,2);
		forceDirection = new Vector3(1, Random.Range (20, 60), -10);

		m_Rigidbody.AddForce (forceDirection);
//		Debug.Log ("Add Force!");
		//forceDirection = new Vector3
	}
	
	// Update is called once per frame
	void Update () {
		//explosionPosition = explosionObject.position;
		m_Rigidbody = gameObject.GetComponent<Rigidbody>();


		if (Input.GetKeyDown (KeyCode.Space)) {
			//m_Rigidbody.AddRelativeForce (explosionPosition);
			m_Rigidbody.AddExplosionForce (explosionForce, explosionPosition, explosionRadius);
			//Debug.Log ("Explode!");
		}

		if (Input.GetKeyDown (KeyCode.Tab)) {
			m_Rigidbody.AddForce (forceDirection);
			Debug.Log ("Add Force!");
		}

		//ConstantForce += strength;
	}
}
