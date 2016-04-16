using UnityEngine;
using System.Collections;

public class EventTest : MonoBehaviour {

	void Awake () {
		PoolMasterEvents.onPreloadPool += OnPreloadPool;
		PoolMasterEvents.onSpawn += OnSpawn;
		PoolMasterEvents.onDespawnObject += OnDespawnObject;
		PoolMasterEvents.onDespawnPool += OnDespawnPool;
		PoolMasterEvents.onDestroyObject += OnDestroyObject;
		PoolMasterEvents.onDestroyPool += OnDestroyPool;
		PoolMasterEvents.onPlayAudio += OnPlayAudio;
	}
	
	void OnPreloadPool (string poolName) {
		//Do something here... 
	}
	
	void OnSpawn (GameObject g) {
		//Do something here...
	}
	
	void OnDespawnObject (GameObject g) {
		//Do something here...
	}
	
	void OnDespawnPool (string poolName) {
		//Do something here...
	}
	
	void OnDestroyObject (GameObject g) {
		//Do something here...
	}
	
	void OnDestroyPool (string poolName) {
		//Do something here...
	}

	void OnPlayAudio(string clipName, GameObject objReference){
		//Do something here;
	}
}
