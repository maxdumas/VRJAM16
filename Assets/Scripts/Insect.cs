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

	public cutsceneManager cM;
	public GameController gC;

	public bool toggle;
	



	private int _strength;
	public int Strength {
		get {
			return _strength;
		}

		set {
			_strength = value;
			Debug.Log (_strength);
			if(shouldEvolve()) {
				evolve();
			}
		}
	}

	private bool _isAlive = true;
	public bool IsAlive {
		get { return _isAlive; }
		set { 
			_isAlive = value; 
			if (_isAlive == false) {
				cM.callCutscene(6);
			}
		}

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
				PoolMaster.Spawn ("Bugs", "adultModel", transform.position, transform.rotation);
				//Instantiate (Nymph, transform.position, transform.rotation);
			}
		}
		else {
			if (Stage == Stage.Larva) {
				gameObject.tag = "Nymph";
				Stage = Stage.Nymph;
				gameObject.GetComponent<StickToGround>().enabled = false;
				gC.maxObjects = 700;
				gC.Spawner();
				gameObject.GetComponent<LarvaPlayerController>().enabled = false;
				gameObject.GetComponent<LarvaMovement>().enabled = false;
				gameObject.GetComponent<NymphPlayerController>().enabled = true;
				gameObject.GetComponent<NymphPlayerController>().reticle.enabled = true;
				Reticle.SetActive (true);
				gameObject.GetComponent<NymphMovement>().enabled = true;
				gameObject.GetComponent<AdultPlayerController>().enabled = false;
				gameObject.GetComponent<AdultMovement>().enabled = false;
				cM.callCutscene(3);
				Debug.Log ("I'm now a Nymphy!");
			}
			else if (Stage == Stage.Nymph) {
				gameObject.tag = "Adult";
				Stage = Stage.Adult;
				gC.maxObjects = 1000;
				gC.Spawner();
				gameObject.GetComponent<StickToGround>().enabled = false;
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
				cM.callCutscene(4);
				Debug.Log ("I'm now a Big ol' Adult!");
			}
		}
	}

	public void win () {
		cM.callCutscene (5);
	}

	// Use this for initialization
	void Start () {
		Reticle.SetActive (false);
		//gameObject.GetComponent<AdultPlayerController>().reticle.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Backslash)) {
			evolve (); 
		} else if (Input.GetKeyDown (KeyCode.Alpha0)) {
			IsAlive = false;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			gameObject.GetComponent<StickToGround>().enabled = toggle;
			toggle = !toggle;
		}

	}
}
