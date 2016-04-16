using UnityEngine;
using System.Collections;

public class RandomBounce : MonoBehaviour {

	private int counter;
	private int state; 
	private int animSpeed;
	public float divider = 10.0f;
	private float realSpeed;

	public AnimationClip[] clips;

	public string[] animationNames;

	public Animation anim;

	public int speedMin = 5;
	public int speedMax = 30;
	public int stateMax = 250;
	
	void Awake () {
		animationNames = new string[clips.Length];

		anim = GetComponent<Animation>();

		foreach (AnimationClip c in clips){
			animationNames [counter++] = c.name;
		}
	}
	

	void Update () {
		animSpeed = Random.Range (speedMin, speedMax);
		state = Random.Range (0, stateMax);
		realSpeed = animSpeed / divider;

		if (state >= 0 && state <= 4) {
			Alive (animationNames [0]);
		} else if (state >= 5 && state <= 6) {
			Alive (animationNames [1]);
		} else if (state == 7) {
			Alive (animationNames [2]);
		} else if (state == 8) {
			Alive (animationNames [3]);
		}

			/*
		if (state == 0) {
			anim["float"].speed = realSpeed;
			//anim["float"].enabled = true;
			//GetComponent<Animation> (). ("float");
			anim.Play ("float");
		} else if (state == 150) {
			anim["shake"].speed = realSpeed;
			//anim["shake"].enabled = true;
			anim.Play ("shake");
		} */
	}

	public void Alive (string clip) {
		anim [clip].speed = realSpeed;
		anim.Play (clip);
	
	} 
}
