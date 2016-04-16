using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum AsteroidGameState {
	Init,
	Idle,
	Spawn,
	Wait,
	Barrage,
	BarrageWait,
	Reset
}

public class AsteroidGameMaster : MonoBehaviour {
	public AsteroidGameState _state;
	private int _score;
	private int _highScore;
	private float _frequency = 1.5f;
	private int _barrageChance = 5;
	private float _barrageLength = 30.0f;
	private float _barrageTimer = 0.0f;
	private float _barrageFrequency = .25f;
	private int _beltChance = 30;
	private int _beltMax = 10;
	private int _beltMin = 3;
	private GameObject _title;
	private GameObject _playerShip;
	private Text _scoreText;
	private Text _highScoreText;
	
	
	
	// Use this for initialization
	void Start () {
		PoolMaster.PlayAudio("Music", true);
		StartCoroutine ("GameController");
	}

	private IEnumerator GameController () {
		while (true) {
			switch (_state) {
			case AsteroidGameState.Init:
				Init ();
				yield return new WaitForSeconds (5.0f);
				break;
			case AsteroidGameState.Idle:
				Idle ();
				yield return new WaitForEndOfFrame ();
				break;
			case AsteroidGameState.Spawn:
				Spawn ();
				yield return new WaitForEndOfFrame ();
				break;
			case AsteroidGameState.Wait:
				Wait ();
				yield return new WaitForSeconds (_frequency);
				break;
			case AsteroidGameState.Barrage:
				Barrage ();
				yield return new WaitForEndOfFrame ();
				break;
			case AsteroidGameState.BarrageWait:
				BarrageWait ();
				yield return new WaitForSeconds (_barrageFrequency);
				break;
			case AsteroidGameState.Reset:
				Reset ();
				yield return new WaitForEndOfFrame ();
				break;
			}
		}
	}
	
	private void Init () {
		_highScore = PlayerPrefs.GetInt ("HighScore");
		_scoreText = GameObject.Find ("scoreText").GetComponent<Text> ();
		_highScoreText = GameObject.Find ("highText").GetComponent<Text> ();
		_highScoreText.text = "HIGH SCORE: " + _highScore.ToString ();
		_playerShip = GameObject.Find ("playerShip");
		_title = GameObject.Find ("asteroid_title");
		_playerShip.SetActive (false);
		_state = AsteroidGameState.Idle;
	}
	
	private void Idle () {
		if (_title.activeSelf) {
			_playerShip.SetActive (true);
			_title.SetActive (false);
		}
		
		_state = AsteroidGameState.Spawn;
	}
	
	private void Spawn () {
		if (Random.Range (0, 100) < _beltChance) {
			int beltSize = Random.Range (_beltMin, _beltMax);
			for (int i = 0; i < beltSize; i++) {
				Vector3 tPos = new Vector3 (Random.Range (.1f, .9f), 1.15f, 0);
				tPos = Camera.main.ViewportToWorldPoint (tPos);
				tPos.z = 0;
				PoolMaster.SpawnRandom (new string[]{"Asteroids"}, tPos);
			}
		} else {
			Vector3 tPos = new Vector3 (Random.Range (.1f, .9f), 1.15f, 0);
			tPos = Camera.main.ViewportToWorldPoint (tPos);
			tPos.z = 0;
			PoolMaster.SpawnRandom (new string[]{"Asteroids"}, tPos);
		}
		_state = AsteroidGameState.Wait;
	}
	
	private void Wait () {
		if (Random.Range (0, 100) < _barrageChance) 
			_state = AsteroidGameState.Barrage;
		else
			_state = AsteroidGameState.Spawn;
	}
	
	private void Barrage () {
		if (Random.Range (0, 100) < _beltChance) {
			int beltSize = Random.Range (_beltMin, _beltMax);
			for (int i = 0; i < beltSize; i++) {
				Vector3 tPos = new Vector3 (Random.Range (.1f, .9f), 1.15f, 0);
				tPos = Camera.main.ViewportToWorldPoint (tPos);
				tPos.z = 0;
				PoolMaster.SpawnRandom (new string[]{"Asteroids"}, tPos);
			}
		} else {
			Vector3 tPos = new Vector3 (Random.Range (.1f, .9f), 1.15f, 0);
			tPos = Camera.main.ViewportToWorldPoint (tPos);
			tPos.z = 0;
			PoolMaster.SpawnRandom (new string[]{"Asteroids"}, tPos);
		}
		_state = AsteroidGameState.BarrageWait;
	}
	
	private void BarrageWait () {
		if (_barrageTimer < _barrageLength) {
			_barrageTimer += _barrageFrequency;
			_state = AsteroidGameState.Barrage;
		} else {
			_barrageTimer = 0;
			_state = AsteroidGameState.Wait;
		}
	}
	
	private void Reset () {
		
	}
	
	public void ModifyScore (int amt) {
		_score += amt;
		_scoreText.text = "SCORE: " + _score.ToString ();
		if (_score > _highScore) {
			_highScore = _score;
			_highScoreText.text = "HIGH SCORE: " + _highScore.ToString ();
			PlayerPrefs.SetInt ("HighScore", _highScore);
		}
	}
	
	
}
