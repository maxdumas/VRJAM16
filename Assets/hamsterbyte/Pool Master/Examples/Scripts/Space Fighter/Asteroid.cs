using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	private float _rotAmount;
	private float _speed;
	
	void OnEnable(){
		_rotAmount = Random.Range(.5f, 1.5f);
		_speed = Random.Range(1.5f, 3.5f);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, _rotAmount);
		transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y -_speed, transform.position.z), Time.deltaTime);
	}
	
	public void Reset(){
		PoolMaster.Despawn(this.gameObject);
	}
}
