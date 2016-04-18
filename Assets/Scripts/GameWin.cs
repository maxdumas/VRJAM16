using UnityEngine;
using System.Collections;

public class GameWin : MonoBehaviour {

	public cutsceneManager cm;
	public OVRScreenFade osf;
	public AdultPlayerController apc;

	public void OnTriggerEnter (Collider other) {
		if (other.gameObject.GetComponent<Insect>().isPlayer == true) {
			apc.GameWin();
			//osf.enabled = true;
			//osf.FadeOut();
			//cm.callCutscene(5);
			Debug.Log ("FLAGELLEA");
		}
		
	}
}
