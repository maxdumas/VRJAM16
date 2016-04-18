using UnityEngine;
using System.Collections;

public class Insect : MonoBehaviour {
	public const int NYMPH_MIN_STRENGTH = 10;
	public const int ADULT_MIN_STRENGTH = 20;

	public Stage Stage;
	public GameObject Larva;
	public GameObject Nymph;
	public GameObject Adult;

	public GameObject Reticle;

	public bool isPlayer;

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

	private bool _isAlive = true;
	public bool IsAlive {
		get { return _isAlive; }
		set { _isAlive = value; }
	}

	bool shouldEvolve () {
		return Strength > NYMPH_MIN_STRENGTH && Stage == Stage.Larva ||
			Strength > ADULT_MIN_STRENGTH && Stage == Stage.Nymph;
	}

	void evolve () {

		if (!isPlayer) {
			PoolMaster.Despawn (this.gameObject);
			//Destroy (this.gameObject);
			if (Stage == Stage.Larva) {
				PoolMaster.Spawn ("Bugs", "nymphModel", transform.position, transform.rotation);
				//Instantiate (Nymph, transform.position, transform.rotation);
			} else if (Stage == Stage.Nymph) {
				PoolMaster.Spawn ("Bugs", "nymphModel", transform.position, transform.rotation);
				//Instantiate (Nymph, transform.position, transform.rotation);
			}
		}
		else {
			if (Stage == Stage.Larva) {
				Stage = Stage.Nymph;
				gameObject.GetComponent<LarvaPlayerController>().enabled = false;
				gameObject.GetComponent<LarvaMovement>().enabled = false;
				gameObject.GetComponent<NymphPlayerController>().enabled = true;
				gameObject.GetComponent<NymphPlayerController>().reticle.enabled = true;
				Reticle.SetActive (true);
				gameObject.GetComponent<NymphMovement>().enabled = true;
				gameObject.GetComponent<AdultPlayerController>().enabled = false;
				gameObject.GetComponent<AdultMovement>().enabled = false;

				Debug.Log ("I'm now a Nymphy!");
			}
			else if (Stage == Stage.Nymph) {
				Stage = Stage.Adult;
				gameObject.GetComponent<LarvaPlayerController>().enabled = false;
				gameObject.GetComponent<LarvaMovement>().enabled = false;
				gameObject.GetComponent<NymphPlayerController>().enabled = false;
				gameObject.GetComponent<NymphMovement>().enabled = false;
				gameObject.GetComponent<AdultPlayerController>().enabled = true;
				Reticle.SetActive (true);
				gameObject.GetComponent<AdultPlayerController>().reticle.enabled = true;
				gameObject.GetComponent<AdultMovement>().enabled = true;
				gameObject.GetComponent<AdultPlayerController>().reticle.ProjectionThreshold = gameObject.GetComponent<AdultPlayerController>().reticle.DefaultProjectionDistance;
				gameObject.GetComponent<AdultPlayerController>().reticle.InvalidTargetColor = gameObject.GetComponent<AdultPlayerController>().reticle.DefaultColor;
				Debug.Log ("I'm now a Big ol' Adult!");
			}
		}
	}

	// Use this for initialization
	void Start () {
		Reticle.SetActive (false);
		//gameObject.GetComponent<AdultPlayerController>().reticle.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Backslash)) {
			evolve ();
		}
	}
}
