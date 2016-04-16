using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	//private UIstuff us;
	//private GameObject scripts;

	void Start() {
	//	scripts = GameObject.FindWithTag ("Scripts");
		//us = scripts.GetComponent<UIstuff> ();
	
	}

	void OnTriggerEnter(Collider col){
		/*if(col.name.Contains("laser")){
			us.missedShots += 1;
		} */
		PoolMaster.Despawn(col.gameObject);
		Debug.Log ("Boundary despawned: " + col.name);
	}

	/*

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Boundary") {
			us.missedShots += 1;
			PoolMaster.Despawn(this.gameObject);
			//PoolMaster.Despawn(other.gameObject);
			//Destroy (gameObject);

		} 
	
	} */
}
