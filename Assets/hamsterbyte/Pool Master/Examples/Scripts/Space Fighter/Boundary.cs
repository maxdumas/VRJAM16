using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

	void OnTriggerExit(Collider col){

		if(col.tag != "Player"){
			Vector3 tPos = PoolMaster.GetRandomSpawnPoint("LarvaSpawn");
			PoolMaster.Despawn(col.gameObject);

			//PoolMaster.SpawnRandom (new string[]{"larvaModel"}, tPos);
			//PoolMaster.SpawnRandom ("larvaModel", tPos);

		}
	}
	
}
