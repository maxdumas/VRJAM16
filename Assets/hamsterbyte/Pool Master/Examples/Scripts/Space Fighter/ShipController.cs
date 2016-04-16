using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using hamsterbyte.PoolMaster;

public enum FireState {
	Init,
	Idle,
	Fire,
	Reset
}

public class ShipController : MonoBehaviour {

	public float movementBuffer = 1.0f;
	public float fireRate = 3.0f;
	
	private SpriteRenderer _muzzleFlash;
	private FireState _fireState;
	
	// Use this for initialization
	void Start () {
		StartCoroutine("FireRoutine");
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveShip ();
	}
	
	
	private void MoveShip(){
		Vector3 tPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		tPos.x = Mathf.Clamp01(tPos.x);
		tPos.y = Mathf.Clamp(tPos.y, 0, .8f);
		tPos = Camera.main.ViewportToWorldPoint(tPos);
		tPos.z = 0;
		this.transform.position = Vector3.Lerp(transform.position, tPos, Time.deltaTime * movementBuffer);
	}
	
	public IEnumerator FireRoutine () {
		while(true){
			switch(_fireState){
				case FireState.Init :
				Init ();
				yield return new WaitForEndOfFrame();
				break;
				case FireState.Idle : 
				Idle ();
				yield return new WaitForEndOfFrame();
				break;
				case FireState.Fire :
				Fire ();
				yield return new WaitForSeconds(1 / fireRate);
				break;
				case FireState.Reset : 
				Reset ();
				yield return new WaitForEndOfFrame();
				break;
			}
		}
	}
	
	private void Init(){
		_muzzleFlash = GameObject.Find ("MuzzleFlash").GetComponent<SpriteRenderer>();
		_muzzleFlash.enabled = false;
		_fireState = FireState.Idle;
	}
	
	private void Idle() {
		_muzzleFlash.enabled = false;
		if(Input.GetMouseButton(0))
			_fireState = FireState.Fire;
		
	}
	
	private void Fire() {
		_muzzleFlash.enabled = true;
		PoolMaster.PlayAudio("Shoot");
	PoolMaster.SpawnRandom("Projectiles", transform.position);
		_fireState = FireState.Idle;
	}

	private void Reset(){
	
	}
}
