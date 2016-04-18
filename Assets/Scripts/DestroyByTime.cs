﻿using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float lifetime = 1f;
	
	void Start () {
		//Destroy (gameObject, lifetime);
		PoolMaster.Despawn(this.gameObject, lifetime);
		PoolMaster.Despawn (gameObject, lifetime);
	}
}
