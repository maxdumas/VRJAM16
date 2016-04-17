using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

	void OnTriggerExit(Collider col){

		if(col.tag != "Player"){
			Vector3 tPos = PoolMaster.GetRandomSpawnPoint("MySpawning1");
			PoolMaster.Despawn(col.gameObject);
			PoolMaster.SpawnRandom ("Bugs", tPos);

		}
	}
	
}
