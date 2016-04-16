using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if(col.name.Contains("asteroid")){
			PoolMaster.Despawn(col.gameObject);
		}
	}
	
}
