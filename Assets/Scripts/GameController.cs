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
	//private GameObject _title;
	//private GameObject _playerShip;
	//private Text _scoreText;
	//private Text _highScoreText;
	
	
	
	// Use this for initialization
	void Start () {
		PoolMaster.PlayAudio("Music", true);
		StartCoroutine ("SpawnStuff");
	}

	private IEnumerator SpawnStuff () {
		while (true) {
			switch (_state) {
			case SpawnState.Init:
				Init ();
				yield return new WaitForSeconds (3.0f);
				break;
			case SpawnState.Idle:
				Idle ();
				yield return new WaitForEndOfFrame ();
				break;
			case SpawnState.Spawn:
				Spawn ();
				yield return new WaitForEndOfFrame ();
				break;
			case SpawnState.Wait:
				Wait ();
				yield return new WaitForSeconds (_frequency);
				break;
			case SpawnState.Barrage:
				Barrage ();
				yield return new WaitForEndOfFrame ();
				break;
			case SpawnState.BarrageWait:
				BarrageWait ();
				yield return new WaitForSeconds (_barrageFrequency);
				break;
			case SpawnState.Reset:
				Reset ();
				yield return new WaitForEndOfFrame ();
				break;
			}
		}
	}
	
	private void Init () {
	//	_highScore = PlayerPrefs.GetInt ("HighScore");
	//	_scoreText = GameObject.Find ("scoreText").GetComponent<Text> ();
	//	_highScoreText = GameObject.Find ("highText").GetComponent<Text> ();
	//	_highScoreText.text = "HIGH SCORE: " + _highScore.ToString ();
	//	_playerShip = GameObject.Find ("playerShip");
		//_title = GameObject.Find ("asteroid_title");
		//_playerShip.SetActive (false);
		_state = SpawnState.Idle;
	}
	
	private void Idle () {
	//	if (_title.activeSelf) {
		//	_playerShip.SetActive (true);
	//		_title.SetActive (false);
	//	}
		
		_state = SpawnState.Spawn;
	}
	
	private void Spawn () {
		if (Random.Range (0, 100) < _swarmChance) {
			int swarmSize = Random.Range (_swarmMin, _swarmMax);
			for (int i = 0; i < swarmSize; i++) {
				//Vector3 tPos = new Vector3 (Random.Range (rangeMin, rangeMax), Random.Range (rangeMin, rangeMax), Random.Range (rangeMin, rangeMax));
				//tPos = Camera.main.ViewportToWorldPoint (tPos);
				//tPos.z = 0;
				//SpawnFood
				Vector3 tPos = PoolMaster.GetRandomSpawnPoint("FoodSpawn");
				PoolMaster.Spawn ("Bugs", "food", tPos);
			}
		} else {
			//tPos = Camera.main.ViewportToWorldPoint (tPos);
			//tPos.z = 0;
			Vector3 tPos = PoolMaster.GetRandomSpawnPoint("AdultSpawn");
			PoolMaster.Spawn ("Bugs", "adultModel", tPos);
		}
		_state = SpawnState.Wait;
	}
	
	private void Wait () {
		if (Random.Range (0, 100) < _barrageChance) 
			_state = SpawnState.Barrage;
		else
			_state = SpawnState.Spawn;
	}
	
	private void Barrage () {
		if (Random.Range (0, 100) < _swarmChance) {
			int swarmSize = Random.Range (_swarmMin, _swarmMax);
			for (int i = 0; i < swarmSize; i++) {
				Vector3 tPos = PoolMaster.GetRandomSpawnPoint("NymphSpawn");
				//tPos = Camera.main.ViewportToWorldPoint (tPos);
				//tPos.z = 0;
				PoolMaster.Spawn ("Bugs", "nymphModel", tPos);
			}
		} else {
			Vector3 tPos = PoolMaster.GetRandomSpawnPoint("LarvaSpawn");
			//tPos = Camera.main.ViewportToWorldPoint (tPos);
			//tPos.z = 0;
			PoolMaster.Spawn ("Bugs", "larvaModel", tPos);
		}
		_state = SpawnState.BarrageWait;
	}
	
	private void BarrageWait () {
		if (_barrageTimer < _barrageLength) {
			_barrageTimer += _barrageFrequency;
			_state = SpawnState.Barrage;
		} else {
			_barrageTimer = 0;
			_state = SpawnState.Wait;
		}
	}


	private void Reset () {
	
	}
	/*
	public void ModifyScore (int amt) {
		_score += amt;
		_scoreText.text = "SCORE: " + _score.ToString ();
		if (_score > _highScore) {
			_highScore = _score;
			_highScoreText.text = "HIGH SCORE: " + _highScore.ToString ();
			PlayerPrefs.SetInt ("HighScore", _highScore);
		}
	}
	 */
}
