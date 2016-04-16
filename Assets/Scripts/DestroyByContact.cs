using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	private GameObject scripts;
//	private PlayerController pc;
//	private UIstuff us;
	public Vector3 holdingArea;
	public PointValue pv;

	//public Camera[] cameras;

	void Start () 
	{
	}


	void OnTriggerEnter (Collider other)
	{ 
		if (other.tag == "PointAffect") {
			return;
		} else {

			if (other.tag == "Boundary" || other.tag == "BTN" || other.tag == "FireButton" || other.tag == "MoveLeft" || other.tag == "MoveRight" || other.tag == "Radio") { // || other.tag == "Enemy")
				return;
			}
	
			if (explosion != null) {
				//us.score += 100;
				//	us.score += Mathf.RoundToInt(pv.points);
				ApplicationModel.explosionScore = pv.points;
				PoolMaster.PlayAudio ("Explosion");
				PoolMaster.Spawn ("Particles", "explosion_Disc", transform.position, transform.rotation);
				//PoolMaster.Spawn ("Particles", "exp");
				//Instantiate (explosion, transform.position, transform.rotation);
				//	Handheld.Vibrate ();
			}

	
			Debug.Log ("Asteroid Destroyed!");
			PoolMaster.Despawn (this.gameObject);
			//Destroy (gameObject);
			//gameObject.transform.position = holdingArea;
		}
	}
}