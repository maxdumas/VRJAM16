﻿using UnityEngine;
using System.Collections;

public class Insect : MonoBehaviour {
	public const int NYMPH_MIN_STRENGTH = 10;
	public const int ADULT_MIN_STRENGTH = 20;

	public Stage Stage;
	public GameObject Larva;
	public GameObject Nymph;
	public GameObject Adult;

	private int _strength;
	public int Strength {
		get {
			return _strength;
		}

		set {
			_strength = value;
			if(shouldEvolve()) {
				evolve();
			}
		}
	}

	bool shouldEvolve () {
		return Strength > NYMPH_MIN_STRENGTH && Stage == Stage.Larva ||
			Strength > ADULT_MIN_STRENGTH && Stage == Stage.Nymph;
	}

	void evolve () {
		Destroy (this.gameObject);
		if (Stage == Stage.Larva) {
			Instantiate (Nymph, transform.position, transform.rotation);
		} else if (Stage == Stage.Nymph) {
			Instantiate (Nymph, transform.position, transform.rotation);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
