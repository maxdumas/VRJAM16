using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum SpawnState {
	Init,
	Idle,
	Spawn,
	Wait,
	Barrage,
	BarrageWait,
	Reset
}

public class GameController : MonoBehaviour {
	public SpawnState _state;
	//private int _score;
	//private int _highScore;

	public float _frequency = 1.5f;
	public int _barrageChance = 5;
	public float _barrageLength = 30.0f;
	private float _barrageTimer = 0.0f;
	public float _barrageFrequency = .25f;
	public int _swarmChance = 30;
	public int _swarmMax = 10;
	public int _swarmMin = 3;

	public float rangeMin = .1f;
	public float rangeMax = 2.2f;

	public int nObjects = 0;
	public int maxObjects;

	private float countDown = 10f;
	//private GameObject _title;
	//private GameObject _playerShip;
	//private Text _scoreText;
	//private Text _highScoreText;
	
	
	
	// Use this for initialization
	void Start () {
		PoolMaster.PlayAudio("Music", true);
		StartCoroutine (Spawner ());
	}

	public IEnumerator Spawner () {
		while (true) {
			if (nObjects < maxObjects) {
				Debug.Log ("I AM SPAWN");
				PoolMaster.Spawn ("Bugs", "food", PoolMaster.GetRandomSpawnPoint ("FoodSpawn"));
				PoolMaster.Spawn ("Bugs", "larvaModel", PoolMaster.GetRandomSpawnPoint("LarvaSpawn"));
				PoolMaster.Spawn ("Bugs", "nymphModel", PoolMaster.GetRandomSpawnPoint("NymphSpawn"));
				PoolMaster.Spawn ("Bugs", "adultModel", PoolMaster.GetRandomSpawnPoint("AdultSpawn"));
			}
			yield return new WaitForSeconds(0.8f);
			countDown = 10f;
		}
	}

	public void Update () {
		countDown -= Time.deltaTime;

		if (countDown <= 0) {
			Spawner();
		}

		nObjects = GameObject.FindObjectsOfType (typeof(MonoBehaviour)).Length;
		
		if (Input.GetKey (KeyCode.RightShift)) {
			Vector3 tPos = PoolMaster.GetRandomSpawnPoint("FoodSpawn");
			PoolMaster.Spawn ("Bugs", "food", tPos);
		}
		if (Input.GetKey (KeyCode.Tab)) {
			Vector3 tPos4 = PoolMaster.GetRandomSpawnPoint ("LarvaSpawn");
			PoolMaster.Spawn ("Bugs", "larvaModel", tPos4);
		}
		if (Input.GetKey (KeyCode.CapsLock)) {
			Vector3 tPos3 = PoolMaster.GetRandomSpawnPoint("NymphSpawn");
			PoolMaster.Spawn ("Bugs", "nymphModel", tPos3);
		}
		if (Input.GetKey (KeyCode.Alpha1)) {
			Vector3 tPos1 = PoolMaster.GetRandomSpawnPoint("AdultSpawn");
			PoolMaster.Spawn ("Bugs", "adultModel", tPos1);
		}
	}
}
