using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	public int StrengthContent = 1;

	public void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Larva")) {
			other.GetComponent<Insect>().Strength += StrengthContent;
			PoolMaster.Spawn ("Explosion", "bugExplosion", transform.position);
			PoolMaster.Despawn (this.gameObject);
		}
	}

}
