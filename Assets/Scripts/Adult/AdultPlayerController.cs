﻿using UnityEngine;
using System.Collections;

public class AdultPlayerController : Controller {

	public Reticle reticle;
	
	private AdultMovement _mvmt;
	private Vector3? _target;
	private Insect _insect;
	
	void Start () {
		_mvmt = GetComponent<AdultMovement> ();
	}
	
	void Update () {
		if (_target == null) {
			if (Input.GetButtonDown ("Fire1")) {
				_target = reticle.ReticleSpawn.transform.position;
			}
		} else if (!_mvmt.MoveTowardsTarget (_target.Value)) {
			_target = null;
		}
	}

	public void OnCollisionEnter (Collision other) {
		// If we hit another insect...
		var otherInsect = other.gameObject.GetComponent<Insect> ();
		if (otherInsect != null) {
			// And it's an adult...
			if (otherInsect.Stage == Stage.Nymph) {
				_insect.IsAlive = false;
			} else if (otherInsect.Stage == Stage.Larva) {
				_insect.Strength += 2;
				reticle.ProjectionThreshold += 0.5f;
				PoolMaster.PlayAudio("Food");
				PoolMaster.PlayAudio("Explosion");
				PoolMaster.Spawn ("Explosion", "bugExplosion", this.transform.position);
				PoolMaster.Despawn(other.gameObject);
				//PoolMaster.Despawn
				Debug.Log (_insect.Strength);
			}
		}

	}

	public void GameWin() {
		if (_insect.Strength >= 30) {
			_insect.win ();
			Debug.Log ("FLAGELLEA");
			}

		}
	}

