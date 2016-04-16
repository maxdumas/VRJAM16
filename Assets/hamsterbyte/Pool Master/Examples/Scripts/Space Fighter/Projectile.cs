using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float fireSpeed = 10.0f;
	private AsteroidGameMaster _master;
	
	void OnEnable () {
		if (_master == null) {
			_master = GameObject.Find ("Main Camera").GetComponent<AsteroidGameMaster> ();
		}
		ApplyOffset ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Time.deltaTime * fireSpeed);
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.name.Contains("asteroid")) {
			_master.SendMessage ("ModifyScore", 1);
			PoolMaster.PlayAudio ("Explosion");
			PoolMaster.Spawn ("Particles", "asteroidExplosion", col.transform.position);
			col.gameObject.SendMessage ("Reset");
		}

		Reset ();
	}
	
	public void ApplyOffset () {
		Vector3 tPos = transform.position;
		tPos.x += .025f;
		tPos.y += .33f;
		transform.position = tPos;
	}
	
	public void Reset () {
		this.transform.position = Vector3.zero;
		PoolMaster.Despawn(this.gameObject);
	}
}
