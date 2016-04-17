using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class BasicGameControls : MonoBehaviour {

	//public float m_RenderScale;
	public int state;

	public float m_RenderScale = 1f;
 
	void Start () {
		VRSettings.renderScale = m_RenderScale;

		state = 01;
	}
	
	// Update is called once per frame
	void Update () {
		//adjust render scale	
		VRSettings.renderScale = m_RenderScale;

		if (Input.GetKeyDown (KeyCode.PageUp)) {
			m_RenderScale += 0.1f;
			Debug.Log("RenderScale = " + VRSettings.renderScale);
		}
		if (Input.GetKeyDown (KeyCode.PageDown)) {
			m_RenderScale -= 0.1f;
			Debug.Log("RenderScale = " + VRSettings.renderScale);
		}

		//quit
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
		//take a picture
		if (Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.Joystick1Button9)) {
			Application.CaptureScreenshot ("C:/Image" + state + ".png");
			state += 1;
			Debug.Log("Pictures Saved: " + " C:/Image" + state + ".png");
		}
			                        
		//reload scene
		if (Input.GetKey(KeyCode.Semicolon) || Input.GetKeyDown (KeyCode.Joystick1Button7)) {
			//SceneManager.LoadScene(Application.loadedLevelName);
			Application.LoadLevel(Application.loadedLevelName);
		}
	}
}
